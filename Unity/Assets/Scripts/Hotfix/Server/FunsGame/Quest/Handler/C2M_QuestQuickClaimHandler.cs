// using System.Linq;
//
// namespace ET.Server
// {
// 	[ActorMessageHandler(SceneType.Map)]
// 	public class C2M_QuestQuickClaimHandler : AMActorLocationRpcHandler<Unit, C2M_QuestQuickClaim, M2C_QuestQuickClaim>
// 	{
// 		protected override async ETTask Run(Unit unit, C2M_QuestQuickClaim request, M2C_QuestQuickClaim response)
// 		{
// 			await ETTask.CompletedTask;
// 			var categories = request.QuestCategory.Select(item => (QuestCategory)item).ToList();
// 			var intParams = request.IntCategoryParams;
// 			response.Error = QuestHelper.QuickClaimByCategory(unit, categories, intParams, out var itemInfos);
//
// 			response.RewardsList.AddRange(itemInfos);
// 		}
// 	}
// }