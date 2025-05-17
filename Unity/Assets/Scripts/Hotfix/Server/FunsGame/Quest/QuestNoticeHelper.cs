using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
	[FriendOf(typeof(QuestsComponent))]
	public static class QuestNoticeHelper
	{
		/// <summary>
		/// 同步任务信息给客户端
		/// </summary>
		public static void SyncQuest(Unit unit, Quest info, QuestOp op)
		{
			// var message = new M2C_UpdateQuest { QuestProto = info.ToMessage(), Op = (int)op };
			// MessageHelper.SendToClient(unit, message);
		}

		/// <summary>
		/// 同步很多任务
		/// </summary>
		public static void SyncQuest(Unit unit, HashSet<int> questIds)
		{
			// if (questIds.Count == 0)
			// 	return;
			// var message = new M2C_SyncQuestList();
			// var questsComponent = unit.GetComponent<QuestsComponent>();
			// foreach (int configId in questIds)
			// {
			// 	var quest = questsComponent.GetQuest(configId);
			// 	if (quest != null)
			// 	{
			// 		message.QuestProto.Add(quest.ToMessage());
			// 	}
			// }
			//
			// MessageHelper.SendToClient(unit, message);
		}

		/// <summary>
		/// 同步很多任务
		/// </summary>
		public static void SyncQuest(Unit unit, List<Quest> quests)
		{
			// if (quests.Count == 0)
			// 	return;
			// var message = new M2C_SyncQuestList();
			// foreach (var quest in quests)
			// {
			// 	message.QuestProto.Add(quest.ToMessage());
			// }
			//
			// MessageHelper.SendToClient(unit, message);
		}

		/// <summary>
		/// 同步活跃度宝箱领取情况
		/// </summary>
		public static void SyncQuestLivenessBox(Unit unit)
		{
			// var questsComponent = unit.GetComponent<QuestsComponent>();
			// var message = new M2C_SyncLiveness();
			// foreach (var (questType, claimIds) in questsComponent.ClaimedLiveness)
			// {
			// 	message.QuestLiveness.Add(questType, new QuestLivenessProto() { ClaimedChestIds = claimIds.ToList() });
			// }
			// MessageHelper.SendToClient(unit, message);
		}

		/// <summary>
		/// 同步所有任务给客户端
		/// </summary>
		public static void SyncAllQuest(Unit unit)
		{
		// 	var questsComponent = unit.GetComponent<QuestsComponent>();
		//
		// 	var message = new M2C_AllQuestList();
		// 	foreach (var quest in questsComponent.QuestDic.Values.ToList())
		// 	{
		// 		message.QuestProto.Add(quest.ToMessage());
		// 	}
		// 	foreach (var (questType, claimIds) in questsComponent.ClaimedLiveness)
		// 	{
		// 		message.QuestLiveness.Add(questType, new QuestLivenessProto() { ClaimedChestIds = claimIds.ToList() });
		// 	}
		// 	MessageHelper.SendToClient(unit, message);
		}

		/// <summary>
		/// 同步活跃度到客户端
		/// </summary>
		public static void SyncQuestLiveness(Unit unit, Dictionary<QuestCategory, int> addLivenessDict)
		{
			//增量
			// if (addLivenessDict.Count <= 0)
			// {
			// 	return;
			// }
			//
			// foreach (var (category, value) in addLivenessDict)
			// {
			// 	NumericHelper.Add(unit, ET.QuestHelper.GetQuestLivenessType(category), value);
			// }
		}
	}
}