﻿namespace ET.Server
{
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_MatchHandler : MessageSessionHandler<C2G_Match, G2C_Match>
    {
        protected override async ETTask Run(Session session, C2G_Match request, G2C_Match response)
        {
            var player = session.GetComponent<SessionPlayerComponent>().Player;
            var startSceneConfig = StartSceneConfigCategory.Instance.Match;

            var g2MatchMatch = G2Match_Match.Create();
            g2MatchMatch.Id = player.Id;
            await session.Root().GetComponent<MessageSender>().Call(startSceneConfig.ActorId, g2MatchMatch);
        }
    }
}