// namespace ET.Server
// {
// 	[ActorMessageHandler(SceneType.Map)]
// 	public class
// 		C2M_ClaimQuestsRewardHandler : AMActorLocationRpcHandler<Unit, C2M_ClaimQuestsReward, M2C_ClaimQuestsReward>
// 	{
// 		protected override async ETTask Run(Unit unit, C2M_ClaimQuestsReward request, M2C_ClaimQuestsReward response)
// 		{
// 			await ETTask.CompletedTask;
// 			bool isAllGet = request.ConfigIds.Count > 1;
// 			foreach (int configId in request.ConfigIds)
// 			{
// 				QuestHelper.TryGetQuestReward(unit, configId, out var rewards);
// 				response.RewardsList.AddRange(rewards);
// 				YzLogHelper.LogQuestInfo(unit, configId, QuestState.Completed, "达成",isAllGet);
// 			}
// 		}
// 	}
// }