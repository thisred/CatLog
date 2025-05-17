namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class Room2C_BattleRoundsResultHandler : MessageHandler<Scene, Room2C_BattleRoundsResult>
    {
        protected override async ETTask Run(Scene entity, Room2C_BattleRoundsResult message)
        {
            BattleRoundResult battleRoundResult = new BattleRoundResult()
            {
                Round = message.Round,
                CardInfos = message.Infos,
            };
            long myId = entity.Root().GetComponent<PlayerComponent>().MyId;
            foreach ((long key, SelectInfo value) in message.SelectInfos)
            {
                if (key == myId)
                {
                    battleRoundResult.left = (value.HeroIds);
                    battleRoundResult.leftId = key;
                }
                else
                {
                    battleRoundResult.right = (value.HeroIds);
                    battleRoundResult.rightId = key;
                }
            }

            await EventSystem.Instance.PublishAsync(entity, battleRoundResult);
        }
    }
}