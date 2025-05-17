using System;

namespace ET
{
    // 黑市交易记录

    public class MarketTransaction
    {
        public string Id { get; set; } // 交易ID
        public string SellerUserId { get; set; } // 卖家用户ID
        public string BuyerUserId { get; set; } // 买家用户ID（未售出时为null）
        public string InventoryItemId { get; set; } // 交易的物品实例ID
        public int ListedPrice { get; set; } // 挂牌价格
        public int FinalPrice { get; set; } // 实际成交价（可能被砍价）
        public DateTime ListTime { get; set; } // 上架时间
        public DateTime? SoldTime { get; set; } // 售出时间（未售出为null）
        public string FlavorText { get; set; } // 随机生成的交易文案
    }
}