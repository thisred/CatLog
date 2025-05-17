namespace ET.Server
{
    [FriendOf(typeof(MatchComponent))]
    public static partial class MatchComponentSystem
    {
        public static async ETTask Match(this MatchComponent self, long playerId)
        {
            if (self.waitMatchPlayers.Contains(playerId))
            {
                return;
            }

            self.waitMatchPlayers.Add(playerId);
            // 当匹配人数不足时，直接返回
            if (self.waitMatchPlayers.Count < GameConst.MatchCount)
            {
                return;
            }

            // 匹配人数达到要求，申请一个房间
            var startSceneConfig = RandomGenerator.RandomArray(StartSceneConfigCategory.Instance.Maps);
            var match2MapGetRoom = Match2Map_GetRoom.Create();
            foreach (long id in self.waitMatchPlayers)
            {
                match2MapGetRoom.PlayerIds.Add(id);
            }

            self.waitMatchPlayers.Clear();

            var root = self.Root();
            var map2MatchGetRoom = await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, match2MapGetRoom) as Map2Match_GetRoom;

            var match2GNotifyMatchSuccess = Match2G_NotifyMatchSuccess.Create();
            match2GNotifyMatchSuccess.ActorId = map2MatchGetRoom.ActorId;
            var messageLocationSenderComponent = root.GetComponent<MessageLocationSenderComponent>();

            foreach (long id in match2MapGetRoom.PlayerIds) // 这里发送消息线程不会修改PlayerInfo，所以可以直接使用
            {
                messageLocationSenderComponent.Get(LocationType.Player).Send(id, match2GNotifyMatchSuccess);
                // 等待进入房间的确认消息，如果超时要通知所有玩家退出房间，重新匹配
            }
        }
    }
}