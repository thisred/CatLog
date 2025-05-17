namespace ET
{
    [EntitySystemOf(typeof(Unit))]
    public static partial class UnitSystem
    {
        [EntitySystem]
        private static void Awake(this Unit self)
        {
        }

        public static UnitType Type(this Unit self)
        {
            return UnitType.Monster;
        }
    }
}