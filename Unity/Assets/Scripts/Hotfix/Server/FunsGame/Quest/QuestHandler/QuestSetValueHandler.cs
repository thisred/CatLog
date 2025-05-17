// // 直接设置值的任务
//
// namespace ET.Server
// {
// 	[QuestHandler(
// 		QuestType.SpeakInPublicChatDays,
// 		QuestType.FriendCount,
// 		QuestType.BondTotalLevel
// 	)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSetValueHandler : AQuestHandler<QuestValueParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, QuestValueParam args)
// 		{
// 			await ETTask.CompletedTask;
// 			quest.SetProgress(args.Value);
// 		}
// 	}
//
// }