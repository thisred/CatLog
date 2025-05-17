namespace ET.Client
{
    [Event(SceneType.Demo)]
    [FriendOfAttribute(typeof(ET.Client.OperaComponent))]
    public class MatchSuccessEvent : AEvent<Scene, MatchSuccess>
    {
        protected override async ETTask Run(Scene scene, MatchSuccess a)
        {
            await UIHelper.Remove(scene, UIType.UILobby);
            await UIHelper.Remove(scene, UIType.UIMatch);
        }
    }
}