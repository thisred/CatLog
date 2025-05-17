namespace ET
{
    /// <summary>
    /// 定义一个能力接口，用于表示游戏中的各种能力。
    /// </summary>
    public interface IAbility
    {
        /// <summary>
        /// 回合开始前调用的方法，用于执行回合开始前的准备工作。
        /// </summary>
        void OnTurnBefore()
        {
        }

        /// <summary>
        /// 回合开始时调用的方法，用于执行回合开始时的逻辑。
        /// </summary>
        void OnTurnStart()
        {
        }

        /// <summary>
        /// 回合结束时调用的方法，用于执行回合结束时的逻辑。
        /// </summary>
        void OnTurnEnd()
        {
        }

        /// <summary>
        /// 造成伤害前调用的方法，用于执行造成伤害前的准备工作。
        /// </summary>
        void OnBeforeDealDamage()
        {
        }

        /// <summary>
        /// 造成伤害时调用的方法，具体实现应包含伤害计算和应用逻辑。
        /// </summary>
        void DealDamage(TBSEntity me, TBSEntity target)
        {
        }

        /// <summary>
        /// 造成伤害后调用的方法，用于执行造成伤害后的逻辑，如治疗、状态应用等。
        /// </summary>
        void OnAfterDealDamage()
        {
        }

        /// <summary>
        /// 承受伤害前调用的方法，用于执行承受伤害前的准备工作。
        /// </summary>
        void OnBeforeTakeDamage()
        {
        }

        /// <summary>
        /// 承受伤害时调用的方法，具体实现应包含伤害计算和应用逻辑。
        /// </summary>
        void TakeDamage()
        {
        }

        /// <summary>
        /// 承受伤害后调用的方法，用于执行承受伤害后的逻辑，如治疗、状态应用等。
        /// </summary>
        void OnAfterTakeDamage()
        {
        }
    }
}