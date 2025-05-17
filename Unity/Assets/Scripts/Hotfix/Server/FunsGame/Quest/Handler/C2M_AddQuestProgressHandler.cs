// namespace ET.Server
// {
// 	[ActorMessageHandler(SceneType.Map)]
// 	public class
// 		C2M_AddQuestProgressHandler : AMActorLocationRpcHandler<Unit, C2M_AddQuestProgress, M2C_AddQuestProgress>
// 	{
// 		protected override async ETTask Run(Unit unit, C2M_AddQuestProgress request, M2C_AddQuestProgress response)
// 		{
// 			await ETTask.CompletedTask;
// 			var actionType = (QuestType)request.QuestType;
// 			switch (actionType)
// 			{
// 				case QuestType.EasterEggHero:
// 					{
// 						if (request.Param.Count == 0) return;
// 						QuestHelper.Run(unit, actionType,
// 							new EasterEggHero() { HeroId = request.Param[0], Count = 1 }, true);
// 						break;
// 					}
// 				case QuestType.EasterEggHeroAnimation:
// 					{
// 						// Gx_#erha_bug，策划配表问题导致的。等策划配表正确后删掉这一批(全局搜 Gx_#erha_bug)打印。
// 						//if (request.Param.Count == 0)
// 						//{
// 						//	Log.Warning($"二哈彩蛋_ 零！");
// 						//}
// 						//else
// 						//{
// 						//	Log.Warning($"二哈彩蛋_ 清君侧 ！ {request.Param[0]}");
// 						//}
//
//
// 						if (request.Param.Count == 0) return;
// 						QuestHelper.Run(unit, actionType,
// 							new EasterEggHeroAnimation() { HeroId = request.Param[0], Count = 1 }, true);
// 						break;
// 					}
// 				case QuestType.EasterEggUI:
// 					{
// 						if (request.Param.Count == 0) return;
// 						QuestHelper.Run(unit, actionType,
// 							new EasterEggUI() { UIConstId = request.Param[0], Count = 1 }, true);
// 						break;
// 					}
// 				case QuestType.ShareGameTimes:
// 				case QuestType.SkillIconClick:
// 					{
// 						QuestHelper.Run(unit, actionType, 1, true);
// 						break;
// 					}
// 				case QuestType.SkillIconClickNoRepeat:
// 					{
// 						if (request.Param.Count < 2) return;
// 						QuestHelper.Run(unit, actionType,
// 							new SkillIconClickNoRepeat()
// 							{
// 								HeroId = request.Param[0], SkillIndex = request.Param[1], Count = 1
// 							}, true);
// 						break;
// 					}
// 				case QuestType.SkillIconClickOneHero:
// 					{
// 						if (request.Param.Count < 2) return;
// 						QuestHelper.Run(unit, actionType,
// 							new SkillIconClickOneHero()
// 							{
// 								HeroId = request.Param[0], SkillIndex = request.Param[1], Count = 1
// 							}, true);
// 						break;
// 					}
// 				case QuestType.SkillView:
// 					{
// 						if (request.Param.Count < 2) return;
// 						QuestHelper.Run(unit, actionType, new SkillView() { Value = request.Param[0] }, true);
// 						return;
// 					}
// 				case QuestType.SkillViewNoRepeat:
// 					{
// 						if (request.Param.Count < 3) return;
// 						QuestHelper.Run(unit, actionType,
// 							new SkillViewNoRepeat()
// 							{
// 								HeroId = request.Param[0],
// 								Count = 1,
// 								SkillIndex = request.Param[1],
// 								Time = request.Param[2]
// 							}, true);
// 						break;
// 					}
// 				case QuestType.SkillViewOneHero:
// 					{
// 						if (request.Param.Count < 3) return;
// 						QuestHelper.Run(unit, actionType,
// 							new SkillViewOneHero()
// 							{
// 								HeroId = request.Param[0],
// 								Count = 1,
// 								SkillIndex = request.Param[1],
// 								Time = request.Param[2]
// 							}, true);
// 						break;
// 					}
// 				case QuestType.TeamRecommendWatchVideo:
// 					{
// 						if (request.Param.Count < 1) return;
// 						{
// 							QuestHelper.Run(unit, actionType, new TeamRecommendWatchVideo() { RecTroopId = request.Param[0] }, true);
// 						}
// 						break;
// 					}
// 				case QuestType.OpenDiscord:
// 					{
// 						QuestHelper.Run(unit, actionType, 1, true);
// 						break;
// 					}
// 				case QuestType.JoinSocialGroup:
// 					{
// 						QuestHelper.Run(unit, actionType, 1, true);
// 						break;
// 					}
// 				// case QuestType.WatchAd:
// 				// 	{
// 				// 		QuestHelper.Run(unit, actionType, 1, true);
// 				// 		break;
// 				// 	}
// 				case QuestType.OpenNatureActivity:
// 					{
// 						QuestHelper.Run(unit, actionType, 1, true);
// 						break;
// 					}
// 				case QuestType.SendFriendRequests:
// 					{
// 						QuestHelper.Run(unit, actionType, request.Param[0], true);
// 						break;
// 					}
// 				case QuestType.AnimalBattleJoinOnce:
// 					{
// 						QuestHelper.Run(unit, actionType, request.Param[0], true);
// 						break;
// 					}
// 				case QuestType.AdventureHitMonster:
// 					{
// 						QuestHelper.Run(unit, actionType, request.Param[0], true);
// 						break;
// 					}
// 			}
// 		}
// 	}
// }