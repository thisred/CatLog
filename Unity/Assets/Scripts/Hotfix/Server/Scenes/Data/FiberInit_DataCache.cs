using System.Net;

namespace ET.Server
{
    [Invoke((long)SceneType.DataCache)]
    public class FiberInit_DataCache : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            var root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<PlayerComponent>();
            root.AddComponent<GateSessionKeyComponent>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<MessageLocationSenderComponent>();
            root.AddComponent<DataCacheComponent>();
            root.AddComponent<DBManagerComponent>();

            var startSceneConfig = StartSceneConfigCategory.Instance.Get((int)root.Id);
            root.AddComponent<NetComponent, IPEndPoint, NetworkProtocol>(startSceneConfig.InnerIPPort, NetworkProtocol.UDP);
            await ETTask.CompletedTask;
        }
    }
}