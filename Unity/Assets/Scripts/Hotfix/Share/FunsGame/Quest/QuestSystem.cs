// using System.Linq;
//
// namespace ET
// {
// 	[FriendOf(typeof(Quest))]
// 	public static partial class QuestSystem
// 	{
// 		public class QuestsAwakeSystem : AwakeSystem<Quest, int>
// 		{
// 			protected override void Awake(Quest self, int configId)
// 			{
// 				self.ConfigId = configId;
// 			}
// 		}
//
// 		[FriendOf(typeof(QuestsComponent))]
// 		public class QuestsDestroySystem : DestroySystem<Quest>
// 		{
// 			protected override void Destroy(Quest self)
// 			{
// 				var parent = self.GetParent<QuestsComponent>();
// 				parent.QuestDic.Remove(self.ConfigId);
// 			}
// 		}
//
// 		public static void FromMessage(this Quest self, QuestProto proto)
// 		{
// 			self.ConfigId = proto.ConfigId;
// 			self.QuestProgress = proto.Progress;
// 			self.QuestState = (QuestState)proto.State;
// 			self.RoundIndex = proto.RoundIndex;
// 		}
//
// 		public static QuestProto ToMessage(this Quest self)
// 		{
// 			var proto = new QuestProto
// 			{
// 				ConfigId = self.ConfigId,
// 				Progress = self.QuestProgress,
// 				State = (int)self.QuestState,
// 				RoundIndex = self.RoundIndex
// 			};
// 			return proto;
// 		}
//
// 		/// <summary>
// 		/// 判断任务是否可领取奖励
// 		/// </summary>
// 		public static bool CanClaim(this Quest self)
// 		{
// 			var config = self.Config;
// 			if (config == null) return false;
// 			
// 			long requireNum = 0;
// 			if (config.MultiRound.Count == 0)
// 			{
// 				// 普通任务完成要求数量可领奖
// 				requireNum = config.RequireNum;
// 			}
// 			else
// 			{
// 				// 多轮任务每一轮可领奖
// 				int roundIndex = self.RoundIndex;
// 				if (roundIndex > config.MultiRound.Count - 1)
// 				{
// 					return false;
// 				}
//
// 				requireNum = config.MultiRound[roundIndex];
// 			}
//
// 			return self.QuestState == QuestState.Completed ||
// 					self.QuestState == QuestState.Doing && self.QuestProgress >= requireNum;
// 		}
//
// 		/// <summary>
// 		/// 获取任务当前完成计数，兼容多轮任务
// 		/// </summary>
// 		public static long GetCurrentRequireNum(this Quest self)
// 		{
// 			var config = self.Config;
// 			const long min = 1; // 最小进度
// 			if (config.MultiRound.Count == 0)
// 			{
// 				// 普通任务
// 				return config.RequireNum < min ? min : config.RequireNum;
// 			}
//
// 			// 多轮任务
// 			int roundIndex = self.RoundIndex;
// 			if (roundIndex > config.MultiRound.Count - 1)
// 			{
// 				int requireCount = config.MultiRound.LastOrDefault();
// 				return requireCount < min ? min : requireCount;
// 			}
//
// 			int requireNum = config.MultiRound[roundIndex];
// 			return requireNum < min ? min : requireNum;
// 		}
//
// 		/// <summary>
// 		/// 获取任务完成最终计数
// 		/// </summary>
// 		/// <param name="self"></param>
// 		/// <returns></returns>
// 		public static long GetRequireNum(this Quest self)
// 		{
// 			var config = self.Config;
// 			return config.MultiRound.Count == 0
// 				? config.RequireNum
// 				: config.MultiRound.LastOrDefault();
// 		}
//
// 		/// <summary>
// 		/// 判断任务是否完成
// 		/// </summary>
// 		public static bool IsCompleted(this Quest self)
// 		{
// 			return self.QuestState == QuestState.Claimed || self.QuestState == QuestState.Completed ||
// 					self.QuestProgress >= self.GetRequireNum();
// 		}
//
// 		/// <summary>
// 		/// 判断任务奖励是否已经领取
// 		/// </summary>
// 		public static bool IsClaimed(this Quest self) => self.QuestState == QuestState.Claimed;
//
// 	}
// }