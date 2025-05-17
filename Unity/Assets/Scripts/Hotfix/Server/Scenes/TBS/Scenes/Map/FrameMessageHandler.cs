// namespace ET.Server
// {
//     [MessageHandler(SceneType.RoomRoot)]
//     [FriendOfAttribute(typeof(TBSRoom))]
//     public class FrameMessageHandler : MessageHandler<Scene, FrameMessage>
//     {
//         protected override async ETTask Run(Scene root, FrameMessage message)
//         {
//             using var _ = message; // 让消息回到池中
//             var room = root.GetComponent<TBSRoom>();
//             room.PlayerInputDic[message.PlayerId] = message.Input;
//             await ETTask.CompletedTask;
//         }
//     }
// }
