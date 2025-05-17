namespace ET
{
    [ChildOf]
    public class PhoneAbility : Entity, IAwake, IAbility
    {
        public void DealDamage(TBSEntity me, TBSEntity target)
        {
            var tbsManager = me.Root().GetComponent<TBSRoom>().GetComponent<TBSManager>();

            // 强于文档猫，弱于游戏猫
            if (target.CardType == CardType.Document)
            {
                var cardInfos = CardInfos.Create(); // 每回合数据
                tbsManager.GetCurrentRoundResult().Add(cardInfos);
                cardInfos.UnitCardInfos[target.PlayerId] = UnitCardInfo.Create();
                cardInfos.UnitCardInfos[me.PlayerId] = UnitCardInfo.Create();

                target.IsDie = true;
                cardInfos.UnitCardInfos[target.PlayerId].Info.Add((int)BattleResult.Die, (int)CardType.Document);
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