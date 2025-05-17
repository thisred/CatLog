// using System.Collections.Generic;
// using System.Linq;
//
// namespace ET.Server
// {
// 	public static partial class QuestHelper
// 	{
// 		public static void GetOrAddQuest(Unit unit, int configId, bool sync = true)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			var quest = questsComponent.GetOrAddQuest(configId);
// 			if (sync)
// 			{
// 				QuestNoticeHelper.SyncQuest(unit, quest, QuestOp.AddOrUpdate);
// 			}
// 		}
//
// 		public static QuestState GetQuestState(Unit unit, int configId)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			var quest = questsComponent.GetQuest(configId);
// 			if (quest != null)
// 			{
// 				if (quest.QuestState != QuestState.Completed && quest.CanClaim())
// 				{
// 					quest.QuestState = QuestState.Completed;
// 					CompleteQuest(unit, configId);
// 				}
//
// 				return quest.QuestState;
// 			}
//
// 			return QuestState.NotStart;
// 		}
//
// 		/// <summary>
// 		/// 直接完成任务
// 		/// </summary>
// 		public static void CompleteQuest(Unit unit, int configId, bool sync = true)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			var quest = questsComponent.GetOrAddQuest(configId);
// 			quest.Complete();
// 			if (sync)
// 			{
// 				QuestNoticeHelper.SyncQuest(unit, quest, QuestOp.AddOrUpdate);
// 			}
// 		}
//
// 		/// <summary>
// 		/// 根据任务类别快速领取任务奖励
// 		/// </summary>
// 		public static int QuickClaimByCategory(Unit unit, List<QuestCategory> categorylist, List<int> categoryIntParams,
// 			out List<ItemInfo> rewards)
// 		{
// 			rewards = new List<ItemInfo>();
// 			var quests = new List<Quest>();
// 			var dictionary = new Dictionary<QuestCategory, int>();
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			for (int i = 0; i < categorylist.Count; i++)
// 			{
// 				var item = categorylist[i];
//
// 				List<Quest> questList;
// 				if (categoryIntParams != null && categoryIntParams.Count > i)
// 				{
// 					int param = categoryIntParams[i];
// 					questList = questsComponent.GetByCategory(item, categoryParam: param);
// 				}
// 				else
// 				{
// 					questList = questsComponent.GetByCategory(item);
// 				}
//
// 				foreach (var quest in questList)
// 				{
// 					if (quest.TryGetQuestAward(unit, out var itemInfos, out var liveness))
// 					{
// 						rewards.AddRange(itemInfos);
// 						quests.Add(quest);
// 						if (quest.IsClaimed())
// 						{
// 							quests.AddRange(questsComponent.CheckNextQuest(quest));
// 						}
//
// 						foreach ((var key, int value) in liveness)
// 						{
// 							if (!dictionary.TryAdd(key, value))
// 							{
// 								dictionary[key] += value;
// 							}
// 						}
// 					}
// 				}
// 			}
//
// 			//将积分的变动同步到客户端
// 			QuestNoticeHelper.SyncQuestLiveness(unit, dictionary);
//
// 			QuestNoticeHelper.SyncQuest(unit, quests);
// 			return ErrorCode.Success;
// 		}
//
// 		/// <summary>
// 		/// 快速获取活跃度奖励
// 		/// </summary>
// 		public static void GetLivenessReward(Unit unit, QuestCategory category, int param, out List<ItemInfo> rewards)
// 		{
// 			rewards = new List<ItemInfo>();
// 			var component = unit.GetComponent<QuestsComponent>();
// 			// var list = LIVENESS_Table.Instance.DataListByCategory(category, param);
// 			// if (list == null)
// 			// {
// 			// 	return;
// 			// }
// 			//
// 			// long liveness = ET.QuestHelper.GetQuestLiveness(unit, category);
// 			// foreach (var config in list)
// 			// {
// 			// 	if (liveness < config.Liveness)
// 			// 		continue;
// 			// 	if (component.IsClaimed(config))
// 			// 		continue;
// 			// 	component.Claim(config);
// 			// 	foreach (var award in config.Awards)
// 			// 	{
// 			// 		if (!BagHelper.Give(unit, award.ItemId, award.Num, LogModule.Quest))
// 			// 			return;
// 			// 		rewards.Add(new ItemInfo { ItemConfigId = award.ItemId, ItemCount = award.Num });
// 			// 	}
// 			// }
//
// 			QuestNoticeHelper.SyncQuestLivenessBox(unit);
// 		}
//
// 		/// <summary>
// 		/// 快速领取每日或者每周任务奖励
// 		/// </summary>
// 		public static int QuickGet(Unit unit, QuestCategory category, out List<ItemInfo> rewards)
// 		{
// 			rewards = new List<ItemInfo>();
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			var currentQuests = questsComponent.GetByCategory(category);
// 			var quests = new List<Quest>();
// 			var dictionary = new Dictionary<QuestCategory, int>();
// 			foreach (var quest in currentQuests)
// 			{
// 				if (!quest.TryGetQuestAward(unit, out var itemInfos, out var liveness))
// 				{
// 					continue;
// 				}
//
// 				foreach ((var key, int value) in liveness)
// 				{
// 					if (!dictionary.TryAdd(key, value))
// 					{
// 						dictionary[key] += value;
// 					}
// 				}
//
// 				rewards.AddRange(itemInfos);
// 				quests.Add(quest);
// 			}
//
// 			//将积分的变动同步到客户端
// 			QuestNoticeHelper.SyncQuestLiveness(unit, dictionary);
// 			QuestNoticeHelper.SyncQuest(unit, quests);
// 			return ErrorCode.Success;
// 		}
//
// 		/// <summary>
// 		/// 玩家上线，根据最后一次刷新时间去刷新每日任务每周任务主线任务
// 		/// </summary>
// 		public static void OnLogin(Unit unit)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			// 先去掉不存在的配置
// 			questsComponent.RemoveNotInConfig();
// 			// 刷新每日和每周任务
// 			TryRefreshQuest(unit);
// 			// 策划可能改配置，重新刷新一遍所有不带参数的任务
// 			// UpdateNoParam(unit).Coroutine();
// 		}
//
// 		private static List<Quest> RefreshDaily(Unit unit)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			questsComponent.RemoveNotInConfig(); // 删除不存在的配置
// 			questsComponent.RefreshDailyLiveness(); // 刷新日常活跃度
//
// 			var quests = new List<Quest>();
// 			quests.AddRange(questsComponent.RefreshQuestByCategory(QuestCategory.Daily));
//
// 			var roleInfo = unit.GetComponent<RoleInfo>();
// 			// if (roleInfo.GuildId > 0)
// 			// {
// 			// 	// 检查是否存在奖励未领取，如果有则发邮件。
// 			// 	var guildQuests = questsComponent.GetByCategory(QuestCategory.GuildDaily);
// 			// 	guildQuests.AddRange(questsComponent.GetByCategory(QuestCategory.GuildChallenge));
// 			// 	guildQuests.AddRange(questsComponent.GetByCategory(QuestCategory.GuildBoss));
// 			// 	var itemInfos = new List<ItemInfo>(); // 补发奖励
// 			// 	foreach (var guildQuest in guildQuests.Where(guildQuest => guildQuest.CanClaim()))
// 			// 	{
// 			// 		itemInfos.AddRange(guildQuest.Config.Reward.ToItemInfos());
// 			// 	}
// 			//
// 			// 	if (itemInfos.Count > 0)
// 			// 	{
// 			// 		var mailMessage = new MailMessage() { ConfigId = GUILD_CONST_TABLE.Instance.GuildRewardMailId };
// 			// 		mailMessage.Items.AddRange(itemInfos);
// 			// 		mailMessage.SetRecipient(unit.Id);
// 			// 		MailSenderHelper.SendMail(unit.DomainScene(), mailMessage); // 补发奖励邮件
// 			// 	}
// 			// }
// 			quests.AddRange(questsComponent.RefreshQuestByCategory(QuestCategory.GuildBoss)); // 公会挑战任务
// 			quests.AddRange(questsComponent.RefreshQuestByCategory(QuestCategory.GuildDaily)); // 公会每日任务
// 			quests.AddRange(questsComponent.RefreshQuestByCategory(QuestCategory.GuildChallenge)); // 公会挑战任务
//
// 			quests.AddRange(RefreshDailyCasualGames(unit)); //老虎机+2048
//
// 			return quests;
// 		}
//
// 		private static List<Quest> RefreshDailyCasualGames(Unit unit)
// 		{
// 			var quests = new List<Quest>();
// 			// var com2048 = unit.GetComponent<Game2048Component>();
// 			// var questsComponent = unit.GetComponent<QuestsComponent>();
// 			// foreach (var (themeId, _) in com2048.ThemeDatas)
// 			// {
// 			// 	quests.AddRange(questsComponent.RefreshQuestByCategory(QuestCategory.Game2048Daily, themeId));
// 			// }
// 			//
// 			// var comSlot = unit.GetComponent<SlotMachineComponent>();
// 			// foreach (var (themeId, _) in comSlot.ThemeDatas)
// 			// {
// 			// 	quests.AddRange(questsComponent.RefreshQuestByCategory(QuestCategory.GameSlotMachineDaily, themeId));
// 			// }
//
// 			return quests;
// 		}
//
// 		private static List<Quest> RefreshWeekly(Unit unit)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			questsComponent.RefreshWeeklyLiveness(); // 刷新周活跃度
// 			var quests = new List<Quest>();
// 			quests.AddRange(questsComponent.RefreshQuestByCategory(QuestCategory.Weekly));
// 			return quests;
// 		}
//
// 		private static List<Quest> RefreshArenaWeekly(Unit unit)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			var quests = new List<Quest>();
// 			quests.AddRange(questsComponent.RefreshQuestByCategory(QuestCategory.ArenaRankWeekly));
// 			return quests;
// 		}
//
//
// 		/// <summary>
// 		/// 玩家在线跨天
// 		/// </summary>
// 		public static void OnDailyRefresh(Unit unit, bool gm)
// 		{
// 			if (gm)
// 			{
// 				var component = unit.GetComponent<QuestsComponent>();
// 			}
//
// 			var quests = TryRefreshQuest(unit);
// 			QuestNoticeHelper.SyncQuest(unit, quests);
// 			QuestNoticeHelper.SyncQuestLivenessBox(unit);
// 		}
//
// 		/// <summary>
// 		/// 刷新每日每周任务和开服任务
// 		/// </summary>
// 		private static List<Quest> TryRefreshQuest(Unit unit)
// 		{
// 			var quests = new List<Quest>();
// 			var component = unit.GetComponent<QuestsComponent>();
// 			// long todayUnixTimestamp = TimeUtils.GetTodayZeroTimestamp();
// 			// if (component.DailyRefreshTime <= todayUnixTimestamp)
// 			// {
// 			// 	// 每日刷新
// 			// 	quests.AddRange(RefreshDaily(unit));
// 			// 	quests.AddRange(component.RefreshQuestByCategory(QuestCategory.Mainline));
// 			// 	quests.AddRange(component.RefreshQuestByCategory(QuestCategory.Home));
// 			//
// 			// 	//刷新丛林声望任务
// 			// 	quests.AddRange(component.RefreshQuestByCategory(QuestCategory.JunglePrestige,
// 			// 		TimeUtils.GetDaysSinceServerOpen(unit.DomainZone())+1));
// 			//
// 			// 	component.DailyRefreshTime = TimeHelper.ServerNow();
// 			// 	Run(unit, QuestType.LoginToday, 1);
// 			// 	Run(unit, QuestType.LoginWeek, 1);
// 			// 	Run(unit, QuestType.LoginTimesDuringEvent, 1);
// 			// }
// 			//
// 			// if (component.WeeklyRefreshTime <= TimeUtils.GetWeekTimestamp())
// 			// {
// 			// 	// 每周刷新
// 			// 	quests.AddRange(RefreshWeekly(unit));
// 			// 	quests.AddRange(RefreshArenaWeekly(unit));
// 			// 	component.WeeklyRefreshTime = TimeHelper.ServerNow();
// 			// }
//
// 			return quests;
// 		}
// 		
// 		public static void RefreshNoviceTargetQuest(Unit unit, bool sync = true,
// 			object categoryParam = null)
// 		{
// 			var quests = unit.GetComponent<QuestsComponent>().RefreshQuestByCategory(QuestCategory.NoviceTarget, categoryParam);
// 			Run(unit, QuestType.LoginToday, 1);
// 			Run(unit, QuestType.LoginWeek, 1);
// 			Run(unit, QuestType.LoginTimesDuringEvent, 1);
// 			if (sync)
// 			{
// 				QuestNoticeHelper.SyncQuest(unit, quests);
// 			}
// 		}
//
// 		public static void RefreshQuestByCategory(Unit unit, QuestCategory category, bool sync = true,
// 			object categoryParam = null)
// 		{
// 			var quests = unit.GetComponent<QuestsComponent>().RefreshQuestByCategory(category, categoryParam);
// 			if (sync)
// 			{
// 				QuestNoticeHelper.SyncQuest(unit, quests);
// 			}
// 		}
//
// 		/// <summary>
// 		/// 重新刷新一遍所有不带参数的任务
// 		/// </summary>
// 		public static async ETTask UpdateNoParamByCategory(Unit unit, QuestCategory category, bool sync = true)
// 		{
// 			var component = unit.GetComponent<QuestsComponent>();
// 			var quests = component.GetByCategory(category).ToList();
// 			foreach (var quest in quests)
// 			{
// 				await QuestHandlerComponent.Instance.Process(component, quest.Config.Type, new QuestNoParam());
// 			}
//
// 			if (sync)
// 			{
// 				QuestNoticeHelper.SyncQuest(unit, quests);
// 			}
// 		}
//
// 		/// <summary>
// 		/// 重新刷新一遍所有不带参数的任务
// 		/// </summary>
// 		public static async ETTask UpdateNoParam(Unit unit)
// 		{
// 			await ETTask.CompletedTask;
// 			var component = unit.GetComponent<QuestsComponent>();
// 			var quests = component.QuestDic.Values.ToList();
// 			foreach (var quest in quests)
// 			{
// 				// await QuestHandlerComponent.Instance.Process(quest, new QuestNoParam());
// 				// if (quest.QuestState == QuestState.Completed && quest.Config.GetAwardsInstantly)
// 				// 	component.TryGetQuestReward(quest.ConfigId, out _);
// 			}
// 		}
//
// 		public static void TryGetQuestReward(Unit unit, int configId, out List<ItemInfo> rewards)
// 		{
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			questsComponent.TryGetQuestReward(configId, out rewards);
// 		}
// 	}
// }