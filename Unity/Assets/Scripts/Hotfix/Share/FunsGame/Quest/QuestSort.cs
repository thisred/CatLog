// using System;
//
// namespace ET
// {
// 	[FriendOf(typeof(Quest))]
// 	public static class QuestSort
// 	{
// 		/// <summary>
// 		/// 任务排序
// 		/// </summary>
// 		public static int NormalComparison(Quest a, Quest b)
// 		{
// 			// 可领奖的在最前
// 			bool aCanClaim = a.CanClaim();
// 			bool bCanClaim = b.CanClaim();
// 			switch (aCanClaim)
// 			{
// 				case true when !bCanClaim:
// 					return -1;
// 				case false when bCanClaim:
// 					return 1;
// 			}
//
// 			// 已领奖的在最后
// 			bool aIsClaimed = a.IsClaimed();
// 			bool bIsClaimed = b.IsClaimed();
// 			switch (aIsClaimed)
// 			{
// 				case true when !bIsClaimed:
// 					return 1;
// 				case false when bIsClaimed:
// 					return -1;
// 			}
//
// 			// 未完成进度高的在前
// 			long aRequireNum = a.GetRequireNum();
// 			long bRequireNum = b.GetRequireNum();
// 			if (aRequireNum > 0 && bRequireNum > 0)
// 			{
// 				float aPercent = (float)a.QuestProgress / aRequireNum;
// 				float bPercent = (float)b.QuestProgress / bRequireNum;
// 				if (Math.Abs(aPercent - bPercent) > 0.001)
// 				{
// 					return bPercent.CompareTo(aPercent);
// 				}
// 			}
//
// 			// 序号低的在前
// 			return a.ConfigId.CompareTo(b.ConfigId);
// 		}
//
// 		/// <summary>
// 		/// 任务排序
// 		/// </summary>
// 		public static int HomeComparison(Quest a, Quest b)
// 		{
// 			// 已领奖的在最后
// 			bool aIsClaimed = a.IsClaimed();
// 			bool bIsClaimed = b.IsClaimed();
// 			switch (aIsClaimed)
// 			{
// 				case true when !bIsClaimed:
// 					return 1;
// 				case false when bIsClaimed:
// 					return -1;
// 			}
//
// 			// 序号低的在前
// 			return a.ConfigId.CompareTo(b.ConfigId);
// 		}
//
// 		/// <summary>
// 		/// 主线任务排序
// 		/// </summary>
// 		public static int MainLineComparison(Quest a, Quest b)
// 		{
// 			// 已领奖的在最后
// 			bool aIsClaimed = a.IsClaimed();
// 			bool bIsClaimed = b.IsClaimed();
// 			switch (aIsClaimed)
// 			{
// 				case true when !bIsClaimed:
// 					return 1;
// 				case false when bIsClaimed:
// 					return -1;
// 			}
//
// 			// 序号低的在前
// 			return a.ConfigId.CompareTo(b.ConfigId);
// 		}
// 	}
// }