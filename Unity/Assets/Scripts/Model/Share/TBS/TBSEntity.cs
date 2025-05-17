namespace ET
{
    [ChildOf(typeof(TBSEntityComponent))]
    public class TBSEntity : Entity, IAwake
    {
        public bool IsDie { get; set; }
        public long PlayerId { get; set; }
        public CardType CardType { get; set; }
        public CardCategory CardCategory { get; set; }
        public bool IsAbilityActive { get; set; }
    }
}