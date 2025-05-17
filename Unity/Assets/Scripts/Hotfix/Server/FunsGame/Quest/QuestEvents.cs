// namespace ET.Server
// {
// 	/// <summary>
// 	/// 登录
// 	/// </summary>
// 	[Event(SceneType.Map)]
// 	public class QuestOnLoginEvent : AQuestEvent<EventType.OnLogin>
// 	{
// 		protected override async ETTask Process(Scene scene, EventType.OnLogin args)
// 		{
// 			await ETTask.CompletedTask;
// 			var unit = args.Unit;
//
// 			QuestHelper.Run(unit, QuestType.LoginToday, 1);
// 			QuestHelper.Run(unit, QuestType.LoginNextDay);
// 			QuestHelper.Run(unit, QuestType.LoginServerDay);
// 		}
// 	}
// }