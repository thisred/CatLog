namespace ET.Server
{
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_LoginGateHandler : MessageSessionHandler<C2G_LoginGate, G2C_LoginGate>
    {
        protected override async ETTask Run(Session session, C2G_LoginGate request, G2C_LoginGate response)
        {
            var root = session.Root();
            string account = root.GetComponent<GateSessionKeyComponent>().Get(request.Key);
            if (account == null)
            {
                response.Error = ErrorCore.ERR_ConnectGateKeyError;
                response.Message = "Gate key验证失败!";
                return;
            }

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            var playerComponent = root.GetComponent<PlayerComponent>();
            var player = playerComponent.GetByAccount(account);
            if (player == null)
            {
                player = playerComponent.AddChild<Player, string>(account);
                playerComponent.Add(player);
                var playerSessionComponent = player.AddComponent<PlayerSessionComponent>();
                playerSessionComponent.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.GateSession);
                await playerSessionComponent.AddLocation(LocationType.GateSession);

                player.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
                await player.AddLocation(LocationType.Player);
            }

            if (session.GetComponent<SessionPlayerComponent>() == null)
                session.AddComponent<SessionPlayerComponent>().Player = player;
            player.GetComponent<PlayerSessionComponent>().Session = session;

            player.RoleId = request.RoleId;
            EnterGame(player, session).Coroutine();
            response.PlayerId = player.Id;
            await ETTask.CompletedTask;
        }

        private static async ETTask EnterGame(Player player, Session session)
        {
            await LogicHelper.EnterLogic(player);
            var syncFinish = G2C_DataSyncFinish.Create();
            session.Send(syncFinish);
            // 判断是否在战斗
            var playerRoomComponent = player.GetComponent<PlayerRoomComponent>();
            if (playerRoomComponent != null && playerRoomComponent.RoomActorId != default)
            {
                await CheckRoom(player, session);
            }
            else
            {
                var playerSessionComponent = player.GetComponent<PlayerSessionComponent>();
                playerSessionComponent.Session = session;
            }
        }

        private static async ETTask CheckRoom(Player player, Session session)
        {
            var fiber = player.Fiber();
            await fiber.WaitFrameFinish();

            var g2RoomReconnect = G2Room_Reconnect.Create();
            g2RoomReconnect.PlayerId = player.Id;
            using var room2GateReconnect = await fiber.Root.GetComponent<MessageSender>().Call(player.GetComponent<PlayerRoomComponent>().RoomActorId,
                g2RoomReconnect) as Room2G_Reconnect;
            var g2CReconnect = G2C_Reconnect.Create();
            // g2CReconnect.StartTime = room2GateReconnect.StartTime;
            // g2CReconnect.Frame = room2GateReconnect.Frame;
            // g2CReconnect.UnitInfos.AddRange(room2GateReconnect.UnitInfos);
            g2CReconnect.ActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
            session.Send(g2CReconnect);

            if (session.GetComponent<SessionPlayerComponent>() == null)
            {
                session.AddComponent<SessionPlayerComponent>().Player = player;
            }

            player.GetComponent<PlayerSessionComponent>().Session = session;
        }
    }
}