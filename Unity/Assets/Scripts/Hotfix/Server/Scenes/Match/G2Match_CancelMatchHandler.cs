namespace ET.Server
{
    [MessageHandler(SceneType.Match)]
    [FriendOfAttribute(typeof(ET.Server.MatchComponent))]
    public class G2Match_CancelMatchHandler : MessageHandler<Scene, G2Match_CancelMatch, Match2G_CancelMatch>
    {
        protected override async ETTask Run(Scene scene, G2Match_CancelMatch request, Match2G_CancelMatch response)
        {
            var matchComponent = scene.GetComponent<MatchComponent>();
            matchComponent.waitMatchPlayers.Remove(request.Id);
            await ETTask.CompletedTask;
        }
    }
}