namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BattleResultEvent : AEvent<Scene, BattleResult>
    {
        protected override async ETTask Run(Scene scene, BattleResult args)
        {
            await UIHelper.Remove(scene, UIType.UISelect);
            await UIHelper.Remove(scene, UIType.UIMatch);
            await UIHelper.Remove(scene, UIType.UIBattle);

            UI tryCreate = await UIHelper.TryCreate(scene, UIType.UIResult, UILayer.Mid);
            UIResultComponent uiResultComponent = tryCreate.GetComponent<UIResultComponent>();
            uiResultComponent.SetResult(args);
        }
    }
}