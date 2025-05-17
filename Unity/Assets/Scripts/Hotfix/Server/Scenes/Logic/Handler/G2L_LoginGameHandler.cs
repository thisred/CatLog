namespace ET.Server
{
    [MessageHandler(SceneType.Logic)]
    public class G2L_LoginGameHandler : MessageHandler<Scene, G2L_LoginGame, L2G_LoginGame>
    {
        protected override async ETTask Run(Scene scene, G2L_LoginGame request, L2G_LoginGame response)
        {
            var unit = await UnitFactory.LoadOrCreatePlayer(scene, request.RoleId);
            UnitFactory.Init(unit);
            UnitFactory.SyncData(unit);
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}