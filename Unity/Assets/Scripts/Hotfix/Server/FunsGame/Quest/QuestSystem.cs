// using System;
// using System.Collections.Generic;
// using ET.EventType;
//
// namespace ET.Server
// {
// 	[FriendOf(typeof(Quest))]
// 	public static class QuestSystem
// 	{
// 		/// <summary>
// 		/// 添加任务进度
// 		/// </summary>
// 		/// <param name="self">Quest</param>
// 		/// <param name="progress">添加的进度</param>
// 		public static void AddProgress(this Quest self, long progress)
// 		{
// 			SetProgress(self, self.QuestProgress + progress);
// 		}
//
// 		/// <summary>
// 		/// 设置任务进度
// 		/// </summary>
// 		/// <param name="self">Quest</param>
// 		/// <param name="progress">设置的进度</param>
// 		public static void SetProgress(this Quest self, long progress)
// 		{
// 			// 如果任务已经做完了，就不更新了
// 			if (self.IsCompleted()) return;
//
// 			self.QuestProgress = progress;
// 			TryCompleteQuest(self);
// 		}
//
// 		/// <summary>
// 		/// 完成任务
// 		/// </summary>
// 		public static void Complete(this Quest self)
// 		{
// 			long requireNum = self.GetRequireNum();
// 			if (requireNum < self.QuestProgress)
// 			{
// 				requireNum = self.QuestProgress;
// 			}
//
// 			self.QuestProgress = requireNum;
// 			if (self.QuestState == QuestState.Completed)
// 			{
// 				return;
// 			}
//
// 			self.QuestState = QuestState.Completed;
// 			var unit = self.GetParent<QuestsComponent>().GetParent<Unit>();
// 			var scene = self.DomainScene();
// 			EventSystem.Instance.Publish(scene, new QuestCompleted() { Unit = unit, Quest = self });
// 			EventSystem.Instance.Publish(scene, new QuestCheckNext() { Unit = unit, Quest = self });
// 		}
//
// 		/// <summary>
// 		/// 尝试完成某个任务、如果是多轮任务，可领取多次
// 		/// </summary>
// 		public static bool TryCompleteQuest(this Quest self)
// 		{
// 			if (!self.IsCompleted() || self.IsClaimed())
// 			{
// 				return false;
// 			}
//
// 			self.Complete();
// 			return true;
// 		}
//
// 		/// <summary>
// 		/// 获取奖励
// 		/// </summary>
// 		public static bool TryGetQuestAward(this Quest self, Unit unit, out List<ItemInfo> itemInfos,
// 			out Dictionary<QuestCategory, int> liveness)
// 		{
// 			itemInfos = new List<ItemInfo>();
// 			liveness = new Dictionary<QuestCategory, int>();
// 			var questConfig = self.Config;
// 			int round = 0;
// 			if (questConfig.MultiRound.Count > 0)
// 			{
// 				// 任务有很多轮的话，一次领完
// 				while (self.CanClaim())
// 				{
// 					round++;
// 					itemInfos.AddRange(questConfig.Reward.ToItemInfos());
// 					if (questConfig.Liveness > 0)
// 					{
// 						liveness.TryAdd(questConfig.Category, 0);
// 						liveness[questConfig.Category] += questConfig.Liveness;
// 					}
//
// 					self.RoundIndex++;
// 					if (self.RoundIndex > Quest.MaxRound)
// 					{
// 						throw new StackOverflowException(
// 							$"Error in claiming rewards for multi-round quests.QuestId:{self.Id}");
// 					}
// 				}
// 			}
// 			else
// 			{
// 				// 普通任务
// 				if (self.CanClaim())
// 				{
// 					round = 1;
// 					itemInfos.AddRange(questConfig.Reward.ToItemInfos());
// 					if (questConfig.Liveness > 0)
// 					{
// 						liveness.TryAdd(questConfig.Category, 0);
// 						liveness[questConfig.Category] += questConfig.Liveness;
// 					}
// 				}
// 			}
//
// 			if (self.IsCompleted())
// 			{
// 				self.QuestState = QuestState.Claimed;
// 			}
//
// 			bool award = itemInfos.Count > 0 || liveness.Count > 0;
// 			if (award)
// 			{
// 				if (questConfig.Category == QuestCategory.GuildBoss ||
// 				    questConfig.Category == QuestCategory.GuildChallenge || 
// 				    questConfig.Category == QuestCategory.GuildDaily)
// 				{
// 					foreach (var itemInfo in itemInfos)
// 					{
// 						if (itemInfo.ItemConfigId == (int)CoinType.GuildCoin)
// 						{
// 							itemInfo.ItemCount += (int)(itemInfo.ItemCount * unit.GetGuildEquityMemberCoin() / 100f);
// 						}
// 					}
// 				}
//
// 				BagHelper.Give(unit, itemInfos, LogModule.Quest);
// 				EventSystem.Instance.Publish(self.DomainScene(),
// 					new QuestClaimed() { Unit = unit, Quest = self, Round = round });
// 			}
//
// 			return award;
// 		}
// 		
//
// 		/// <summary>
// 		/// 获取帮派成员资金权益
// 		/// </summary>
// 		/// <returns>增加的收益百分点</returns>
// 		private static int GetGuildEquityMemberCoin(this Unit unit)
// 		{
// 			var roleInfo = unit.GetComponent<RoleInfo>();
// 			int value = 0;
// 			if (roleInfo.GuildId > 0)
// 			{
// 				var guildConfigs = GUILD_INFO_TABLE.Instance.DataList;
// 				foreach (var config in guildConfigs)
// 				{
// 					if (roleInfo.GuildLv >= config.Level && config.EquityType == GuildEquityType.MemberCoin)
// 					{
// 						if (int.TryParse(config.EquityArgs, out int tempValue))
// 						{
// 							value += tempValue;
// 						}
// 					}
// 				}
// 			}
//
// 			return value;
// 		}
// 	}
// }