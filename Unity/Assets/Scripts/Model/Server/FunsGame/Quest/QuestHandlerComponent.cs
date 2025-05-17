using System;
using System.Collections.Generic;

namespace ET
{
	/// <summary>
	/// 处理任务分发
	/// </summary>
	[ComponentOf(typeof(Scene))]
	public class QuestHandlerComponent : Entity, IAwake
	{
		public static QuestHandlerComponent Instance { get; set; }
		
		public Dictionary<QuestType, QuestHandleInfo> Handlers;
	}
	
	/// <summary>
	/// 记录任务类型和处理类
	/// </summary>
	public class QuestHandleInfo
	{
		public QuestType QuestType { get; }
		public IQuestHandler QuestHandler { get; }
		public Type ParamType { get; }
		
		public QuestHandleInfo(QuestType questType, IQuestHandler questHandler)
		{
			QuestType = questType;
			QuestHandler = questHandler;
			ParamType = questHandler.GetParamType();
		}
	}
}