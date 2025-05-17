using System;

namespace ET
{
    // 玩家库存物品

    public class InventoryItem
    {
        public string Id { get; set; } // 实例ID
        public string LootItemId { get; set; } // 对应LootItem的ID
        public string OwnerCatId { get; set; } // 带回此物的猫咪ID
        public DateTime ObtainTime { get; set; } // 获得时间
        public bool IsProcessed { get; set; } // 是否已加工
        public int CurrentPrice { get; set; } // 当前估值（可能被加工影响）
    }
}