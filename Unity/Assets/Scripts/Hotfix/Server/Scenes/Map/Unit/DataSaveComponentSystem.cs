using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(DataSaveComponent))]
    [FriendOf(typeof(DataSaveComponent))]
    public static partial class DataSaveComponentSystem
    {
        [EntitySystem]
        private static void Awake(this DataSaveComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(30000, TimerInvokeType.DataSave, self);
        }

        [EntitySystem]
        private static void Destroy(this DataSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        [EntitySystem]
        private static void GetComponentSys(this DataSaveComponent self, Type type)
        {
            if (!type.IsAssignableFrom(typeof(ICache)))
            {
                return;
            }

            self.ChangeTypes.Add(type);
        }

        [Invoke(TimerInvokeType.DataSave)]
        public class DataSaveTimer : ATimer<DataSaveComponent>
        {
            protected override void Run(DataSaveComponent self)
            {
                try
                {
                    self.Check().Coroutine();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        private static async ETTask Check(this DataSaveComponent self)
        {
            var unit = self.GetParent<Unit>();
            var entities = new Dictionary<string, Entity>();
            foreach (var type in self.ChangeTypes)
            {
                var cache = unit.GetComponent(type);
                entities.Add(type.Name, cache);
            }

            await DataHelper.Update(self.Scene(), unit.Id, entities);
        }
    }
}