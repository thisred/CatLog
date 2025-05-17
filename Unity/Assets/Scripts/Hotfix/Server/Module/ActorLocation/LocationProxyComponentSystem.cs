﻿using System;

namespace ET.Server
{
    public static partial class LocationProxyComponentSystem
    {
        private static ActorId GetLocationSceneId(long key)
        {
            return StartSceneConfigCategory.Instance.LocationConfig.ActorId;
        }

        public static async ETTask Add(this LocationProxyComponent self, int type, long key, ActorId actorId)
        {
            var fiber = self.Fiber();
            Log.Info($"location proxy add {key}, {actorId} {TimeInfo.Instance.ServerNow()}");
            var objectAddRequest = ObjectAddRequest.Create();
            objectAddRequest.Type = type;
            objectAddRequest.Key = key;
            objectAddRequest.ActorId = actorId;
            await fiber.Root.GetComponent<MessageSender>().Call(GetLocationSceneId(key), objectAddRequest);
        }

        public static async ETTask Lock(this LocationProxyComponent self, int type, long key, ActorId actorId, int time = 60000)
        {
            var fiber = self.Fiber();
            Log.Info($"location proxy lock {key}, {actorId} {TimeInfo.Instance.ServerNow()}");

            var objectLockRequest = ObjectLockRequest.Create();
            objectLockRequest.Type = type;
            objectLockRequest.Key = key;
            objectLockRequest.ActorId = actorId;
            objectLockRequest.Time = time;
            await fiber.Root.GetComponent<MessageSender>().Call(GetLocationSceneId(key), objectLockRequest);
        }

        public static async ETTask UnLock(this LocationProxyComponent self, int type, long key, ActorId oldActorId, ActorId newActorId)
        {
            var fiber = self.Fiber();
            Log.Info($"location proxy unlock {key}, {newActorId} {TimeInfo.Instance.ServerNow()}");
            var objectUnLockRequest = ObjectUnLockRequest.Create();
            objectUnLockRequest.Type = type;
            objectUnLockRequest.Key = key;
            objectUnLockRequest.OldActorId = oldActorId;
            objectUnLockRequest.NewActorId = newActorId;
            await fiber.Root.GetComponent<MessageSender>().Call(GetLocationSceneId(key), objectUnLockRequest);
        }

        public static async ETTask Remove(this LocationProxyComponent self, int type, long key)
        {
            var fiber = self.Fiber();
            Log.Info($"location proxy remove {key}, {TimeInfo.Instance.ServerNow()}");

            var objectRemoveRequest = ObjectRemoveRequest.Create();
            objectRemoveRequest.Type = type;
            objectRemoveRequest.Key = key;
            await fiber.Root.GetComponent<MessageSender>().Call(GetLocationSceneId(key), objectRemoveRequest);
        }

        public static async ETTask<ActorId> Get(this LocationProxyComponent self, int type, long key)
        {
            if (key == 0)
            {
                throw new Exception($"get location key 0");
            }

            // location server配置到共享区，一个大战区可以配置N多个location server,这里暂时为1
            var objectGetRequest = ObjectGetRequest.Create();
            objectGetRequest.Type = type;
            objectGetRequest.Key = key;
            var response =
                    (ObjectGetResponse) await self.Root().GetComponent<MessageSender>().Call(GetLocationSceneId(key), objectGetRequest);
            return response.ActorId;
        }

        public static async ETTask AddLocation(this Entity self, int type)
        {
            await self.Root().GetComponent<LocationProxyComponent>().Add(type, self.Id, self.GetActorId());
        }

        public static async ETTask RemoveLocation(this Entity self, int type)
        {
            await self.Root().GetComponent<LocationProxyComponent>().Remove(type, self.Id);
        }
    }
}