using System;

namespace ET.Auction
{
    /// <summary>
    /// 拍卖行全局数据（用于展示热榜）
    /// </summary>
    public class AuctionHouseStats
    {
        public string Id { get; set; } // 统计ID（可按小时/天分区）
        public int TotalActiveAuctions { get; set; } // 当前进行中的拍卖数
        public int TotalItemsSold { get; set; } // 已售出物品总数
        public int HighestBidToday { get; set; } // 今日最高成交价
        public string MostActiveCatId { get; set; } // 最活跃卖货猫咪ID
        public DateTime UpdateTime { get; set; } // 最后统计时间
    }
}