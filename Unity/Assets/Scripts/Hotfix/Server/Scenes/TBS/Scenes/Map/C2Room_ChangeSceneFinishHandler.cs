namespace ET.Server
{
    [MessageHandler(SceneType.RoomRoot)]
    [FriendOf(typeof(RoomServerComponent))]
    public class C2Room_ChangeSceneFinishHandler : MessageHandler<Scene, C2Room_ChangeSceneFinish>
    {
        protected override async ETTask Run(Scene root, C2Room_ChangeSceneFinish message)
        {
            var room = root.GetComponent<TBSRoom>();
            var roomServerComponent = room.GetComponent<RoomServerComponent>();
            var roomPlayer = room.GetComponent<RoomServerComponent>().GetChild<RoomPlayer>(message.PlayerId);
            roomPlayer.Progress = 100;
            if (!roomServerComponent.IsAllPlayerProgress100())
            {
                return;
            }

            await room.Fiber.Root.GetComponent<TimerComponent>().WaitAsync(1000);

            var room2CStart = Room2C_Start.Create();
            room2CStart.StartTime = TimeInfo.Instance.ServerFrameTime();
            // 下发房间内的人的信息给客户端
            foreach (var rp in roomServerComponent.Children.Values)
            {
                var player = (RoomPlayer)rp;
                var tbsUnitInfo = TBSUnitInfo.Create();
                tbsUnitInfo.PlayerId = player.Id;
                room2CStart.UnitInfo.Add(tbsUnitInfo);
            }

            room.Init(room2CStart.StartTime);
            room.InitPlayer(room2CStart.UnitInfo);
            room.Start();
            // 发角色信息，血量，位置等
            RoomMessageHelper.BroadCast(room, room2CStart);
        }
    }
}