// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// namespace ET.Server
// {
// 	[FriendOf(typeof(QuestHandlerComponent))]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOfAttribute(typeof(ET.QuestsComponent))]
// 	public static class QuestHandlerComponentSystem
// 	{
// 		public class QuestHandlerComponentAwakeSystem : AwakeSystem<QuestHandlerComponent>
// 		{
// 			protected override void Awake(QuestHandlerComponent self)
// 			{
// 				QuestHandlerComponent.Instance = self;
// 				self.Init();
// 			}
// 		}
//
// 		private static void Init(this QuestHandlerComponent self)
// 		{
// 			self.Handlers = new Dictionary<QuestType, QuestHandleInfo>();
// 			var types = EventSystem.Instance.GetTypes(typeof(QuestHandlerAttribute));
// 			foreach (var type in types)
// 			{
// 				object[] attrs = type.GetCustomAttributes(typeof(QuestHandlerAttribute), false);
// 				foreach (QuestHandlerAttribute attr in attrs)
// 				{
// 					var obj = (IQuestHandler)Activator.CreateInstance(type);
// 					if (obj == null)
// 					{
// 						Log.Error($"{type.Name}没有继承IQuestHandler");
// 						continue;
// 					}
//
// 					foreach (var questType in attr.QuestTypes)
// 					{
// 						if (self.Handlers.ContainsKey(questType))
// 						{
// 							Log.Error($"{questType} QuestHandler重复添加失败");
// 						}
// 						else
// 						{
// 							self.Handlers.Add(questType, new QuestHandleInfo(questType, obj));
// 						}
// 					}
// 				}
// 			}
// 		}
//
// 		/// <summary>
// 		/// 初始化任务
// 		/// </summary>
// 		public static async ETTask Init(this QuestHandlerComponent self, QuestsComponent questsComponent, Quest quest)
// 		{
// 			if (!self.Handlers.TryGetValue(quest.Config.Type, out var handleInfo))
// 			{
// 				// 没有对应处理类
// 				return;
// 			}
//
// 			var unit = questsComponent.GetParent<Unit>();
// 			if (quest.IsCompleted())
// 			{
// 				return;
// 			}
//
// 			long tempProgress = quest.QuestProgress;
// 			var tempState = quest.QuestState;
// 			await handleInfo.QuestHandler.InitHandle(unit, quest);
// 			if (tempProgress != quest.QuestProgress || tempState != quest.QuestState)
// 			{
// 				questsComponent.ChangedQuestIds.Add(quest.ConfigId);
// 			}
// 		}
//
// 		public static async ETTask<List<Quest>> Process<T>(this QuestHandlerComponent self,
// 			QuestsComponent questsComponent, QuestType questType, T args) where T : IQuestParam
// 		{
// 			var changed = new List<Quest>(); // 有变化的任务
// 			if (!self.Handlers.TryGetValue(questType, out var handleInfo) || handleInfo.ParamType != typeof(T))
// 			{
// 				return changed;
// 			}
//
// 			var unit = questsComponent.GetParent<Unit>();
// 			var quests = questsComponent.Children.Values.ToList();
// 			foreach (var entity in quests)
// 			{
// 				var quest = (Quest)entity;
// 				var questConfig = quest.Config;
// 				if (questConfig == null || questConfig.Type != handleInfo.QuestType)
// 				{
// 					continue;
// 				}
//
// 				if (quest.IsCompleted() && !questConfig.InheritProgress)
// 				{
// 					continue;
// 				}
//
// 				long tempProgress = quest.QuestProgress;
// 				var tempState = quest.QuestState;
// 				await handleInfo.QuestHandler.RunHandle(unit, quest, args);
// 				if (tempProgress != quest.QuestProgress || tempState != quest.QuestState)
// 				{
// 					changed.Add(quest);
// 				}
// 			}
//
// 			return changed;
// 		}
//
// 		public static async ETTask Process(this QuestHandlerComponent self, Quest quest, IQuestParam args)
// 		{
// 			var questsComponent = quest.GetParent<QuestsComponent>();
// 			var unit = questsComponent.GetParent<Unit>();
// 			var config = quest.Config;
// 			if (!self.Handlers.TryGetValue(config.Type, out var handleInfo) || handleInfo.ParamType != args.GetType())
// 			{
// 				return;
// 			}
//
// 			if (quest.IsCompleted() && !config.InheritProgress)
// 			{
// 				return;
// 			}
//
// 			await handleInfo.QuestHandler.RunHandle(unit, quest, args);
// 		}
// 	}
// }