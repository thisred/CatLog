// namespace ET.Server
// {
// 	[ActorMessageHandler(SceneType.Map)]
// 	public class
// 		C2M_ReceiveRewardHandler : AMActorLocationRpcHandler<Unit, C2M_ClaimQuestReward, M2C_ClaimQuestReward>
// 	{
// 		protected override async ETTask Run(Unit unit, C2M_ClaimQuestReward request, M2C_ClaimQuestReward response)
// 		{
// 			var category = request.ConfigId == -1 ? (QuestCategory)request.QuestCategory : QUEST_Table.Instance.GetOrDefault(request.ConfigId).Category;
// 			if (request.ConfigId == -1)
// 			{
// 				if (category != QuestCategory.Daily && category != QuestCategory.Weekly && category != QuestCategory.GuildBoss)
// 				{
// 					return;
// 				}
//
// 				// 如果是-1就是快速领取
// 				response.Error = QuestHelper.QuickGet(unit, category, out var rewards);
// 				response.RewardsList.AddRange(rewards);
// 			}
// 			else
// 			{
// 				QuestHelper.TryGetQuestReward(unit, request.ConfigId, out var rewards);
// 				response.RewardsList.AddRange(rewards);
// 				var quest = QUEST_Table.Instance.GetOrDefault(request.ConfigId);
// 				YzLogHelper.LogQuestInfo(unit, request.ConfigId, QuestState.Claimed, "领取", false);
//
// 			}
// 			if (category == QuestCategory.Daily || category == QuestCategory.Weekly)
// 			{
// 				string activity_topic = "";
// 				string activity_step = "";
// 				if (category == QuestCategory.Daily)
// 				{
// 					activity_topic = "日常任务";
// 					activity_step = "日常任务奖励领取";
// 				}
// 				else
// 				{
// 					activity_topic = "周常任务";
// 					activity_step = "周常任务奖励领取";
// 				}
// 				YzLogHelper.LogActivityInfo(unit, activity_topic, activity_step, "", "", null, response.RewardsList);
//
// 			}
// 			await ETTask.CompletedTask;
// 		}
// 	}
// }