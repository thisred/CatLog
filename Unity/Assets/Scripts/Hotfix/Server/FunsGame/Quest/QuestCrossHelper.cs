// using System.Collections.Generic;
//
// namespace ET.Server
// {
// 	/// <summary>
// 	/// 任务的跨服逻辑
// 	/// </summary>
// 	public static class QuestCrossHelper
// 	{
// 		public static async ETTask<QuestUpdateResponse> CallMap(long roleId, QuestType questType, List<int> args)
// 		{
// 			var request = new QuestUpdateRequest() { QuestType = (int)questType };
// 			request.Param.AddRange(args);
// 			var response = (QuestUpdateResponse)await ActorLocationSenderComponent.Instance.Call(roleId, request);
// 			return response;
// 		}
// 	}
// }