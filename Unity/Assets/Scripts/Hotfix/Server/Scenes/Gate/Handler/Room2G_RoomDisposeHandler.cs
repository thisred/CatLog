namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    public class Room2G_RoomDisposeHandler : MessageHandler<Scene, Room2G_RoomDispose>
    {
        protected override async ETTask Run(Scene scene, Room2G_RoomDispose message)
        {
            await ETTask.CompletedTask;
            foreach (long playerId in message.PlayerIds)
            {
                var playerComponent = scene.GetComponent<PlayerComponent>();
                var player = playerComponent.GetChild<Player>(playerId);
                if (player != null)
                {
                    var playerRoomComponent = player.GetComponent<PlayerRoomComponent>();
                    playerRoomComponent?.Dispose();
                }
            }
        }
    }
}