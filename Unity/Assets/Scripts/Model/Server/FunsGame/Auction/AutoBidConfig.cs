namespace ET.Auction
{
    /// <summary>
    /// 自动出价规则（类似eBay的代理竞价）
    /// </summary>
    public class AutoBidConfig
    {
        public string Id { get; set; } // 配置ID
        public string UserId { get; set; } // 用户ID
        public string AuctionId { get; set; } // 关联拍卖ID
        public int MaxBidAmount { get; set; } // 最高可接受价格
        public int BidIncrement { get; set; } // 每次最小加价幅度
        public bool IsActive { get; set; } // 是否生效
    }
}