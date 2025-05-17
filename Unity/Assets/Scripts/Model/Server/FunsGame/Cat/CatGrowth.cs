using System;

namespace ET
{
    /// <summary>
    /// 猫咪成长属性
    /// </summary>
    public class CatGrowth
    {
        public long CatId { get; set; } // 关联猫咪ID
        public int Fullness { get; set; } // 饱食度 (0-100)
        public int Cleanliness { get; set; } // 清洁度 (0-100)
        public int Energy { get; set; } // 精力值 (0-100)
        public int Curiosity { get; set; } // 好奇心 (隐藏属性)
        public int[] SkillLevels { get; set; } // 技能数组 [狩猎, 社交, 卖萌]
        public DateTime LastGrowthCheck { get; set; } // 上次属性衰减时间
    }
}