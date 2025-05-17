namespace ET
{
    /// <summary>
    /// 描述游戏中的回合状态。
    /// </summary>
    public enum TBSState
    {
        /// <summary>
        /// 回合开始状态。
        /// </summary>
        TurnStart,

        /// <summary>
        /// 游戏回合的准备阶段。
        /// </summary>
        PreparationPhase,

        /// <summary>
        /// 游戏回合的战斗阶段。
        /// </summary>
        CombatPhase,

        /// <summary>
        /// 回合结束状态。
        /// </summary>
        TurnEnd
    }
}