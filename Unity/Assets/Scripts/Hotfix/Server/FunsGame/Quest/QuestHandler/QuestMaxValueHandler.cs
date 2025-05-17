// // 记录最大值的任务
//
// namespace ET.Server
// {
// 	[QuestHandler(
// 		QuestType.HitFlyNumOneBattle,
// 		QuestType.HitBackNumOneBattle,
// 		QuestType.MaxDamage,
// 		QuestType.CharmLastMonster,
// 		QuestType.TurtleClickAttackNum,
// 		QuestType.TurlteClickUltimateNum,
// 		QuestType.FriendBorrowHeroCount,
// 		QuestType.GradeLeveIn2048,
// 		QuestType.ClearAnimalArenaRoundTimes,
// 		QuestType.GuildBossStageNKill,
// 		QuestType.TurpleSkillMaxNum,
// 		QuestType.CampSkillMaxNum,
// 		QuestType.BondLevel,
// 		QuestType.ChallengeDungeonScore,
// 		QuestType.ReputationReaches
// 	)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestMaxValueHandler : AQuestHandler<QuestValueParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, QuestValueParam args)
// 		{
// 			await ETTask.CompletedTask;
// 			if (quest.QuestProgress < args.Value)
// 			{
// 				quest.SetProgress(args.Value);
// 			}
// 		}
// 	}
// }