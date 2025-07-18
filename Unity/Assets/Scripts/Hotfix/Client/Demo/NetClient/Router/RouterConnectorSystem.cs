﻿using System.Net;

namespace ET.Client
{
    [FriendOf(typeof(RouterConnector))]
    [EntitySystemOf(typeof(RouterConnector))]
    public static partial class RouterConnectorSystem
    {
        [EntitySystem]
        private static void Awake(this RouterConnector self)
        {
            var netComponent = self.GetParent<NetComponent>();
            var kService = (KService)netComponent.AService;
            kService.AddRouterAckCallback(self.Id, (flag) =>
            {
                self.Flag = flag;
            });
        }
        [EntitySystem]
        private static void Destroy(this RouterConnector self)
        {
            var netComponent = self.GetParent<NetComponent>();
            var kService = (KService)netComponent.AService;
            kService.RemoveRouterAckCallback(self.Id);
        }

        public static void Connect(this RouterConnector self, byte[] bytes, int index, int length, IPEndPoint ipEndPoint)
        {
            var netComponent = self.GetParent<NetComponent>();
            var kService = (KService)netComponent.AService;
            kService.Transport.Send(bytes, index, length, ipEndPoint);
        }
    }
}