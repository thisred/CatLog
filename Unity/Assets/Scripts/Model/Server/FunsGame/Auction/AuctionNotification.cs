using System;

namespace ET.Auction
{
    /// <summary>
    /// 拍卖事件通知
    /// </summary>
    public class AuctionNotification
    {
        public string Id { get; set; }              // 通知ID
        public string RelatedAuctionId { get; set; }// 关联拍卖ID
        public string TargetUserId { get; set; }   // 接收用户ID
        public string NotificationType { get; set; }// "outbid|success|fail"
        public string Message { get; set; }         // 生成的通知文案
        public DateTime CreateTime { get; set; }    // 生成时间
        public bool IsRead { get; set; }            // 是否已读
    }
}