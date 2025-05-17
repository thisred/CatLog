using System;

namespace ET
{
    public static class TBSSortHelper
    {
        public static int GetSpeed(this CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Document:
                case CardType.Phone:
                case CardType.Game:
                    return 1;
                case CardType.Toilet:
                    return 99;
                case CardType.Traffic:
                    return 97;
                case CardType.Roadblock:
                    return 98;
                case CardType.Glass:
                    return 96;
                case CardType.RemoteCtrl:
                    return 100;
                case CardType.Shrimp:
                    return 95;
                case CardType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(cardType), cardType, null);
            }
        }

        public static int GetRoundMaxNum(int round)
        {
            return round switch
            {
                1 => 1,
                2 => 3,
                3 => 5,
                _ => 0
            };
        }
    }
}