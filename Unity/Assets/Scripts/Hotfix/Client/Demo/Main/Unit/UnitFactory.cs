namespace ET.Client
{
    public static partial class UnitFactory
    {
        // public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        // {
        //     var unitComponent = currentScene.GetComponent<UnitComponent>();
        //     var unit = unitComponent.AddChildWithId<Unit>(unitInfo.UnitId);
        //     unitComponent.Add(unit);
        //     var numericComponent = unit.AddComponent<NumericComponent>();
        //     // foreach (var kv in unitInfo.KV)
        //     // {
        //     //     numericComponent.Set(kv.Key, kv.Value);
        //     // }
        //
        //     unit.AddComponent<ObjectWait>();
        //
        //     EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() { Unit = unit });
        //     return unit;
        // }
    }
}