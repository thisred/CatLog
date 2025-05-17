namespace ET
{
    // 战利品物品
    public class LootItem
    {
        public string Id { get; set; } // 物品唯一ID
        public string Name { get; set; } // 物品名称
        public string Emoji { get; set; } // 物品Emoji
        public int BasePrice { get; set; } // 基础价值
        public string Category { get; set; } // 分类: "junk"/"food"/"treasure"
        public string Origin { get; set; } // 来源描述 ("小区垃圾桶"/"神秘洞穴")
        public string SpecialEffect { get; set; } // 特殊效果标记
    }
}