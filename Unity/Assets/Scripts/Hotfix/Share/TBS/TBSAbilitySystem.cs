namespace ET
{
    public static class TBSAbilitySystem
    {
        public static void Execute(this TBSAbilityComponent self, TBSEntity first, TBSEntity second)
        {
            if (first.IsDie)
            {
                return;
            }

            foreach ((long key, var value) in self.Children)
            {
                var ability = (IAbility)value;
                ability.DealDamage(first, second);
            }
        }

        public static void ExecuteEx(this TBSAbilityComponent self, TBSEntity first, TBSEntity second)
        {
            if (first.IsDie || second.IsDie)
            {
                return;
            }

            var tbsManager = self.Root().GetComponent<TBSRoom>().GetComponent<TBSManager>();
            var cardInfos = CardInfos.Create(); // 每回合数据
            tbsManager.GetCurrentRoundResult().Add(cardInfos);
            cardInfos.UnitCardInfos[first.PlayerId] = UnitCardInfo.Create();
            cardInfos.UnitCardInfos[second.PlayerId] = UnitCardInfo.Create();

            if (first.CardType == second.CardType)
            {
                first.IsDie = true;
                second.IsDie = true;
                cardInfos.UnitCardInfos[first.PlayerId].Info.Add((int)BattleResult.Die, (int)first.CardType);
                cardInfos.UnitCardInfos[second.PlayerId].Info.Add((int)BattleResult.Die, (int)second.CardType);
            }

            if (first.IsDie || second.IsDie)
            {
                return;
            }

            if (first.CardCategory == CardCategory.FunctionType && second.CardCategory == CardCategory.FunctionType)
            {
                first.IsDie = true;
                second.IsDie = true;
                cardInfos.UnitCardInfos[first.PlayerId].Info.Add((int)BattleResult.Die, (int)first.CardType);
                cardInfos.UnitCardInfos[second.PlayerId].Info.Add((int)BattleResult.Die, (int)second.CardType);
            }
        }
    }
}