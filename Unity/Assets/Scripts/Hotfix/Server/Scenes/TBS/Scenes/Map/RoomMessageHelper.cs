namespace ET.Server
{

    public static partial class RoomMessageHelper
    {
        public static void BroadCast(TBSRoom tbsRoom, IMessage message)
        {
            // 广播的消息不能被池回收
            (message as MessageObject).IsFromPool = false;
            
            var roomServerComponent = tbsRoom.GetComponent<RoomServerComponent>();

            var messageLocationSenderComponent = tbsRoom.Root().GetComponent<MessageLocationSenderComponent>();
            foreach (var kv in roomServerComponent.Children)
            {
                var roomPlayer = kv.Value as RoomPlayer;

                if (!roomPlayer.IsOnline)
                {
                    continue;
                }
                
                messageLocationSenderComponent.Get(LocationType.GateSession).Send(roomPlayer.Id, message);
            }
        }
    }
}