namespace ET.Client
{
    public static partial class UnitHelper
    {
        public static Unit GetMyUnitFromClientScene(Scene root)
        {
            var playerComponent = root.GetComponent<PlayerComponent>();
            var currentScene = root.GetComponent<CurrentScenesComponent>().Scene;
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }
        
        public static Unit GetMyUnitFromCurrentScene(Scene currentScene)
        {
            var playerComponent = currentScene.Root().GetComponent<PlayerComponent>();
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }
    }
}