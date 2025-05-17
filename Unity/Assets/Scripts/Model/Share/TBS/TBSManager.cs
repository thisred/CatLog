using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 用于管理TBS房间中的玩家,接收玩家的操作
    /// </summary>
    [ComponentOf(typeof(TBSRoom))]
    public class TBSManager : Entity, IAwake
    {
        public long PlayerId1 { get; set; }
        public long PlayerId2 { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public Dictionary<long, int> Score { get; set; } = new();

        /// <summary>
        /// 当前轮次
        /// </summary>
        public int Round { get; set; }

        /// <summary>
        /// 轮次信息
        /// </summary>
        public Dictionary<int, RoundInfo> RoundInfos { get; set; } = new();

        /// <summary>
        /// 每回合结果
        /// </summary>
        public Dictionary<int, List<CardInfos>> Dictionary { get; set; } = new();

        /// <summary>
        /// 当前回合生成的英雄
        /// </summary>
        public Dictionary<long, CardType> SpawnCards{ get; set; } = new();
    }
}