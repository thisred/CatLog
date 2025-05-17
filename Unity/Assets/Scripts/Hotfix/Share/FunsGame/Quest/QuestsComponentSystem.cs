// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// namespace ET
// {
// 	[FriendOf(typeof(QuestsComponent))]
// 	[FriendOf(typeof(WeeklyQuestDataComponent))]
// 	[FriendOf(typeof(Quest))]
// 	public static class QuestsComponentSystem
// 	{
// 		public static Quest GetQuest(this QuestsComponent self, int configId)
// 		{
// 			return self.QuestDic.GetValueOrDefault(configId);
// 		}
//
// 		/// <summary>
// 		/// 获取任务列表
// 		/// </summary>
// 		/// <param name="self"></param>
// 		/// <param name="type">任务类型</param>
// 		/// <param name="comparison">比较器</param>
// 		/// <param name="removeBefore">是否移除已完成的前置任务</param>
// 		/// <returns></returns>
// 		public static List<Quest> GetByCategory(this QuestsComponent self, QuestCategory type,
// 			Comparison<Quest> comparison = null, bool removeBefore = false, object categoryParam = null)
// 		{
// 			var quests = new List<Quest>();
// 			foreach (var quest in self.QuestDic.Values)
// 			{
// 				var questConfig = quest.Config;
// 				if (questConfig == null) continue;
// 				if (questConfig.Category != type) continue;
// 				if (removeBefore && questConfig.NextIds.Count != 0 && quest.IsClaimed()) continue;
// 				if (!questConfig.SatisfiedByCategoryParam(categoryParam)) continue;
// 				quests.Add(quest);
// 			}
//
// 			quests.Sort(comparison ?? QuestSort.NormalComparison);
// 			return quests;
// 		}
//
// 		public static List<Quest> GetByType(this QuestsComponent self, QuestType questType)
// 		{
// 			var quests = new List<Quest>();
// 			foreach (var quest in self.QuestDic.Values)
// 			{
// 				var questConfig = quest.Config;
// 				if (questConfig == null) continue;
// 				if (questConfig.Type != questType) continue;
//
// 				quests.Add(quest);
// 			}
//
// 			return quests;
// 		}
//
// 		/// <summary>
// 		/// 获取当前主线任务
// 		/// </summary>
// 		/// <param name="self"></param>
// 		/// <returns></returns>
// 		public static Quest GetCurrentMain(this QuestsComponent self)
// 		{
// 			var quests = self.GetByCategory(QuestCategory.Mainline, QuestSort.MainLineComparison);
// 			return quests.Count == 0 ? null : quests.FirstOrDefault();
// 		}
//
// 		public static bool TryGetMainQuest(this QuestsComponent self, out Quest quest)
// 		{
// 			quest = null;
// 			var quests = self.GetByCategory(QuestCategory.Mainline, QuestSort.MainLineComparison);
// 			if (quests.Count > 0)
// 			{
// 				quest = quests.FirstOrDefault();
// 				if (quest.IsClaimed())
// 				{
// 					return false;
// 				}
// 			}
//
// 			return quests.Count > 0;
// 		}
//
//
// 		public static bool CheckCanClaim(this QuestsComponent self, LIVENESS liveness, long count)
// 		{
// 			if (count < liveness.Liveness)
// 			{
// 				return false;
// 			}
//
// 			if (!self.ClaimedLiveness.TryGetValue((int)liveness.Category, out var claimedLiveness))
// 			{
// 				return true;
// 			}
//
// 			return !claimedLiveness.Contains(liveness.Id);
// 		}
//
// 		public static bool IsClaimed(this QuestsComponent self, LIVENESS liveness)
// 		{
// 			if (!self.ClaimedLiveness.TryGetValue((int)liveness.Category, out var claimedLiveness))
// 			{
// 				return false;
// 			}
//
// 			return claimedLiveness.Contains(liveness.Id);
// 		}
//
// 		public static bool IsClaimed(this QuestsComponent self, QuestCategory category, int id)
// 		{
// 			if (!self.ClaimedLiveness.TryGetValue((int)category, out var claimedLiveness))
// 			{
// 				return false;
// 			}
//
// 			return claimedLiveness.Contains(id);
// 		}
//
// 		public static void Claim(this QuestsComponent self, LIVENESS liveness)
// 		{
// 			int category = (int)liveness.Category;
// 			if (!self.ClaimedLiveness.ContainsKey(category))
// 			{
// 				self.ClaimedLiveness.Add(category, new HashSet<int>());
// 			}
//
// 			self.ClaimedLiveness[category].Add(liveness.Id);
// 		}
//
// 		public static bool CanClaimByCategory(this QuestsComponent self, QuestCategory category,
// 			object categoryParam = null)
// 		{
// 			bool canClaim = false;
// 			var quests = self.GetByCategory(category, null, false, categoryParam);
// 			if (quests.Any(currentQuest => currentQuest.CanClaim()))
// 			{
// 				canClaim = true;
// 			}
//
// 			return canClaim;
// 		}
//
// 		public static bool CanQuickGetLiveness(this QuestsComponent self, QuestCategory questCategory, out LIVENESS cfg,object paramObject = null)
// 		{
// 			cfg = null;
// 			bool canGet = false;
// 			long count = QuestHelper.GetQuestLiveness(self.GetParent<Unit>(), questCategory);
// 			var dataListByType = LIVENESS_Table.Instance.DataListByCategory(questCategory,paramObject);
// 			foreach (var config in dataListByType)
// 			{
// 				if (count < config.Liveness)
// 					continue;
// 				if (self.IsClaimed(config))
// 					continue;
// 				cfg = config;
// 				canGet = true;
// 			}
//
// 			return canGet;
// 		}
//
// 		public static bool SatisfiedByCategoryParam(this QUEST cfg, object categoryParam)
// 		{
// 			// 任务本身不需要用CategoryParam来区分
// 			if (cfg.CategoryParam.Count == 0) return true;
//
// 			// 需要区分但无参数
// 			if (categoryParam == null) return false;
//
// 			// 如果传入的是true,则忽略参数判断。
// 			if (categoryParam is true)
// 			{
// 				return true;
// 			}
//
// 			// 单int参数
// 			if (categoryParam is int intP && cfg.CategoryParam.Count > 0)
// 			{
// 				return cfg.CategoryParam[0] == intP;
// 			}
//
// 			if (cfg.Category == QuestCategory.NoviceTarget)
// 			{
// 				if (categoryParam is List<int> intListValue && cfg.CategoryParam.Count >= 2)
// 				{
// 					return cfg.CategoryParam[0] == intListValue[0] && cfg.CategoryParam[1] == intListValue[1];
// 				}
//
// 				return false;
// 			}
// 			
// 			if (cfg.Category == QuestCategory.FruitFrenzy)
// 			{
// 				return cfg.CategoryParam.Count > 0;
// 			}
//
// 			// TODO:其他参数类型的情况，需要时追加到此处判定
//
// 			return false;
// 		}
// 	}
// }