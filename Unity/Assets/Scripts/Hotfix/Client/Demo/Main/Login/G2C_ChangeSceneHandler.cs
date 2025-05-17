namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class Match2G_NotifyMatchSuccessHandler : MessageHandler<Scene, Match2G_NotifyMatchSuccess>
    {
        protected override async ETTask Run(Scene root, Match2G_NotifyMatchSuccess message)
        {
            EventSystem.Instance.Publish(root, new MatchSuccess());
            
            await SceneChangeHelper.EnterWorldScene(root, "Map2", message.ActorId.InstanceId);
        }
    }
}