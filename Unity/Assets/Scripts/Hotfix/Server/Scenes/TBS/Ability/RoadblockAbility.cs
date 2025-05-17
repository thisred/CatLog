namespace ET
{
    /// <summary>
    /// 遇上红绿灯牌，红绿灯牌失效
    /// </summary>
    [ChildOf]
    public class RoadblockAbility : Entity, IAbility, IAwake
    {
        public void DealDamage(TBSEntity me, TBSEntity target)
        {
            var tbsManager = me.Root().GetComponent<TBSRoom>().GetComponent<TBSManager>();

            if (target.CardType == CardType.Traffic)
            {
                var cardInfos = CardInfos.Create(); // 每回合数据
                tbsManager.GetCurrentRoundResult().Add(cardInfos);
                cardInfos.UnitCardInfos[target.PlayerId] = UnitCardInfo.Create();
                cardInfos.UnitCardInfos[me.PlayerId] = UnitCardInfo.Create();

                target.IsDie = true;
                cardInfos.UnitCardInfos[target.PlayerId].Info.Add((int)BattleResult.Die, (int)target.CardType);
            }
        }
    }
}