namespace ET.Server
{
    [MessageHandler(SceneType.RoomRoot)]
    public class C2Room_StartBattleHandler : MessageHandler<Scene, C2Room_StartBattle>
    {
        protected override async ETTask Run(Scene scene, C2Room_StartBattle message)
        {
            await ETTask.CompletedTask;
            var tbsRoom = scene.GetComponent<TBSRoom>();
            var tbsManager = tbsRoom.GetComponent<TBSManager>();
            var playerRoundInput = new PlayerRoundInput();
            foreach (int i in message.CardId)
            {
                playerRoundInput.Cards.Add((CardType)i);
            }

            tbsManager.SetPlayerInput(message.PlayerId, playerRoundInput);
            // 检查是否所有人输入完成，在状态机里update检查
        }
    }
}