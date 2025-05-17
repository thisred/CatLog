// using System;
// using System.Collections.Generic;
// using System.Linq;
// // using ET.EventType;
//
// namespace ET.Server
// {
// 	[FriendOf(typeof(QuestsComponent))]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestsComponentDeserializeSystem : DeserializeSystem<QuestsComponent>
// 	{
// 		protected override void Deserialize(QuestsComponent self)
// 		{
// 			foreach (var quest in self.Children.Values.Cast<Quest>())
// 			{
// 				self.QuestDic[quest.ConfigId] = quest;
// 			}
// 		}
// 	}
//
// 	[FriendOf(typeof(QuestsComponent))]
// 	[FriendOf(typeof(Quest))]
// 	public static partial class QuestsComponentSystem
// 	{
// 		public static Quest GetOrAddQuest(this QuestsComponent self, int configId)
// 		{
// 			if (self.QuestDic.TryGetValue(configId, out var quest))
// 				return quest;
// 			var questConfig = QUEST_Table.Instance.GetOrDefault(configId);
// 			if (questConfig == null)
// 			{
// 				throw new Exception($"Quest not found, id : {configId}");
// 			}
//
// 			quest = self.AddChild<Quest, int>(configId);
// 			quest = (Quest)quest;
// 			quest.QuestState = QuestState.Doing;
// 			self.QuestDic.Add(configId, quest);
//
// 			Init(self, quest).Coroutine();
// 			return quest;
// 		}
//
// 		private static async ETTask Init(this QuestsComponent self, Quest quest)
// 		{
// 			await QuestHandlerComponent.Instance.Init(self, quest);
// 			if (quest.QuestState == QuestState.Completed && quest.Config.GetAwardsInstantly)
// 				TryGetQuestReward(self, quest.ConfigId, out _);
// 		}
//
// 		/// <summary>
// 		/// 删除任务
// 		/// </summary>
// 		public static void Remove(this QuestsComponent self, int configId, bool sync = true)
// 		{
// 			if (!self.QuestDic.Remove(configId, out var quest))
// 			{
// 				return;
// 			}
//
// 			if (sync)
// 			{
// 				var unit = self.GetParent<Unit>();
// 				QuestNoticeHelper.SyncQuest(unit, quest, QuestOp.Delete);
// 			}
//
// 			self.RemoveChild(quest.Id);
// 		}
//
// 		/// <summary>
// 		/// 检查并删除配置里不存在的任务
// 		/// </summary>
// 		public static void RemoveNotInConfig(this QuestsComponent self)
// 		{
// 			foreach (int configId in self.QuestDic.Keys.ToArray())
// 			{
// 				var questConfig = QUEST_Table.Instance.GetOrDefault(configId);
// 				if (questConfig == null)
// 				{
// 					self.Remove(configId);
// 				}
// 			}
// 		}
//
// 		/// <summary>
// 		/// 删除某一类任务
// 		/// </summary>
// 		public static void RemoveByCategory(this QuestsComponent self, QuestCategory type, object categoryParam = null)
// 		{
// 			var questIds = new List<int>();
// 			foreach (var quest in self.QuestDic.Values.ToList())
// 			{
// 				
// 				var questConfig = quest.Config;
// 				if (questConfig == null) continue;
// 				if (questConfig.Category != type) continue;
// 				if (!questConfig.SatisfiedByCategoryParam(categoryParam)) continue;
// 				questIds.Add(quest.ConfigId);
// 				if (quest.CanClaim())
// 				{
// 					quest.TryGetQuestAward(self.GetParent<Unit>(), out _, out _); // 如果任务已经完成，则直接领取奖励
// 				}
// 			}
//
// 			foreach (int configId in questIds)
// 			{
// 				Remove(self, configId);
// 			}
// 		}
//
//
// 		/// <summary>
// 		/// 检查后置任务
// 		/// </summary>
// 		public static List<Quest> CheckNextQuest(this QuestsComponent self, Quest quest)
// 		{
// 			var questConfig = quest.Config;
// 			var quests = new List<Quest>();
// 			if (questConfig.NextIds.Count <= 0)
// 			{
// 				return quests;
// 			}
//
// 			foreach (int nextId in questConfig.NextIds)
// 			{
// 				var nextQuest = self.GetOrAddQuest(nextId);
// 				if (nextQuest.Config.InheritProgress)
// 				{
// 					nextQuest.SetProgress(quest.QuestProgress);
// 				}
//
// 				quests.Add(nextQuest);
// 			}
//
// 			return quests;
// 		}
//
// 		/// <summary>
// 		/// 尝试获取奖励，如果任务没有完成不会领取
// 		/// </summary>
// 		public static void TryGetQuestReward(this QuestsComponent self, int configId, out List<ItemInfo> rewards)
// 		{
// 			rewards = new List<ItemInfo>();
// 			var unit = self.GetParent<Unit>();
// 			var quest = self.GetQuest(configId);
// 			if (quest == null)
// 			{
// 				return;
// 			}
//
// 			if (quest.IsClaimed())
// 			{
// 				return;
// 			}
//
// 			if (!quest.TryGetQuestAward(unit, out var itemInfos, out var livenessDict))
// 			{
// 				return;
// 			}
//
// 			//将积分的变动同步到客户端
// 			QuestNoticeHelper.SyncQuestLiveness(unit, livenessDict);
// 			rewards.AddRange(itemInfos);
// 			QuestNoticeHelper.SyncQuest(unit, quest, QuestOp.AddOrUpdate);
// 		}
//
//
// 		/// <summary>
// 		/// 清除领取的积分id
// 		/// </summary>
// 		public static void ClearLivenessClaimedIds(this QuestsComponent self, QuestCategory questCategory)
// 		{
// 			int category = (int)questCategory;
// 			if (self.ClaimedLiveness.ContainsKey(category))
// 			{
// 				self.ClaimedLiveness[category].Clear();
// 			}
// 		}
//
// 		/// <summary>
// 		/// 任务已完成
// 		/// </summary>
// 		[Event(SceneType.Map)]
// 		public class QuestCompleteEvent : AEvent<QuestCheckNext>
// 		{
// 			protected override async ETTask Run(Scene scene, QuestCheckNext args)
// 			{
// 				await ETTask.CompletedTask;
// 				var unit = args.Unit;
// 				var questsComponent = unit.GetComponent<QuestsComponent>();
// 				var quests = questsComponent.CheckNextQuest(args.Quest);
// 				QuestNoticeHelper.SyncQuest(unit, quests);
// 			}
// 		}
// 	}
// }