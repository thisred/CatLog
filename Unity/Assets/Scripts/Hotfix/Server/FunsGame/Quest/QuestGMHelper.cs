// namespace ET.Server
// {
// 	[FriendOf(typeof(QuestsComponent))]
// 	public static class QuestGMHelper
// 	{
// 		/// <summary>
// 		/// GM刷新任务
// 		/// </summary>
// 		public static void InitQuest(Unit unit)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			questsComponent.Dispose();
// 			questsComponent = unit.AddComponent<QuestsComponent>();
// 			QuestHelper.OnLogin(unit);
// 			QuestNoticeHelper.SyncAllQuest(unit);
// 		}
// 	}
// }