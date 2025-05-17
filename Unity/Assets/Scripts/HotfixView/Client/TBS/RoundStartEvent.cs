namespace ET.Client
{
    [Event(SceneType.Demo)]
    [FriendOfAttribute(typeof(ET.Client.ClientRoomComponent))]
    public class EnterGameRoundEvent : AEvent<Scene, EnterGameRound>
    {
        protected override async ETTask Run(Scene scene, EnterGameRound args)
        {
            await UIHelper.Remove(scene, UIType.UIBattle);
            UI tryCreate = await UIHelper.TryCreate(scene, UIType.UISelect, UILayer.Mid);
            tryCreate.GetComponent<UISelectCardComponent>().Init(args);
            scene.GetComponent<ClientRoomComponent>().Score = args.Score;
        }
    }
}