namespace ET
{
	[ChildOf(typeof(QuestsComponent))]
	public class Quest : Entity, IDestroy, ISerializeToEntity, IAwake<int>
	{
		/// <summary>
		/// 任务配置id
		/// </summary>
		public int ConfigId = 0;
		
		/// <summary>
		/// 任务状态
		/// 用这个来判断任务是否完成可领奖有风险，策划有可能改完成数量配置，导致改配置之前未完成的任务现在的数量在改之后足够完成，任务状态未更新
		/// </summary>
		public QuestState QuestState = 0;
		
		/// <summary>
		/// 任务进度
		/// </summary>
		public long QuestProgress = 0;
		
		/// <summary>
		/// 记录任务进度，存序列化后的信息
		/// </summary>
		public string ProgressData;
		
		/// <summary>
		/// 用于记录多轮任务的当前轮数下标
		/// </summary>
		public int RoundIndex;
		
		public QUEST Config => QUEST_Table.Instance.GetOrDefault(ConfigId);
		public const int MaxRound = 1000;
	}
}