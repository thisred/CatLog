using System;

namespace ET.Server
{
    public static partial class TBSUnitFactory
    {
        public static TBSUnit Init(TBSRoom room, TBSUnitInfo info)
        {
            var tbsUnitComponent = room.GetComponent<TBSUnitComponent>();
            var tbsUnit = tbsUnitComponent.AddChildWithId<TBSUnit>(info.PlayerId);
            var tbsEntityComponent = tbsUnit.AddComponent<TBSEntityComponent>();
            foreach (object enumValue in typeof(CardType).GetEnumValues())
            {
                var cardType = (CardType)enumValue;
                if (cardType == CardType.None)
                {
                    continue;
                }

                var tbsEntity = tbsEntityComponent.AddChildWithId<TBSEntity>((int)cardType);
                tbsEntity.CardType = cardType;
                tbsEntity.PlayerId = info.PlayerId;
                var component = tbsEntity.AddComponent<TBSAbilityComponent>();
                switch (cardType)
                {
                    case CardType.None:
                        break;
                    case CardType.Document:
                        tbsEntity.CardCategory = CardCategory.ConstraintType;
                        component.AddChild<DocumentAbility>();
                        break;
                    case CardType.Phone:
                        tbsEntity.CardCategory = CardCategory.ConstraintType;

                        component.AddChild<PhoneAbility>();
                        break;
                    case CardType.Game:
                        tbsEntity.CardCategory = CardCategory.ConstraintType;

                        component.AddChild<GameAbility>();
                        break;
                    case CardType.Toilet:
                        tbsEntity.CardCategory = CardCategory.FunctionType;

                        component.AddChild<ToiletAbility>();
                        break;
                    case CardType.Traffic:
                        component.AddChild<TrafficAbility>();
                        tbsEntity.CardCategory = CardCategory.FunctionType;

                        break;
                    case CardType.Roadblock:
                        component.AddChild<RoadblockAbility>();
                        tbsEntity.CardCategory = CardCategory.FunctionType;

                        break;
                    case CardType.Glass:
                        component.AddChild<GlassAbility>();
                        tbsEntity.CardCategory = CardCategory.FunctionType;

                        break;
                    case CardType.RemoteCtrl:
                        component.AddChild<RemoteCtrlAbility>();
                        tbsEntity.CardCategory = CardCategory.FunctionType;

                        break;
                    case CardType.Shrimp:
                        component.AddChild<ShrimpAbility>();
                        tbsEntity.CardCategory = CardCategory.FunctionType;

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return tbsUnit;
        }
    }
}