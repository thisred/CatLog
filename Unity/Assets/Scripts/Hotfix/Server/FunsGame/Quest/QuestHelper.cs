// namespace ET.Server
// {
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(QuestsComponent))]
// 	public static partial class QuestHelper
// 	{
// 		/// <summary>
// 		/// 更新任务进度。自定义任务参数时调用
// 		/// </summary>
// 		public static void Run<T>(Unit unit, QuestType actionType, T args, bool sync = false) where T : IQuestParam
// 		{
// 			Run2(unit, actionType, args, sync).Coroutine();
// 		}
//
// 		/// <summary>
// 		/// 更新任务进度。在仅有进度一个参数时可调用
// 		/// </summary>
// 		public static void Run(Unit unit, QuestType actionType, long value, bool sync = false)
// 		{
// 			Run2(unit, actionType, new QuestValueParam { Value = value }, sync).Coroutine();
// 		}
//
// 		/// <summary>
// 		/// 更新任务进度。不传参数，根据当前unit的组件信息去判断任务进度
// 		/// </summary>
// 		public static void Run(Unit unit, QuestType actionType, bool sync = false)
// 		{
// 			Run2(unit, actionType, new QuestNoParam(), sync).Coroutine();
// 		}
//
// 		private static async ETTask Run2<T>(Unit unit, QuestType actionType, T args, bool sync) where T : IQuestParam
// 		{
// 			await Process(unit, actionType, args);
// 			if (sync)
// 			{
// 				var questsComponent = unit.GetComponent<QuestsComponent>();
// 				QuestNoticeHelper.SyncQuest(unit, questsComponent.ChangedQuestIds);
// 				questsComponent.ChangedQuestIds.Clear();
// 			}
// 		}
//
// 		private static async ETTask Process<T>(Unit unit, QuestType actionType, T args) where T : IQuestParam
// 		{
// 			var component = unit.GetComponent<QuestsComponent>();
// 			// 处理成就，成就任务不事先加在玩家身上。
// 			// var achievements = QUEST_Table.Instance.GetAchievements(actionType);
// 			// if (achievements.Count > 0)
// 			// {
// 			// 	foreach (var achievement in achievements)
// 			// 	{
// 			// 		component.GetOrAddQuest(achievement.Id);
// 			// 	}
// 			// }
//
// 			var quests = await QuestHandlerComponent.Instance.Process(component, actionType, args);
// 			foreach (var quest in quests)
// 			{
// 				if (quest.QuestState == QuestState.Completed && quest.Config.GetAwardsInstantly)
// 					TryGetQuestReward(unit, quest.ConfigId, out var list);
// 			}
//
// 			foreach (var quest in quests)
// 			{
// 				component.ChangedQuestIds.Add(quest.ConfigId);
// 			}
// 		}
// 	}
// }