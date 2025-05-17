using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    /// <summary>
    /// 回合开始
    /// </summary>
    [TBSState]
    [FriendOfAttribute(typeof(ET.TimeoutComponent))]
    public class TurnStartState : ITBSState
    {
        public void Enter(TBSRoom room)
        {
            var tbsManager = room.GetComponent<TBSManager>();
            if (tbsManager.CheckGameEnd())
            {
                // 进入结算,关闭房间
                var result = Room2C_BattleResult.Create();
                int player1Score = tbsManager.Score.GetValueOrDefault(tbsManager.PlayerId1);
                int player2Score = tbsManager.Score.GetValueOrDefault(tbsManager.PlayerId2);
                if (player1Score > player2Score)
                {
                    result.WinPlayerId = tbsManager.PlayerId1;
                }
                else if (player1Score < player2Score)
                {
                    result.WinPlayerId = tbsManager.PlayerId2;
                }
                else if (player1Score == player2Score)
                {
                    result.WinPlayerId = 0;
                }

                RoomMessageHelper.BroadCast(room, result);

                var room2GRoomDispose = Room2G_RoomDispose.Create();
                room2GRoomDispose.PlayerIds.Add(tbsManager.PlayerId1);
                room2GRoomDispose.PlayerIds.Add(tbsManager.PlayerId2);
                var gate = StartSceneConfigCategory.Instance.Gates[1][0]; // 临时写法
                room.Fiber().Root.GetComponent<MessageSender>().Send(gate.ActorId, room2GRoomDispose);

                return;
            }
            else
            {
                var room2CRoundStart = Room2C_RoundStart.Create();
                tbsManager.Round += 1;
                room2CRoundStart.Round = tbsManager.Round;
                room2CRoundStart.TurnCountdown = GameConst.MaxRoundWait / 1000;
                foreach (var pair in tbsManager.Score)
                {
                    room2CRoundStart.Score.Add(pair.Key, pair.Value);
                }

                RoomMessageHelper.BroadCast(room, room2CRoundStart);
            }

            room.GetComponent<TBSStateMachine>().ChangeState(TBSState.PreparationPhase);
        }

        public void Execute(TBSRoom room)
        {
        }

        public void Exit(TBSRoom room)
        {
            room.GetComponent<TimeoutComponent>().Time = 0;
        }

        public void Update(TBSRoom room, float deltaTime)
        {
            var tbsManager = room.GetComponent<TBSManager>();
            if (tbsManager.CheckGameEnd())
            {
                var timeoutComponent = room.GetComponent<TimeoutComponent>();
                timeoutComponent.Time += deltaTime;
                if (timeoutComponent.Time > GameConst.MaxRoundWait)
                {
                    // 销毁房间
                    room.Dispose();
                }
            }
        }
    }

    /// <summary>
    /// 准备阶段，当超时后 或者 收到所有玩家协议后 直接进入战斗阶段
    /// </summary>
    [TBSState]
    [FriendOfAttribute(typeof(ET.TimeoutComponent))]
    public class PreparationPhaseState : ITBSState
    {
        public void Enter(TBSRoom room)
        {
            TBSManager tbsManager = room.GetComponent<TBSManager>();
            foreach (TBSEntity playerHero in tbsManager.GetPlayerHeros(tbsManager.PlayerId1))
            {
                playerHero.IsDie = false;
            }

            foreach (TBSEntity playerHero in tbsManager.GetPlayerHeros(tbsManager.PlayerId2))
            {
                playerHero.IsDie = false;
            }
        }

        public void Execute(TBSRoom room)
        {
        }

        public void Exit(TBSRoom room)
        {
            room.GetComponent<TimeoutComponent>().Time = 0;
        }

        public void Update(TBSRoom room, float deltaTime)
        {
            // 超时后直接进入战斗阶段
            var timeoutComponent = room.GetComponent<TimeoutComponent>();
            timeoutComponent.Time += deltaTime;
            var tbsManager = room.GetComponent<TBSManager>();
            if (tbsManager.CheckEveryOneFinish()) // 所有玩家输入完成，直接进入战斗阶段
            {
                room.GetComponent<TBSStateMachine>().ChangeState(TBSState.CombatPhase);
                return;
            }

            if (timeoutComponent.Time > GameConst.MaxRoundWait)
            {
                timeoutComponent.Time = 0;
                // 有玩家没输入，给默认操作
                var currentRound = tbsManager.GetCurrentRound();
                if (!currentRound.PlayerInputs.TryGetValue(tbsManager.PlayerId1, out var input))
                {
                    input = new PlayerRoundInput();
                    currentRound.PlayerInputs[tbsManager.PlayerId1] = input;
                    input.Cards.AddRange(tbsManager.GetRandomCardIfPlayerNoInput(tbsManager.PlayerId1));
                }

                if (!currentRound.PlayerInputs.TryGetValue(tbsManager.PlayerId2, out input))
                {
                    input = new PlayerRoundInput();
                    currentRound.PlayerInputs[tbsManager.PlayerId2] = input;
                    input.Cards.AddRange(tbsManager.GetRandomCardIfPlayerNoInput(tbsManager.PlayerId2));
                }

                room.GetComponent<TBSStateMachine>().ChangeState(TBSState.CombatPhase);
            }
        }
    }

    /// <summary>
    /// 计算玩家技能伤害，计算伤害，应用buff等。
    /// </summary>
    [TBSState]
    [FriendOfAttribute(typeof(ET.TimeoutComponent))]
    public class CombatPhaseState : ITBSState
    {
        public void Enter(TBSRoom room)
        {
            try
            {
                Execute(room);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            room.GetComponent<TBSStateMachine>().ChangeState(TBSState.TurnEnd);
        }

        public void Execute(TBSRoom room)
        {
            var tbsManager = room.GetComponent<TBSManager>();
            var currentRound = tbsManager.GetCurrentRound();

            var queue1 = new Queue<ActionUnit>();
            var queue2 = new Queue<ActionUnit>();
            var player1Input = currentRound.PlayerInputs.GetValueOrDefault(tbsManager.PlayerId1);
            var player2Input = currentRound.PlayerInputs.GetValueOrDefault(tbsManager.PlayerId2);
            foreach (var cardType in player1Input.Cards)
            {
                queue1.Enqueue(new ActionUnit() { CardType = cardType, PlayerId = tbsManager.PlayerId1 });
            }

            foreach (var cardType in player2Input.Cards)
            {
                queue2.Enqueue(new ActionUnit() { CardType = cardType, PlayerId = tbsManager.PlayerId2 });
            }

            while (queue1.Count > 0 || queue2.Count > 0)
            {
                queue1.TryPeek(out ActionUnit actionUnit1);
                queue2.TryPeek(out ActionUnit actionUnit2);
                // 对方无英雄
                if (actionUnit1 == null || actionUnit2 == null)
                {
                    if (actionUnit1 != null)
                    {
                        tbsManager.AddScore(tbsManager.PlayerId1);
                        queue1.Dequeue();
                    }
                    else if (actionUnit2 != null)
                    {
                        tbsManager.AddScore(tbsManager.PlayerId2);
                        queue2.Dequeue();
                    }

                    continue;
                }

                // 排序，技能优先级，执行技能
                var actionUnits = new List<ActionUnit>() { actionUnit1, actionUnit2 };
                actionUnits.Sort((unit1, unit2) => unit1.CardType.GetSpeed().CompareTo(unit2.CardType.GetSpeed()));
                int compareTo = actionUnit1.CardType.GetSpeed().CompareTo(actionUnit2.CardType.GetSpeed());
                if (compareTo == 0) // 随机顺序
                {
                    RandomGenerator.BreakRank(actionUnits);
                }

                var firstUnit = actionUnits[0];
                var secondUnit = actionUnits[1];
                var tbsEntity1 = tbsManager.GetPlayeHeroCurrentRound(firstUnit.PlayerId, firstUnit.CardType);
                var tbsEntity2 = tbsManager.GetPlayeHeroCurrentRound(secondUnit.PlayerId, secondUnit.CardType);
                tbsEntity1.GetComponent<TBSAbilityComponent>().Execute(tbsEntity1, tbsEntity2);
                tbsEntity2.GetComponent<TBSAbilityComponent>().Execute(tbsEntity2, tbsEntity1);

                tbsEntity2.GetComponent<TBSAbilityComponent>().ExecuteEx(tbsEntity2, tbsEntity1);
                tbsEntity2.GetComponent<TBSAbilityComponent>().ExecuteEx(tbsEntity2, tbsEntity1);

                if (tbsEntity1.IsDie)
                {
                    queue1.Dequeue();
                }

                if (tbsEntity2.IsDie)
                {
                    queue2.Dequeue();
                }

                foreach (var tbsManagerSpawnCard in tbsManager.SpawnCards)
                {
                    if (tbsManagerSpawnCard.Key == tbsManager.PlayerId1)
                    {
                        var list = queue1.ToList();
                        list.Add(new ActionUnit() { CardType = tbsManagerSpawnCard.Value, PlayerId = tbsManager.PlayerId1 });
                        queue1 = new Queue<ActionUnit>(list);
                    }
                    else if (tbsManagerSpawnCard.Key == tbsManager.PlayerId2)
                    {
                        var list = queue2.ToList();
                        list.Add(new ActionUnit() { CardType = tbsManagerSpawnCard.Value, PlayerId = tbsManager.PlayerId2 });
                        queue2 = new Queue<ActionUnit>(list);
                    }
                }

                tbsManager.SpawnCards.Clear();
            }
        }

        public void Exit(TBSRoom room)
        {
            room.GetComponent<TimeoutComponent>().Time = 0;

            var result = Room2C_BattleRoundsResult.Create(); // 通知客户端的结果
            var tbsManager = room.GetComponent<TBSManager>();
            var currentRoundResult = tbsManager.GetCurrentRoundResult();
            var currentRound = tbsManager.GetCurrentRound();
            foreach ((long key, var value) in currentRound.PlayerInputs)
            {
                var selectInfo = SelectInfo.Create();
                foreach (var cardType in value.Cards)
                {
                    selectInfo.HeroIds.Add((int)cardType);
                }

                result.SelectInfos.Add(key, selectInfo);
            }

            result.Infos.AddRange(currentRoundResult);
            result.Round = tbsManager.Round;
            RoomMessageHelper.BroadCast(room, result);
        }

        public void Update(TBSRoom room, float deltaTime)
        {
            var timeoutComponent = room.GetComponent<TimeoutComponent>();
            timeoutComponent.Time += deltaTime;
            if (timeoutComponent.Time > GameConst.MaxRoundWait)
            {
                timeoutComponent.Time = 0;
                room.GetComponent<TBSStateMachine>().ChangeState(TBSState.TurnEnd);
            }
        }
    }

    /// <summary>
    /// 回合结束，判断战斗结果，结束当前回合，进入下一个回合或是结束游戏
    /// </summary>
    [TBSState]
    [FriendOfAttribute(typeof(ET.TimeoutComponent))]
    public class TurnEndState : ITBSState
    {
        public void Enter(TBSRoom room)
        {
        }

        public void Execute(TBSRoom room)
        {
        }

        public void Exit(TBSRoom room)
        {
            room.GetComponent<TimeoutComponent>().Time = 0;
        }

        public void Update(TBSRoom room, float deltaTime)
        {
            var tbsManager = room.GetComponent<TBSManager>();
            // 等待客户端播放动画完成
            var timeoutComponent = room.GetComponent<TimeoutComponent>();
            timeoutComponent.Time += deltaTime;
            int waitTime = GameConst.MaxRoundWait;
            if (tbsManager.CheckGameEnd())
            {
                waitTime = GameConst.EndRoundWait;
            }

            if (timeoutComponent.Time > waitTime)
            {
                timeoutComponent.Time = 0;
                room.GetComponent<TBSStateMachine>().ChangeState(TBSState.TurnStart);
            }

            if (tbsManager.CheckEveryOneAnimationCompleted())
            {
                room.GetComponent<TBSStateMachine>().ChangeState(TBSState.TurnStart);
            }
        }
    }
}