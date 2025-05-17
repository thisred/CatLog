// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// namespace ET.Server
// {
// 	[FriendOfAttribute(typeof(ET.QuestsComponent))]
// 	public static class QuestRefreshHelper
// 	{
// 		/// <summary>
// 		/// 根据任务类别刷新
// 		/// </summary>
// 		public static List<Quest> RefreshQuestByCategory(this QuestsComponent self, QuestCategory category,
// 			object categoryParam = null)
// 		{
// 			var quests = new List<Quest>();
// 			switch (category)
// 			{
// 				case QuestCategory.Mainline:
// 					quests.AddRange(RefreshMainlineQuest(self));
// 					break;
// 				case QuestCategory.Daily:
// 				case QuestCategory.Weekly:
// 					quests.AddRange(RefreshDailyOrWeeklyQuest(self, category));
// 					break;
// 				case QuestCategory.JunglePrestige:
// 					quests.AddRange(RefreshJunglePrestigeQuest(self, categoryParam));
// 					break;
// 				case QuestCategory.ArenaRankWeekly:
// 				case QuestCategory.Egypt:
// 				case QuestCategory.EgyptChapter:
// 				case QuestCategory.EgyptActivity:
// 				case QuestCategory.HeroTrial:
// 				case QuestCategory.ExploreGeoCenter:
// 					{
// 						self.RemoveByCategory(category);
// 						quests.AddRange(RefreshNormalQuest(self, category));
// 						break;
// 					}
// 				case QuestCategory.Game2048:
// 				case QuestCategory.Game2048Daily:
// 				case QuestCategory.GameSlotMachine:
// 				case QuestCategory.GameSlotMachineDaily:
// 				case QuestCategory.NoviceTarget:
// 				case QuestCategory.FruitFrenzy:
// 				case QuestCategory.HeroCultivateTarget:
// 				case QuestCategory.FruitCultivateTarget:
// 				case QuestCategory.HeroEquipCultivateTarget:
// 				case QuestCategory.GemCultivateTarget:
// 				case QuestCategory.FollowerSys:
// 				case QuestCategory.FollowerSysSub:
// 				case QuestCategory.GameTheWall:
// 				case QuestCategory.HeroThemeEvent:
// 					{
// 						self.RemoveByCategory(category, categoryParam);
// 						quests.AddRange(RefreshNormalQuest(self, category, categoryParam));
// 						break;
// 					}
// 				case QuestCategory.Home:
// 					{
// 						quests.AddRange(RefreshDailyOrWeeklyQuest(self, category));
// 						break;
// 					}
// 				case QuestCategory.GuildDaily:
// 					{
// 						quests.AddRange(RefreshGuildDailyQuest(self));
// 						break;
// 					}
// 				case QuestCategory.GuildChallenge:
// 					{
// 						quests.AddRange(RefreshGuildChallengeQuest(self));
// 						break;
// 					}
// 				case QuestCategory.GuildBoss:
// 					{
// 						quests.AddRange(RefreshGuildBossQuest(self));
// 						break;
// 					}
// 				case QuestCategory.Tree:
// 				case QuestCategory.Achievement:
// 				case QuestCategory.Collection:
// 				case QuestCategory.None:
// 				case QuestCategory.AvatarFrame:
// 				case QuestCategory.WeeklyActivity:
// 				default:
// 					throw new ArgumentOutOfRangeException(nameof(category), category, null);
// 			}
//
// 			return quests;
// 		}
//
// 		/// <summary>
// 		/// 刷新每日或每周任务
// 		/// </summary>
// 		/// <param name="self"></param>
// 		/// <param name="category"></param>
// 		/// <returns></returns>
// 		private static List<Quest> RefreshDailyOrWeeklyQuest(QuestsComponent self, QuestCategory category)
// 		{
// 			var unit = self.GetParent<Unit>();
// 			var quests = new List<Quest>();
// 			// var conditionCom = unit.GetComponent<CommonConditionComponent>();
// 			// self.RemoveByCategory(category);
// 			// int plan = 0;
// 			// switch (category)
// 			// {
// 			// 	case QuestCategory.Daily:
// 			// 		plan = QUEST_CONST_Table.Instance.PlanDaily;
// 			// 		break;
// 			// 	case QuestCategory.Weekly:
// 			// 		plan = QUEST_CONST_Table.Instance.PlanWeekly;
// 			// 		break;
// 			// 	case QuestCategory.Home:
// 			// 		plan = QUEST_CONST_Table.Instance.PlanHome;
// 			// 		break;
// 			// }
// 			//
// 			// var questPlan = QUEST_PLAN_Table.Instance.Get(plan, category);
// 			// if (questPlan == null)
// 			// {
// 			// 	return quests;
// 			// }
// 			//
// 			// var list = questPlan.QuestIds.Select(questId => QUEST_Table.Instance.GetOrDefault(questId)).ToList();
// 			// list.RemoveAll(x => x == null || x.Conditions.Any(condition => !conditionCom.IsFinish(condition)));
// 			// var range = RandomGenerator.RandomListWithCount(list, QUEST_CONST_Table.Instance.MaxQuestCount);
// 			// foreach (var config in range)
// 			// {
// 			// 	var quest = self.GetOrAddQuest(config.Id);
// 			// 	quests.Add(quest);
// 			// }
//
// 			return quests;
// 		}
//
// 		/// <summary>
// 		/// 刷新周活跃度
// 		/// </summary>
// 		public static void RefreshWeeklyLiveness(this QuestsComponent self)
// 		{
// 			// self.ClearLivenessClaimedIds(QuestCategory.Weekly);
// 			// NumericHelper.SetWithSyncClient(self.GetParent<Unit>(), (int)CoinType.LivenessWeekly, 0);
// 		}
//
// 		/// <summary>
// 		/// 刷新日常活跃度
// 		/// </summary>
// 		public static void RefreshDailyLiveness(this QuestsComponent self)
// 		{
// 			// self.ClearLivenessClaimedIds(QuestCategory.Daily);
// 			// NumericHelper.SetWithSyncClient(self.GetParent<Unit>(), (int)CoinType.LivenessDaily, 0);
// 		}
//
// 		/// <summary>
// 		/// 刷新主线任务
// 		/// </summary>
// 		private static List<Quest> RefreshMainlineQuest(this QuestsComponent self)
// 		{
// 			var quests = new List<Quest>();
// 			// var unit = self.GetParent<Unit>();
// 			// long playerLevel = unit.GetComponent<NumericComponent>()[NumericType.Level];
// 			// foreach (var questCfg in QUEST_Table.Instance.GetByCategory(QuestCategory.Mainline))
// 			// {
// 			// 	int configId = questCfg.Id;
// 			// 	var quest = self.GetQuest(configId);
// 			// 	if (quest != null)
// 			// 	{
// 			// 		continue;
// 			// 	}
// 			//
// 			// 	if (!questCfg.AutoAdd)
// 			// 	{
// 			// 		continue;
// 			// 	}
// 			//
// 			// 	if (playerLevel < questCfg.PlayerLvLimit)
// 			// 	{
// 			// 		// 需要大于指定等级
// 			// 		continue;
// 			// 	}
// 			//
// 			// 	if (questCfg.PreIds.Count > 0)
// 			// 	{
// 			// 		bool isCan = true;
// 			// 		foreach (int preId in questCfg.PreIds)
// 			// 		{
// 			// 			var questBefore = self.GetQuest(preId);
// 			// 			if (questBefore != null && questBefore.CanClaim())
// 			// 			{
// 			// 				continue;
// 			// 			}
// 			//
// 			// 			// 需要完成前置任务
// 			// 			isCan = false;
// 			// 			break;
// 			// 		}
// 			//
// 			// 		if (isCan)
// 			// 		{
// 			// 			// 存在前置任务未完成
// 			// 			continue;
// 			// 		}
// 			// 	}
// 			//
// 			// 	quests.Add(self.GetOrAddQuest(configId));
// 			// }
//
// 			return quests;
// 		}
//
// 		/// <summary>
// 		/// 刷新丛林声望任务
// 		/// </summary>
// 		/// <param name="self"></param>
// 		/// <param name="categoryParam">当前开服天数</param>
// 		/// <returns></returns>
// 		private static List<Quest> RefreshJunglePrestigeQuest(QuestsComponent self, object categoryParam)
// 		{
// 			var quests = new List<Quest>();
// 			// if (categoryParam is not int day)
// 			// {
// 			// 	return quests;
// 			// }
// 			//
// 			// var unit = self.GetParent<Unit>();
// 			// var conditionCom = unit.GetComponent<CommonConditionComponent>();
// 			// self.RemoveByCategory(QuestCategory.JunglePrestige);
// 			// var taskCfg = JUNGLE_PRESTIGE_TASK_Table.Instance.GetTasks(day);
// 			// if (taskCfg == null)
// 			// {
// 			// 	return quests;
// 			// }
// 			//
// 			// var list = taskCfg.Tasks.Select(questId => QUEST_Table.Instance.GetOrDefault(questId)).ToList();
// 			// list.RemoveAll(x => x == null || x.Conditions.Any(condition => !conditionCom.IsFinish(condition)));
// 			// foreach (var config in list)
// 			// {
// 			// 	var quest = self.GetOrAddQuest(config.Id);
// 			// 	quests.Add(quest);
// 			// }
//
// 			return quests;
// 		}
//
// 		/// <summary>
// 		/// 刷新任务
// 		/// </summary>
// 		private static List<Quest> RefreshNormalQuest(this QuestsComponent self, QuestCategory category,
// 			object categoryParam = null)
// 		{
// 			var quests = new List<Quest>();
// 			// var questsByType = QUEST_Table.Instance.GetByCategory(category);
// 			// var unit = self.GetParent<Unit>();
// 			// var conditionCom = unit.GetComponent<CommonConditionComponent>();
// 			// foreach (var questCfg in questsByType)
// 			// {
// 			// 	int configId = questCfg.Id;
// 			// 	var quest = self.GetQuest(configId);
// 			// 	if (quest != null) continue;
// 			//
// 			// 	if (!questCfg.AutoAdd) continue;
// 			// 	if (!questCfg.SatisfiedByCategoryParam(categoryParam)) continue;
// 			//
// 			// 	bool flag = questCfg.Conditions.Any(condition => !conditionCom.IsFinish(condition));
// 			// 	if (flag)
// 			// 	{
// 			// 		continue;
// 			// 	}
// 			//
// 			// 	if (questCfg.PreIds.Count > 0)
// 			// 	{
// 			// 		flag = true;
// 			// 		foreach (int preId in questCfg.PreIds)
// 			// 		{
// 			// 			var questBefore = self.GetQuest(preId);
// 			// 			if (questBefore != null && questBefore.CanClaim())
// 			// 			{
// 			// 				continue;
// 			// 			}
// 			//
// 			// 			// 需要完成前置任务
// 			// 			flag = false;
// 			// 			break;
// 			// 		}
// 			//
// 			// 		if (flag)
// 			// 		{
// 			// 			// 存在前置任务未完成
// 			// 			continue;
// 			// 		}
// 			// 	}
// 			//
// 			// 	quests.Add(self.GetOrAddQuest(configId));
// 			// }
//
// 			return quests;
// 		}
//
// 		/// <summary>
// 		/// 刷新公会挑战任务
// 		/// </summary>
// 		/// <param name="self"></param>
// 		/// <returns></returns>
// 		public static List<Quest> RefreshGuildChallengeQuest(this QuestsComponent self)
// 		{
// 			// self.RemoveByCategory(QuestCategory.GuildChallenge);
// 			// var unit = self.GetParent<Unit>();
// 			// int weeksSinceServerOpen = unit.GetWeeksSinceServerOpen(); // 开服周数
// 			// if (weeksSinceServerOpen < 0)
// 			// {
// 			// 	weeksSinceServerOpen = 1;
// 			// }
// 			//
// 			// int weekCount = GUILD_CHALLENGE_QUEST_TABLE.Instance.GetWeekCount(); // 配置共n周
// 			// int week = (weeksSinceServerOpen - 1) % weekCount + 1; // 超过配置周数后，进行轮换
// 			// var dayOfWeek = TimeUtils.GetDayOfWeek();
// 			// int day = dayOfWeek == 0 ? 7 : (int)dayOfWeek; // 一周7天
// 			// var guildChallengeQuests = GUILD_CHALLENGE_QUEST_TABLE.Instance.DataListByWeek(week);
// 			// var challengeQuests = guildChallengeQuests
// 			// 	.Where(challengeQuest => challengeQuest.Day == day).ToList();
// 			//
// 			// var questIds = challengeQuests.Select(t => t.Quest).ToList();
// 			// return AddQuests(self, questIds);
// 			return default;
// 		}
//
// 		/// <summary>
// 		/// 刷新公会每日任务
// 		/// </summary>
// 		/// <param name="self"></param>
// 		/// <returns></returns>
// 		public static List<Quest> RefreshGuildDailyQuest(this QuestsComponent self)
// 		{
// 			return default;
//
// 			// self.RemoveByCategory(QuestCategory.GuildDaily);
// 			// var unit = self.GetParent<Unit>();
// 			// int daysSinceServerOpen = unit.GetDaysSinceServerOpen(); // 开服天数
// 			// if (daysSinceServerOpen < 0)
// 			// {
// 			// 	daysSinceServerOpen = 0;
// 			// }
// 			//
// 			// int dayCount = GUILD_DAILY_QUEST_TABLE.Instance.GetDayCount(); // 配置共n天
// 			// int day = daysSinceServerOpen % dayCount + 1; // 超过配置天数后，进行轮换
// 			// var dataListByDay = GUILD_DAILY_QUEST_TABLE.Instance.DataListByDay(day);
// 			// var questIds = dataListByDay.Select(t => t.Quest).ToList();
// 			//
// 			// return AddQuests(self, questIds);
// 		}
// 		
// 		
// 		/// <summary>
// 		/// 刷新帮派Boss任务
// 		/// </summary>
// 		/// <param name="self"></param>
// 		/// <returns></returns>
// 		public static List<Quest> RefreshGuildBossQuest(this QuestsComponent self)
// 		{
// 			// self.RemoveByCategory(QuestCategory.GuildBoss);
// 			// var unit = self.GetParent<Unit>();
// 			// int weeksSinceServerOpen = unit.GetWeeksSinceServerOpen(); // 开服周数
// 			// if (weeksSinceServerOpen < 0)
// 			// {
// 			// 	weeksSinceServerOpen = 1;
// 			// }
// 			//
// 			// int weekCount = GUILD_BOSS_QUEST_TABLE.Instance.GetWeekCount(); // 配置共n周
// 			// int week = (weeksSinceServerOpen - 1) % weekCount + 1; // 超过配置周数后，进行轮换
// 			// var dayOfWeek = TimeUtils.GetDayOfWeek();
// 			// int day = dayOfWeek == 0 ? 7 : (int)dayOfWeek; // 一周7天
// 			// var guildChallengeQuests = GUILD_BOSS_QUEST_TABLE.Instance.DataListByWeek(week);
// 			// var challengeQuests = guildChallengeQuests
// 			// 	.Where(challengeQuest => challengeQuest.Day == day).ToList();
// 			//
// 			// var questIds = challengeQuests.Select(t => t.Quest).ToList();
// 			// return AddQuests(self, questIds);
// 			return default;
//
// 		}
//
// 		private static List<Quest> AddQuests(this QuestsComponent self, List<int> questIds)
// 		{
// 			// var quests = new List<Quest>();
// 			// var unit = self.GetParent<Unit>();
// 			// long playerLevel = unit.GetComponent<NumericComponent>()[NumericType.Level];
// 			// foreach (int questId in questIds)
// 			// {
// 			// 	var questCfg = QUEST_Table.Instance.Get(questId);
// 			// 	int configId = questCfg.Id;
// 			// 	var quest = self.GetQuest(configId);
// 			// 	if (quest != null)
// 			// 	{
// 			// 		continue;
// 			// 	}
// 			//
// 			// 	if (playerLevel < questCfg.PlayerLvLimit)
// 			// 	{
// 			// 		// 需要大于指定等级
// 			// 		continue;
// 			// 	}
// 			//
// 			// 	if (questCfg.PreIds.Count > 0)
// 			// 	{
// 			// 		bool isCan = true;
// 			// 		foreach (int preId in questCfg.PreIds)
// 			// 		{
// 			// 			var questBefore = self.GetQuest(preId);
// 			// 			if (questBefore != null && questBefore.CanClaim())
// 			// 			{
// 			// 				continue;
// 			// 			}
// 			//
// 			// 			// 需要完成前置任务
// 			// 			isCan = false;
// 			// 			break;
// 			// 		}
// 			//
// 			// 		if (isCan)
// 			// 		{
// 			// 			// 存在前置任务未完成
// 			// 			continue;
// 			// 		}
// 			// 	}
// 			//
// 			// 	quests.Add(self.GetOrAddQuest(configId));
// 			// }
// 			//
// 			// return quests;
// 			return default;
//
// 		}
// 	}
// }