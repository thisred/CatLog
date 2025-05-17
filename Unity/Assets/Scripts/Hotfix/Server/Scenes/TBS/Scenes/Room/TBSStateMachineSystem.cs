using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(TBSStateMachine))]
    [FriendOfAttribute(typeof(ET.TBSStateMachine))]
    public static partial class TBSStateMachineSystem
    {
        [EntitySystem]
        private static void Awake(this ET.TBSStateMachine self)
        {
            self.States[TBSState.TurnStart] = new TurnStartState();
            self.States[TBSState.PreparationPhase] = new PreparationPhaseState();
            self.States[TBSState.CombatPhase] = new CombatPhaseState();
            self.States[TBSState.TurnEnd] = new TurnEndState();
        }

        [EntitySystem]
        private static void Update(this ET.TBSStateMachine self)
        {
            TBSRoom room = self.GetParent<TBSRoom>();
            long timeNow = TimeInfo.Instance.ServerFrameTime();
            int frame = room.AuthorityFrame + 1;
            if (timeNow < room.FixedTimeCounter.FrameTime(frame))
            {
                return;
            }

            ++room.AuthorityFrame;
            self.CurrentState?.Update(room, GameConst.UpdateInterval);
        }

        public static void ChangeState(this ET.TBSStateMachine self, TBSState newState)
        {
            TBSRoom room = self.GetParent<TBSRoom>();
            if (self.States.TryGetValue(newState, out ITBSState value))
            {
                Log.Console($"{self.CurrentState} => {newState}");
                try
                {
                    self.CurrentState?.Exit(room);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }

                self.CurrentState = value;
                self.CurrentState.Enter(room);
            }
        }
    }
}