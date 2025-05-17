namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class Room2C_BattleResultHandler : MessageHandler<Scene, Room2C_BattleResult>
    {
        protected override async ETTask Run(Scene entity, Room2C_BattleResult message)
        {
            await EventSystem.Instance.PublishAsync(entity, new BattleResult()
            {
                WinnerId = message.WinPlayerId,
            });
        }
    }
}