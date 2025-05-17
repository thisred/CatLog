using System;
using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public static class TBSManagerSystem
    {
        public static void Init(this TBSManager self)
        {
            self.RoundInfos.Add(1, new RoundInfo());
            self.RoundInfos.Add(2, new RoundInfo());
            self.RoundInfos.Add(3, new RoundInfo());
            self.Dictionary.Add(1, new List<CardInfos>());
            self.Dictionary.Add(2, new List<CardInfos>());
            self.Dictionary.Add(3, new List<CardInfos>());
        }

        public static void SetPlayerInput(this TBSManager self, long playerId, PlayerRoundInput input)
        {
            var currentRound = self.GetCurrentRound();
            if (!currentRound.PlayerInputs.TryGetValue(playerId, out var playerInput))
            {
                playerInput = new PlayerRoundInput();
                currentRound.PlayerInputs.Add(playerId, playerInput);
            }

            foreach (var inputCard in input.Cards)
            {
                playerInput.Cards.Add(inputCard);
            }
        }

        public static void SetAnimationCompleted(this TBSManager self, long playerId)
        {
            var currentRound = self.GetCurrentRound();
            currentRound.AnimationComplete.Add(playerId);
        }

        public static bool CheckEveryOneAnimationCompleted(this TBSManager self)
        {
            return self.GetParent<TBSRoom>().GetComponent<TBSUnitComponent>().Children.Count == self.GetCurrentRound().AnimationComplete.Count;
        }

        public static TBSUnit GetPlayer(this TBSManager self, long playerId)
        {
            var tbsUnit = self.GetParent<TBSRoom>().GetComponent<TBSUnitComponent>().GetChild<TBSUnit>(playerId);
            return tbsUnit;
        }

        public static TBSEntity GetPlayeHeroCurrentRound(this TBSManager self, long playerId, CardType cardType)
        {
            var tbsUnitComponent = self.GetParent<TBSRoom>().GetComponent<TBSUnitComponent>();
            var tbsUnit = tbsUnitComponent.GetChild<TBSUnit>(playerId);
            if (!self.GetCurrentRound().PlayerInputs.GetValueOrDefault(playerId).Cards.Contains(cardType))
            {
                return null;
            }

            var tbsEntity = tbsUnit.GetComponent<TBSEntityComponent>().GetChild<TBSEntity>((long)cardType);
            return tbsEntity;
        }

        public static List<TBSEntity> GetPlayerHeros(this TBSManager self, long playerId)
        {
            var tbsUnit = self.GetParent<TBSRoom>().GetComponent<TBSUnitComponent>().GetChild<TBSUnit>(playerId);
            var tbsEntities = new List<TBSEntity>();
            foreach ((long key, Entity value) in tbsUnit.GetComponent<TBSEntityComponent>().Children)
            {
                TBSEntity tbsEntity = (TBSEntity)value;
                tbsEntities.Add(tbsEntity);
            }

            return tbsEntities;
        }

        /// <summary>
        /// 获取当前轮次信息
        /// </summary>
        public static RoundInfo GetCurrentRound(this TBSManager self)
        {
            return self.RoundInfos[self.Round];
        }

        /// <summary>
        /// 获取当前轮次结果
        /// </summary>
        public static List<CardInfos> GetCurrentRoundResult(this TBSManager self)
        {
            return self.Dictionary[self.Round];
        }

        /// <summary>
        /// 检查是否所有玩家都输入了
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool CheckEveryOneFinish(this TBSManager self)
        {
            var currentRound = self.GetCurrentRound();
            var tbsRoom = self.GetParent<TBSRoom>();
            foreach ((long key, var value) in tbsRoom.GetComponent<TBSUnitComponent>().Children)
            {
                if (!currentRound.PlayerInputs.TryGetValue(key, out _))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckGameEnd(this TBSManager self)
        {
            if (self.Round >= GameConst.MaxRound)
            {
                return true;
            }

            return false;
        }

        public static void AddScore(this TBSManager self, long playerId, int score = 1)
        {
            self.Score.TryGetValue(playerId, out int score1);
            self.Score[playerId] = score1 + score;
        }

        public static CardType GetRandomCardNonExistRound(this TBSManager self, long playerId)
        {
            var cardTypes = self.GetCurrentRound().PlayerInputs.GetValueOrDefault(playerId).Cards;
            var playerHeros = self.GetPlayerHeros(playerId);
            var types = new List<CardType>();
            foreach (var playerHero in playerHeros)
            {
                if (!cardTypes.Contains(playerHero.CardType))
                {
                    types.Add(playerHero.CardType);
                }
            }

            return RandomGenerator.RandomArray(types);
        }

        /// <summary>
        /// 玩家当前回合没有操作，随机选几个英雄
        /// </summary>
        /// <param name="self"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public static List<CardType> GetRandomCardIfPlayerNoInput(this TBSManager self, long playerId)
        {
            var playerHeros = self.GetPlayerHeros(playerId);
            var types = playerHeros.Select(playerHero => playerHero.CardType).ToList();
            int roundMaxNum = TBSSortHelper.GetRoundMaxNum(self.Round);
            RandomGenerator.BreakRank(types);
            var cardTypes = types.GetRange(0, roundMaxNum);
            return cardTypes;
        }
    }
}