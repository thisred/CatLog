using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 用于驱动游戏回合的状态机
    /// </summary>
    [ComponentOf(typeof(TBSRoom))]
    public class TBSStateMachine : Entity, IAwake, IUpdate
    {
        public Dictionary<TBSState, ITBSState> States { get; } = new();
        public ITBSState CurrentState { get; set; }
    }
}