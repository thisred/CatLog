namespace ET.NewWorld.Shop
{
    public class CatItem
    {
        public string Id { get; set; } // 道具ID
        public string EffectOn { get; set; } // 影响属性（"Fullness|Energy"）
        public int EffectValue { get; set; } // 增加值
        public bool IsConsumable { get; set; } // 是否消耗品
        public string SpecialEventId { get; set; } // 关联特殊事件
    }
}