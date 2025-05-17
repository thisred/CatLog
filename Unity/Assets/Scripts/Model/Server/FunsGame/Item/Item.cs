using System;
using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 游戏中的物品，能记录每个主人与跟随时间
    /// </summary>
    public class Item : Entity, IAwake
    {
        public long OwnerId { get; set; }
        public List<ItemOwner> Followers { get; set; } = new();
        public long CreateTime { get; set; }
    }

    public class ItemOwner
    {
        public long Id { get; set; }
        public string Nickname { get; set; } // 玩家昵称
        public long StartTime { get; set; }
        public long EndTime { get; set; }
    }

    

    // 玩家基础数据
    public class PlayerProfile
    {
        public string UserId { get; set; } // 关联微信ID
        public string Nickname { get; set; } // 玩家昵称
        public int Coins { get; set; } // 持有金币
        public int TotalEarnings { get; set; } // 历史总收益（成就用）
        public DateTime LastLogin { get; set; } // 最后登录时间
    }
}