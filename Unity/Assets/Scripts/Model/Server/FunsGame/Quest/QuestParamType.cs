using System.Collections.Generic;

namespace ET
{
	public interface IQuestParam
	{
	}
	
	public struct QuestNoParam : IQuestParam
	{
	}
	
	public struct QuestValueParam : IQuestParam
	{
		public long Value;
	}
	
	
	/// <summary>
	/// 获得x物品y个
	/// </summary>
	public struct GetItemCount : IQuestParam
	{
		public int ItemId;
		public long AddNum;
	}
	
}