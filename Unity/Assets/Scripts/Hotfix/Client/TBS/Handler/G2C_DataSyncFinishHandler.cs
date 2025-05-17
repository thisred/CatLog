namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class G2C_DataSyncFinishHandler : MessageHandler<Scene, G2C_DataSyncFinish>
    {
        protected override async ETTask Run(Scene entity, G2C_DataSyncFinish message)
        {
            await ETTask.CompletedTask;
        }
    }
}