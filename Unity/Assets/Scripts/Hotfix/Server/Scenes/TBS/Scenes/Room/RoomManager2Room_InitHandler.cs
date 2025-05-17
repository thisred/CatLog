using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.RoomRoot)]
    public class RoomManager2Room_InitHandler : MessageHandler<Scene, RoomManager2Room_Init, Room2RoomManager_Init>
    {
        protected override async ETTask Run(Scene root, RoomManager2Room_Init request, Room2RoomManager_Init response)
        {
            var room = root.AddComponent<TBSRoom>();
            room.AddComponent<RoomServerComponent, List<long>>(request.PlayerIds);

            // room.LSWorld = new LSWorld(SceneType.LockStepServer).Init();
            // room.LSWorld.AddComponent<RendererComponent>();
            await ETTask.CompletedTask;
        }
    }
}