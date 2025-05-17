using System.Collections.Generic;

namespace ET.Client
{
    public static partial class SceneChangeHelper
    {
        public static async ETTask EnterWorldScene(Scene root, string sceneName, long sceneInstanceId)
        {
            var currentScenesComponent = root.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            var currentScene = CurrentSceneFactory.Create(sceneInstanceId, sceneName, currentScenesComponent);

            // 可以订阅这个事件中创建Loading界面
            await EventSystem.Instance.PublishAsync(root, new SceneChangeStart());
            var message = C2Room_ChangeSceneFinish.Create();
            message.PlayerId = root.GetComponent<PlayerComponent>().MyId;
            root.GetComponent<ClientSenderComponent>().Send(message);

            // 等待Room2C_EnterMap消息
            var waitRoom2CStart = await root.GetComponent<ObjectWait>().Wait<WaitType.Wait_Room2C_Start>();
            GameRoomStart gameRoomStart = new GameRoomStart()
            {
                PlayerIds = new List<long>()
            };
            foreach (TBSUnitInfo tbsUnitInfo in waitRoom2CStart.Message.UnitInfo)
            {
                gameRoomStart.PlayerIds.Add(tbsUnitInfo.PlayerId);
            }

            await EventSystem.Instance.PublishAsync(root, gameRoomStart);
            EventSystem.Instance.Publish(currentScene, new SceneChangeFinish());
            // 通知等待场景切换的协程
            root.GetComponent<ObjectWait>().Notify(new Wait_SceneChangeFinish());
        }
    }
}