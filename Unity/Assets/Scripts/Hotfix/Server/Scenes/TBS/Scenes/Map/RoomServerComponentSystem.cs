using System.Collections.Generic;
using System.Numerics;

namespace ET.Server
{
    [EntitySystemOf(typeof(RoomServerComponent))]
    [FriendOf(typeof(RoomServerComponent))]
    public static partial class RoomServerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.RoomServerComponent self)
        {
        }

        [EntitySystem]
        private static void Awake(this RoomServerComponent self, List<long> playerIds)
        {
            foreach (long id in playerIds)
            {
                var roomPlayer = self.AddChildWithId<RoomPlayer>(id);
            }
        }

        public static bool IsAllPlayerProgress100(this RoomServerComponent self)
        {
            foreach (var entity in self.Children.Values)
            {
                var roomPlayer = (RoomPlayer)entity;
                if (roomPlayer.Progress != 100)
                {
                    return false;
                }
            }

            return true;
        }
    }
}