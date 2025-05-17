namespace ET
{
    [ChildOf]
    public class GlassAbility : Entity, IAbility, IAwake
    {
        public void DealDamage(TBSEntity me, TBSEntity target)
        {
            var tbsManager = me.Root().GetComponent<TBSRoom>().GetComponent<TBSManager>();

            if (target.CardType == CardType.Glass)
            {
                var cardInfos = CardInfos.Create(); // 每回合数据
                tbsManager.GetCurrentRoundResult().Add(cardInfos);
                cardInfos.UnitCardInfos[target.PlayerId] = UnitCardInfo.Create();
                cardInfos.UnitCardInfos[me.PlayerId] = UnitCardInfo.Create();

                target.IsDie = true;
                cardInfos.UnitCardInfos[target.PlayerId].Info.Add((int)BattleResult.Die, (int)target.CardType);
                var type = tbsManager.GetRandomCardNonExistRound(target.PlayerId);
                cardInfos.UnitCardInfos[target.PlayerId].Info.Add((int)BattleResult.Add, (int)type);
                tbsManager.SpawnCards[target.PlayerId] = type;

                me.IsDie = true;
                cardInfos.UnitCardInfos[me.PlayerId].Info.Add((int)BattleResult.Die, (int)me.CardType);
                var type1 = tbsManager.GetRandomCardNonExistRound(me.PlayerId);
                cardInfos.UnitCardInfos[me.PlayerId].Info.Add((int)BattleResult.Add, (int)type1);
                tbsManager.SpawnCards[me.PlayerId] = type1;
            }
        }
    }
}