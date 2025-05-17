using System.Collections.Generic;

namespace ET
{
    public class RoundInfo
    {
        public int Round { get; set; }

        /// <summary>
        /// 回合准备 玩家id => 输入
        /// </summary>
        public Dictionary<long, PlayerRoundInput> PlayerInputs { get; set; } = new Dictionary<long, PlayerRoundInput>();

        /// <summary>
        /// 回合结束 客户端播放动画完成
        /// </summary>
        public List<long> AnimationComplete { get; set; } = new List<long>();
    }

    /// <summary>
    /// 游戏简单，玩家输入只是卡牌顺序
    /// </summary>
    public class PlayerRoundInput
    {
        public List<CardType> Cards { get; set; } = new List<CardType>();
    }
}