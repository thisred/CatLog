namespace ET
{
    /// <summary>
    /// 出现的时候会随机亮灯，红灯停（冻结对方一回合）并直接胜出，绿灯行（绿灯时对方能攻击）
    /// </summary>
    [ChildOf]
    public class TrafficAbility : Entity, IAbility, IAwake
    {
        public void DealDamage(TBSEntity me, TBSEntity target)
        {
            var tbsManager = me.Root().GetComponent<TBSRoom>().GetComponent<TBSManager>();

            bool kill = RandomGenerator.RandomBool();
            if (kill)
            {
                var cardInfos = CardInfos.Create(); // 每回合数据
                tbsManager.GetCurrentRoundResult().Add(cardInfos);
                cardInfos.UnitCardInfos[target.PlayerId] = UnitCardInfo.Create();
                cardInfos.UnitCardInfos[me.PlayerId] = UnitCardInfo.Create();

                target.IsDie = true;
                cardInfos.UnitCardInfos[target.PlayerId].Info.Add((int) BattleResult.Die, (int) target.CardType);
            }
        }
    }
}