﻿using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(MessageLocationSenderOneType))]
    [FriendOf(typeof(MessageLocationSenderOneType))]
    [FriendOf(typeof(MessageLocationSender))]
    public static partial class MessageLocationSenderComponentSystem
    {
        [Invoke(TimerInvokeType.MessageLocationSenderChecker)]
        public class MessageLocationSenderChecker: ATimer<MessageLocationSenderOneType>
        {
            protected override void Run(MessageLocationSenderOneType self)
            {
                try
                {
                    self.Check();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
    
        [EntitySystem]
        private static void Awake(this MessageLocationSenderOneType self, int locationType)
        {
            self.LocationType = locationType;
            // 每10s扫描一次过期的actorproxy进行回收,过期时间是2分钟
            // 可能由于bug或者进程挂掉，导致ActorLocationSender发送的消息没有确认，结果无法自动删除，每一分钟清理一次这种ActorLocationSender
            self.CheckTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(10 * 1000, TimerInvokeType.MessageLocationSenderChecker, self);
        }
        
        [EntitySystem]
        private static void Destroy(this MessageLocationSenderOneType self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.CheckTimer);
        }

        private static void Check(this MessageLocationSenderOneType self)
        {
            using (var list = ListComponent<long>.Create())
            {
                long timeNow = TimeInfo.Instance.ServerNow();
                foreach ((long key, var value) in self.Children)
                {
                    var messageLocationMessageSender = (MessageLocationSender) value;

                    if (timeNow > messageLocationMessageSender.LastSendOrRecvTime + MessageLocationSenderOneType.TIMEOUT_TIME)
                    {
                        list.Add(key);
                    }
                }

                foreach (long id in list)
                {
                    self.Remove(id);
                }
            }
        }

        private static MessageLocationSender GetOrCreate(this MessageLocationSenderOneType self, long id)
        {
            if (id == 0)
            {
                throw new Exception($"actor id is 0");
            }

            if (self.Children.TryGetValue(id, out var actorLocationSender))
            {
                return (MessageLocationSender) actorLocationSender;
            }

            actorLocationSender = self.AddChildWithId<MessageLocationSender>(id);
            return (MessageLocationSender) actorLocationSender;
        }

        // 有需要主动删除actorMessageSender的需求，比如断线重连，玩家登录了不同的Gate，这时候需要通知map删掉之前的actorMessageSender
        // 然后重新创建新的，重新请求新的ActorId
        public static void Remove(this MessageLocationSenderOneType self, long id)
        {
            if (!self.Children.TryGetValue(id, out var actorMessageSender))
            {
                return;
            }

            actorMessageSender.Dispose();
        }
        
        // 发给不会改变位置的actorlocation用这个，这种actor消息不会阻塞发送队列，性能更高
        // 发送过去找不到actor不会重试,用此方法，你得保证actor提前注册好了location
        public static void Send(this MessageLocationSenderOneType self, long entityId, IMessage message)
        {
            self.SendInner(entityId, message).Coroutine();
        }
        
        private static async ETTask SendInner(this MessageLocationSenderOneType self, long entityId, IMessage message)
        {
            var messageLocationSender = self.GetOrCreate(entityId);

            var root = self.Root();
            
            if (messageLocationSender.ActorId != default)
            {
                messageLocationSender.LastSendOrRecvTime = TimeInfo.Instance.ServerNow();
                root.GetComponent<MessageSender>().Send(messageLocationSender.ActorId, message);
                return;
            }
            
            long instanceId = messageLocationSender.InstanceId;
            
            int coroutineLockType = (self.LocationType << 16) | CoroutineLockType.MessageLocationSender;
            using (await root.Root().GetComponent<CoroutineLockComponent>().Wait(coroutineLockType, entityId))
            {
                if (messageLocationSender.InstanceId != instanceId)
                {
                    throw new RpcException(ErrorCore.ERR_MessageTimeout, $"{message}");
                }
                
                if (messageLocationSender.ActorId == default)
                {
                    messageLocationSender.ActorId = await root.GetComponent<LocationProxyComponent>().Get(self.LocationType, messageLocationSender.Id);
                    if (messageLocationSender.InstanceId != instanceId)
                    {
                        throw new RpcException(ErrorCore.ERR_ActorLocationSenderTimeout2, $"{message}");
                    }
                }
                
                messageLocationSender.LastSendOrRecvTime = TimeInfo.Instance.ServerNow();
                root.GetComponent<MessageSender>().Send(messageLocationSender.ActorId, message);
            }
        }

        // 发给不会改变位置的actorlocation用这个，这种actor消息不会阻塞发送队列，性能更高，发送过去找不到actor不会重试
        // 发送过去找不到actor不会重试,用此方法，你得保证actor提前注册好了location
        public static async ETTask<IResponse> Call(this MessageLocationSenderOneType self, long entityId, IRequest request)
        {
            var messageLocationSender = self.GetOrCreate(entityId);

            var root = self.Root();
            
            if (messageLocationSender.ActorId != default)
            {
                messageLocationSender.LastSendOrRecvTime = TimeInfo.Instance.ServerNow();
                return await root.GetComponent<MessageSender>().Call(messageLocationSender.ActorId, request);
            }
            
            long instanceId = messageLocationSender.InstanceId;
            
            int coroutineLockType = (self.LocationType << 16) | CoroutineLockType.MessageLocationSender;
            using (await root.GetComponent<CoroutineLockComponent>().Wait(coroutineLockType, entityId))
            {
                if (messageLocationSender.InstanceId != instanceId)
                {
                    throw new RpcException(ErrorCore.ERR_MessageTimeout, $"{request}");
                }

                if (messageLocationSender.ActorId == default)
                {
                    messageLocationSender.ActorId = await root.GetComponent<LocationProxyComponent>().Get(self.LocationType, messageLocationSender.Id);
                    if (messageLocationSender.InstanceId != instanceId)
                    {
                        throw new RpcException(ErrorCore.ERR_ActorLocationSenderTimeout2, $"{request}");
                    }
                }
            }

            messageLocationSender.LastSendOrRecvTime = TimeInfo.Instance.ServerNow();
            return await root.GetComponent<MessageSender>().Call(messageLocationSender.ActorId, request);
        }

        public static void Send(this MessageLocationSenderOneType self, long entityId, ILocationMessage message)
        {
            self.Call(entityId, message).Coroutine();
        }

        public static async ETTask<IResponse> Call(this MessageLocationSenderOneType self, long entityId, ILocationRequest iRequest)
        {
            var messageLocationSender = self.GetOrCreate(entityId);

            var root = self.Root();
            var iRequestType = iRequest.GetType();
            long actorLocationSenderInstanceId = messageLocationSender.InstanceId;
            int coroutineLockType = (self.LocationType << 16) | CoroutineLockType.MessageLocationSender;
            using (await root.GetComponent<CoroutineLockComponent>().Wait(coroutineLockType, entityId))
            {
                if (messageLocationSender.InstanceId != actorLocationSenderInstanceId)
                {
                    throw new RpcException(ErrorCore.ERR_NotFoundActor, $"{iRequest}");
                }

                try
                {
                    return await self.CallInner(messageLocationSender, iRequest);
                }
                catch (RpcException)
                {
                    self.Remove(messageLocationSender.Id);
                    throw;
                }
                catch (Exception e)
                {
                    self.Remove(messageLocationSender.Id);
                    throw new Exception($"{iRequestType.FullName}", e);
                }
            }
        }

        private static async ETTask<IResponse> CallInner(this MessageLocationSenderOneType self, MessageLocationSender messageLocationSender, IRequest iRequest)
        {
            int failTimes = 0;
            long instanceId = messageLocationSender.InstanceId;
            messageLocationSender.LastSendOrRecvTime = TimeInfo.Instance.ServerNow();
            
            var root = self.Root();

            var requestType = iRequest.GetType();
            while (true)
            {
                if (messageLocationSender.ActorId == default)
                {
                    messageLocationSender.ActorId = await root.GetComponent<LocationProxyComponent>().Get(self.LocationType, messageLocationSender.Id);
                    if (messageLocationSender.InstanceId != instanceId)
                    {
                        throw new RpcException(ErrorCore.ERR_ActorLocationSenderTimeout2, $"{iRequest}");
                    }
                }

                if (messageLocationSender.ActorId == default)
                {
                    return MessageHelper.CreateResponse(requestType, 0, ErrorCore.ERR_NotFoundActor);
                }
                var response = await root.GetComponent<MessageSender>().Call(messageLocationSender.ActorId, iRequest, needException: false);
                
                if (messageLocationSender.InstanceId != instanceId)
                {
                    throw new RpcException(ErrorCore.ERR_ActorLocationSenderTimeout3, $"{requestType.FullName}");
                }
                
                switch (response.Error)
                {
                    case ErrorCore.ERR_NotFoundActor:
                    {
                        // 如果没找到Actor,重试
                        ++failTimes;
                        if (failTimes > 20)
                        {
                            Log.Debug($"actor send message fail, actorid: {messageLocationSender.Id} {requestType.FullName}");
                            
                            // 这里删除actor，后面等待发送的消息会判断InstanceId，InstanceId不一致返回ERR_NotFoundActor
                            self.Remove(messageLocationSender.Id);
                            return response;
                        }

                        // 等待0.5s再发送
                        await root.GetComponent<TimerComponent>().WaitAsync(500);
                        if (messageLocationSender.InstanceId != instanceId)
                        {
                            throw new RpcException(ErrorCore.ERR_ActorLocationSenderTimeout4, $"{requestType.FullName}");
                        }

                        messageLocationSender.ActorId = default;
                        continue;
                    }
                    case ErrorCore.ERR_MessageTimeout:
                    {
                        throw new RpcException(response.Error, $"{requestType.FullName}");
                    }
                }

                if (ErrorCore.IsRpcNeedThrowException(response.Error))
                {
                    throw new RpcException(response.Error, $"Message: {response.Message} Request: {requestType.FullName}");
                }

                return response;
            }
        }
    }

    [EntitySystemOf(typeof(MessageLocationSenderComponent))]
    [FriendOf(typeof (MessageLocationSenderComponent))]
    public static partial class MessageLocationSenderManagerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MessageLocationSenderComponent self)
        {
            for (int i = 0; i < self.messageLocationSenders.Length; ++i)
            {
                self.messageLocationSenders[i] = self.AddChild<MessageLocationSenderOneType, int>(i);
            }
        }
        
        public static MessageLocationSenderOneType Get(this MessageLocationSenderComponent self, int locationType)
        {
            return self.messageLocationSenders[locationType];
        }
    }
}