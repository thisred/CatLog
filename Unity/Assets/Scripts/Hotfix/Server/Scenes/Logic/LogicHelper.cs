namespace ET.Server
{
    public static class LogicHelper
    {
        public static async ETTask EnterLogic(Player player)
        {
            int zone = player.Zone();
            long roleId = player.RoleId;
            var scene = player.Scene();
            await scene.Fiber().WaitFrameFinish();
            ulong hash = (ulong)roleId.GetHashCode();
            var logics = StartSceneConfigCategory.Instance.Logics[zone];
            var sceneConfig = logics[(int)(hash % (ulong)logics.Count)];

            var g2LLoginGame = G2L_LoginGame.Create();
            g2LLoginGame.RoleId = roleId;
            g2LLoginGame.OldActorId = player.GetActorId();
            await scene.GetComponent<LocationProxyComponent>().Lock(LocationType.Unit, roleId, player.GetActorId());
            await scene.GetComponent<MessageSender>().Call(sceneConfig.ActorId, g2LLoginGame);
        }
    }
}