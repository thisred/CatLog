namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class Room2C_RoundStartHandler : MessageHandler<Scene, Room2C_RoundStart>
    {
        protected override async ETTask Run(Scene root, Room2C_RoundStart message)
        {
            await EventSystem.Instance.PublishAsync(root, new EnterGameRound()
            {
                Round = message.Round, TurnCountdown = message.TurnCountdown, Score = message.Score
            });

            await ETTask.CompletedTask;
        }
    }
}