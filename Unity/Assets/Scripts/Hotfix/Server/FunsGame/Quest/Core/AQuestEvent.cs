namespace ET.Server
{
    [FriendOf(typeof(QuestsComponent))]
    [EnableClass]
    public abstract class AQuestEvent<A> : AEvent<Scene, A> where A : struct, IUnitEvent
    {
        /// <summary>
        /// 处理任务后同步给客户端
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="a"></param>
        protected override async ETTask Run(Scene scene, A a)
        {
            await Process(scene, a);
            Sync(scene, a).Coroutine();
        }

        private async ETTask Sync(Scene scene, A a)
        {
            var unit = a.Unit;
            var com = unit.GetComponent<QuestsComponent>();
            var timerComponent = scene.Root().GetComponent<TimerComponent>();
            await timerComponent.WaitFrameAsync(); // 等待1帧后同步，目的减少同步次数
            QuestNoticeHelper.SyncQuest(unit, com.ChangedQuestIds);
            com.ChangedQuestIds.Clear();
        }

        protected abstract ETTask Process(Scene scene, A a);
    }
}