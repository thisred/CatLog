namespace ET
{
    [ChildOf]
    public class RemoteCtrlAbility : Entity, IAbility, IAwake
    {
        public void DealDamage(TBSEntity me, TBSEntity target)
        {
            var tbsManager = me.Root().GetComponent<TBSRoom>().GetComponent<TBSManager>();

        }
    }
}