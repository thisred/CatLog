using System;

namespace ET
{
    /// <summary>
    /// 猫猫
    /// </summary>
    [ChildOf(typeof(CatHouseComponent))]
    public class Cat : Entity, IAwake
    {
        /// <summary>
        /// 猫咪名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 亲密度 (0-100)
        /// </summary>
        public int Affection { get; set; }

        /// <summary>
        /// 猫咪状态
        /// </summary>
        public CatStatus Status { get; set; }

        /// <summary>
        /// 猫咪皮肤ID
        /// </summary>
        public string SkinId { get; set; }
    }

    // 养成触发的随机事件
    public class CatRandomEvent
    {
        public string Id { get; set; } // 事件ID
        public string TriggerAction { get; set; } // 触发动作（如"feed"）
        public float Chance { get; set; } // 触发概率 (0-1)
        public string[] RequiredConditions { get; set; } // ["Fullness>80", "Curiosity>50"]

        // 结果效果（可存储JSON）
        public string Effects { get; set; } // 例：{"SkillLevels[1]":"+2","CustomMessage":"猫偷学了邻居狗的捕猎技巧！"}

        public string EmojiAnimation { get; set; } // 关联的动画效果标识
    }

    public class CatMilestone
    {
        public string Id { get; set; } // 里程碑ID
        public string Condition { get; set; } // 解锁条件（如"SkillLevels[0]>=50"）
        public string Title { get; set; } // 称号（"捕猎大师"）
        public string BadgeEmoji { get; set; } // 成就图标（"🏆"）
        public bool IsSecret { get; set; } // 是否隐藏成就
    }
}