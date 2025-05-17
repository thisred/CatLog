using System.Collections;
using System.Collections.Generic;
namespace ET
{
    public static class Const
    {
        public static readonly Dictionary<int, string> Names = new Dictionary<int, string>()
        {
            { 0, "文档猫" },
            { 1, "游戏猫" },
            { 2, "电话猫" },
            { 3, "马桶猫" },
            { 4, "红绿灯猫" },
            { 5, "路障猫" },
            { 6, "酒杯猫" },
            { 7, "遥控器猫" },
            { 8, "虾猫" },
        };

        public static readonly Dictionary<int, int> Round2SelectNum = new Dictionary<int, int>()
        {
            { 1, 1 },
            { 2, 3 },
            { 3, 5 },
        };

        public static readonly Dictionary<int, string> Tips = new Dictionary<int, string>()
        {
            { 0, "强于游戏猫 弱于电话猫遇到电话猫会被叫回去打工遇到游戏猫会变成压力怪各种骂脏话" },
            { 1, "强于电话猫 弱于文档猫遇到文档猫会焦虑地打游戏无视领导的需求" },
            { 2, "强于文档猫 弱于游戏猫遇到什么猫都会叮铃铃响只是会被游戏猫和功能猫无视" },
            { 3, "随机挑选一个对面的敌人吸进马桶里（如敌方有啤酒猫，首选吸啤酒猫，如果没有则随机吸" },
            { 4, "出现的时候会随机亮灯，红灯停并直接胜出，绿灯行（绿灯时对方能攻击）" },
            { 5, "遇上红绿灯牌，红绿灯牌失效" },
            { 6, "如果偶遇了另一只酒杯将会触发和平的效果（爆随机装备，随机加一只猫）" },
            { 7, "可以逆转对方的出棋顺序，让下一位上场对撞。没写代码，目前上场就是炮灰" },
            { 8, "虾猫技能太复杂待开发，目前上场就是炮灰" },
        };
    }
}