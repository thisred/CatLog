namespace ET.Client
{
    [Event(SceneType.Demo)]
    [FriendOfAttribute(typeof(ET.Client.ClientRoomComponent))]
    public class GameRoomStartEvent : AEvent<Scene, GameRoomStart>
    {
        protected override async ETTask Run(Scene scene, GameRoomStart a)
        {
            await ETTask.CompletedTask;
            ClientRoomComponent clientRoomComponent = scene.AddComponent<ClientRoomComponent>();
            clientRoomComponent.PlayerIds.AddRange(a.PlayerIds);
        }
    }
}