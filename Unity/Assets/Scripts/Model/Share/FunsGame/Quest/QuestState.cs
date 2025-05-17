namespace ET
{
	public enum QuestState
	{
		NotStart,
		/// <summary>
		/// 正在进行
		/// </summary>
		Doing,
		/// <summary>
		/// 完成任务
		/// </summary>
		Completed,
		/// <summary>
		/// 领取过奖励
		/// </summary>
		Claimed,
	}

	/// <summary>
	/// 任务更新类型
	/// </summary>
	public enum QuestOp
	{
		AddOrUpdate,
		Delete,
	}
}