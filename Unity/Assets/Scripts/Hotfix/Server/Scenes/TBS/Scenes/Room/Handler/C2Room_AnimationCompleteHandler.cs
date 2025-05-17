namespace ET.Server
{
    [MessageHandler(SceneType.RoomRoot)]
    public class C2Room_AnimationCompleteHandler : MessageHandler<Scene, C2Room_AnimationComplete>
    {
        protected override async ETTask Run(Scene scene, C2Room_AnimationComplete message)
        {
            await ETTask.CompletedTask;
            var tbsRoom = scene.GetComponent<TBSRoom>();
            var tbsManager = tbsRoom.GetComponent<TBSManager>();

            tbsManager.SetAnimationCompleted(message.PlayerId);
        }
    }
}