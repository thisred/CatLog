﻿using System.Net.Sockets;

namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_LoginHandler: MessageHandler<Scene, Main2NetClient_Login, NetClient2Main_Login>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_Login request, NetClient2Main_Login response)
        {
            string account = request.Account;
            string password = request.Password;
            // 创建一个ETModel层的Session
            root.RemoveComponent<RouterAddressComponent>();
            // 获取路由跟realmDispatcher地址
            var routerAddressComponent =
                    root.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
            await routerAddressComponent.Init();
            root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily, NetworkProtocol.UDP);
            root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;

            var netComponent = root.GetComponent<NetComponent>();
            
            var realmAddress = routerAddressComponent.GetRealmAddress(account);

            R2C_Login r2CLogin;
            using (var session = await netComponent.CreateRouterSession(realmAddress, account, password))
            {
                var c2RLogin = C2R_Login.Create();
                c2RLogin.Account = account;
                c2RLogin.Password = password;
                r2CLogin = (R2C_Login)await session.Call(c2RLogin);
            }

            // 创建一个gate Session,并且保存到SessionComponent中
            var gateSession = await netComponent.CreateRouterSession(NetworkHelper.ToIPEndPoint(r2CLogin.Address), account, password);
            gateSession.AddComponent<ClientSessionErrorComponent>();
            root.AddComponent<SessionComponent>().Session = gateSession;
            var c2GLoginGate = C2G_LoginGate.Create();
            c2GLoginGate.Key = r2CLogin.Key;
            c2GLoginGate.GateId = r2CLogin.GateId;
            var g2CLoginGate = (G2C_LoginGate)await gateSession.Call(c2GLoginGate);

            Log.Debug("登陆gate成功!");

            // await gateSession.Call(C2G_EnterMap.Create());
            response.PlayerId = g2CLoginGate.PlayerId;
        }
    }
}