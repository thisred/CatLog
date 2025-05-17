using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(TBSRoom))]
    public static partial class RoomSystem
    {
        public static void Init(this TBSRoom self, long startTime, int frame = -1)
        {
            self.StartTime = startTime;
            self.FixedTimeCounter = new FixedTimeCounter(self.StartTime, 0, GameConst.UpdateInterval);
            self.AddComponent<TBSUnitComponent>();
            self.AddComponent<TBSStateMachine>();
            self.AddComponent<TimeoutComponent>();
            var addComponent = self.AddComponent<TBSManager>();
            addComponent.Init();
        }

        public static void Start(this TBSRoom self)
        {
            var tbsStateMachine = self.GetComponent<TBSStateMachine>();
            tbsStateMachine.ChangeState(TBSState.TurnStart);
        }

        public static void InitPlayer(this TBSRoom self, List<TBSUnitInfo> unitInfos)
        {
            var tbsManager = self.GetComponent<TBSManager>();
            for (int i = 0; i < unitInfos.Count; ++i)
            {
                var unitInfo = unitInfos[i];
                TBSUnitFactory.Init(self, unitInfo);
            }

            tbsManager.PlayerId1 = unitInfos[0].PlayerId;
            tbsManager.PlayerId2 = unitInfos[1].PlayerId;
        }
    }
}