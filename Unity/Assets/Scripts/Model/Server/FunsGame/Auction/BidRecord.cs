using System;

namespace ET.Auction
{
    /// <summary>
    /// 每次出价记录（子表）
    /// </summary>
    public class BidRecord
    {
        public string Id { get; set; } // 出价记录ID
        public string AuctionId { get; set; } // 关联的拍卖ID
        public string BidderId { get; set; } // 出价者用户ID
        public int BidAmount { get; set; } // 出价金额
        public DateTime BidTime { get; set; } // 出价时间
        public bool IsAutoBid { get; set; } // 是否为自动竞价
        public string BidderComment { get; set; } // 出价骚话（如"这袜子配我的拖鞋！"）
    }
}