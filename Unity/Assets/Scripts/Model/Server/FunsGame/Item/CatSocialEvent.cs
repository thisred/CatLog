using System;

namespace ET
{
    // 猫咪社交行为

    public class CatSocialEvent
    {
        public string Id { get; set; } // 事件ID
        public string CatId { get; set; } // 发起猫咪ID
        public string TargetUserId { get; set; } // 目标用户ID（如果是去别人家）
        public string EventType { get; set; } // 事件类型: "visit"/"steal"/"gift"
        public string RelatedItemId { get; set; } // 关联物品ID（可能带/偷东西）
        public DateTime EventTime { get; set; } // 发生时间
        public bool IsCompleted { get; set; } // 是否已完成
    }
}