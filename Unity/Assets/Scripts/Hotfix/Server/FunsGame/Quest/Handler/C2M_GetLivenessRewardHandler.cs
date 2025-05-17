// using System.Collections.Generic;
//
// namespace ET.Server
// {
// 	[ActorMessageHandler(SceneType.Map)]
// 	public class
// 		C2M_GetLivenessRewardHandler : AMActorLocationRpcHandler<Unit, C2M_GetLivenessChest, M2C_GetLivenessChest>
// 	{
// 		protected override async ETTask Run(Unit unit, C2M_GetLivenessChest request, M2C_GetLivenessChest response)
// 		{
// 			List<ItemInfo> rewards = null;
// 			var category = (QuestCategory)request.QuestCategory;
//
// 			// 之后有不同任务类别的额外判断 可以加在这里
// 			if (category == QuestCategory.JunglePrestige)
// 			{
// 				bool success =
// 					BattlePassHelper.CheckClaimLivenessReward(unit, request.CategoryParam, out int errorcode);
// 				if (!success)
// 				{	
// 					response.Error = errorcode;
// 					return;
// 				}
// 			}
//
// 			QuestHelper.GetLivenessReward(unit, category, request.CategoryParam, out rewards);
// 			response.RewardsList = rewards;
// 			await ETTask.CompletedTask;
// 		}
// 	}
// }