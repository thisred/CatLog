using System;

namespace ET
{
	/// <summary>
	/// 任务处理类接口
	/// </summary>
	public interface IQuestHandler
	{
		/// <summary>
		/// 任务初始化
		/// </summary>
		/// <param name="unit">玩家实体</param>
		/// <param name="quest">任务</param>
		ETTask InitHandle(Unit unit, Quest quest);
		
		/// <summary>
		/// 任务更新进度
		/// </summary>
		/// <param name="unit">玩家实体</param>
		/// <param name="quest">任务</param>
		/// <param name="o">任务参数</param>
		ETTask RunHandle(Unit unit, Quest quest, object o);
		
		/// <summary>
		/// 获取任务参数类型
		/// </summary>
		/// <returns></returns>
		public Type GetParamType();
	}
}