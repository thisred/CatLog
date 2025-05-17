namespace ET.Client
{
    [Event(SceneType.Demo)]
    [FriendOfAttribute(typeof(ET.Client.UIBattleComponent))]
    public class RoundResultEvent : AEvent<Scene, BattleRoundResult>
    {
        protected override async ETTask Run(Scene scene, BattleRoundResult args)
        {
            await UIHelper.Remove(scene, UIType.UISelect);
            UI tryCreate = await UIHelper.TryCreate(scene, UIType.UIBattle, UILayer.Mid);
            UIBattleComponent uiBattleComponent = tryCreate.GetComponent<UIBattleComponent>();
            uiBattleComponent.BattlePanel.Init(args);
        }
    }
}