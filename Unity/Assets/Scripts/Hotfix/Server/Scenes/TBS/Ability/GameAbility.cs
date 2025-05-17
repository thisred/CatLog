namespace ET
{
    [ChildOf]
    public class GameAbility : Entity, IAwake, IAbility
    {
        public void DealDamage(TBSEntity me, TBSEntity target)
        {
            var tbsManager = me.Root().GetComponent<TBSRoom>().GetComponent<TBSManager>();
        

            // 强于电话猫，弱于文档猫
            if (target.CardType == CardType.Phone)
            {
                var cardInfos = CardInfos.Create(); // 每回合数据
                tbsManager.GetCurrentRoundResult().Add(cardInfos);
                cardInfos.UnitCardInfos[target.PlayerId] = UnitCardInfo.Create();
                cardInfos.UnitCardInfos[me.PlayerId] = UnitCardInfo.Create();
                target.IsDie = true;
                cardInfos.UnitCardInfos[target.PlayerId].Info.Add((int)BattleResult.Die, (int)CardType.Phone);

            }
            else if (target.CardCategory == CardCategory.FunctionType)
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