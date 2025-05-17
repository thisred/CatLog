namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class G2C_ReconnectHandler: MessageHandler<Scene, G2C_Reconnect>
    {
        protected override async ETTask Run(Scene root, G2C_Reconnect message)
        {
            await SceneChangeHelper.EnterWorldScene(root, "Map2", message.ActorId.InstanceId);
            await ETTask.CompletedTask;
        }
    }
}