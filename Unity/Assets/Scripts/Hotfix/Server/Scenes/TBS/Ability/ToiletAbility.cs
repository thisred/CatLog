namespace ET
{
    /// <summary>
    /// 随机挑选一个对面的敌人吸进马桶里
    /// 如敌方有啤酒猫，首选吸啤酒猫，如果没有则随机吸，很可能吸走对方一个很强的，也有可能把最弱的吸走了
    /// </summary>
    [ChildOf]
    public class ToiletAbility : Entity, IAwake, IAbility
    {
        public void DealDamage(TBSEntity me, TBSEntity target)
        {
            var tbsManager = me.Root().GetComponent<TBSRoom>().GetComponent<TBSManager>();

            var playerHero = tbsManager.GetPlayeHeroCurrentRound(target.PlayerId, CardType.Glass);
            if (playerHero != null)
            {
                var cardInfos = CardInfos.Create(); // 每回合数据
                tbsManager.GetCurrentRoundResult().Add(cardInfos);
                cardInfos.UnitCardInfos[target.PlayerId] = UnitCardInfo.Create();
                cardInfos.UnitCardInfos[me.PlayerId] = UnitCardInfo.Create();

                playerHero.IsDie = true;
                cardInfos.UnitCardInfos[target.PlayerId].Info.Add((int) BattleResult.Drown, (int) CardType.Glass);
            }
            else
            {
                var cardInfos = CardInfos.Create(); // 每回合数据
                tbsManager.GetCurrentRoundResult().Add(cardInfos);
                cardInfos.UnitCardInfos[target.PlayerId] = UnitCardInfo.Create();
                cardInfos.UnitCardInfos[me.PlayerId] = UnitCardInfo.Create();

                var playerHeros = tbsManager.GetPlayerHeros(target.PlayerId);
                var entity = RandomGenerator.RandomArray(playerHeros);
                entity.IsDie = true;
                cardInfos.UnitCardInfos[target.PlayerId].Info.Add((int) BattleResult.Drown, (int) entity.CardType);
            }
        }
    }
}