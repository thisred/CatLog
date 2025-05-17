using System;

namespace ET.Server
{
	[EnableClass]
	public abstract class AQuestHandler : IQuestHandler
	{
		public async ETTask InitHandle(Unit unit, Quest quest)
		{
			try
			{
				await Init(unit, quest);
			}
			catch (Exception e)
			{
				Log.Error($"任务异常,请检查配置: {quest.Config}\n{e}");
			}
		}

		public async ETTask RunHandle(Unit unit, Quest quest, object o)
		{
			try
			{
				await Run(unit, quest);
			}
			catch (Exception e)
			{
				Log.Error($"任务异常,请检查配置: {quest.Config}\n{e}");
			}
		}

		protected virtual async ETTask Init(Unit unit, Quest quest)
		{
			await Run(unit, quest);
		}

		protected abstract ETTask Run(Unit unit, Quest quest);

		public Type GetParamType()
		{
			return typeof(QuestNoParam);
		}
	}

	[EnableClass]
	public abstract class AQuestHandler<A> : IQuestHandler where A : IQuestParam, new()
	{
		public async ETTask InitHandle(Unit unit, Quest quest)
		{
			try
			{
				await Init(unit, quest);
			}
			catch (Exception e)
			{
				Log.Error($"任务异常,请检查配置: {quest.Config}\n{e}");
			}
		}

		public async ETTask RunHandle(Unit unit, Quest quest, object o)
		{
			try
			{
				var param = (A)o;
				await Run(unit, quest, param);
			}
			catch (Exception e)
			{
				Log.Error($"任务异常,请检查配置: {quest.Config}\n{e}");
			}
		}

		protected virtual async ETTask Init(Unit unit, Quest quest)
		{
			await ETTask.CompletedTask;
		}

		protected abstract ETTask Run(Unit unit, Quest quest, A args);

		public Type GetParamType()
		{
			return typeof(A);
		}
	}
}