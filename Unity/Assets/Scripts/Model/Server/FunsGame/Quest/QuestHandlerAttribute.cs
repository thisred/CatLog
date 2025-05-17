using System;

namespace ET
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class QuestHandlerAttribute : BaseAttribute
	{
		public QuestType[] QuestTypes { get; }

		public QuestHandlerAttribute(params QuestType[] questTypes)
		{
			this.QuestTypes = questTypes;
		}
	}
}