using System;

namespace ET.Auction
{
    /// <summary>
    /// 拍卖中的物品（主表）
    /// </summary>
    public class AuctionItem
    {
        public string Id { get; set; } // 拍卖唯一ID
        public string RoleId { get; set; } // 拍卖角色ID
        public string InventoryItemId { get; set; } // 关联的库存物品ID
        public int StartingPrice { get; set; } // 起拍价
        public int BuyoutPrice { get; set; } // 一口价（可选）
        public DateTime StartTime { get; set; } // 上架时间
        public DateTime EndTime { get; set; } // 拍卖结束时间
        public string Status { get; set; } // "bidding|sold|expired|canceled"
        public int CurrentBid { get; set; } // 当前最高出价
        public string CurrentBidderId { get; set; } // 当前最高出价者ID（null表示流拍）
        public string SpecialConditions { get; set; } // 特殊条件（如"仅限橘猫主人"）
    }
}