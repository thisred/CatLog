namespace ET.Server
{
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_CancelMatchHandler : MessageSessionHandler<C2G_CancelMatch, G2C_CancelMatch>
    {
        protected override async ETTask Run(Session session, C2G_CancelMatch request, G2C_CancelMatch response)
        {
            var player = session.GetComponent<SessionPlayerComponent>().Player;
            var startSceneConfig = StartSceneConfigCategory.Instance.Match;

            var cancelMatch = G2Match_CancelMatch.Create();
            cancelMatch.Id = player.Id;
            await session.Root().GetComponent<MessageSender>().Call(startSceneConfig.ActorId, cancelMatch);
        }
    }
}