using System.Collections.Generic;

namespace ET.Client
{
    public struct SceneChangeStart
    {
    }

    public struct SceneChangeFinish
    {
    }

    public struct AfterCreateClientScene
    {
    }

    public struct AfterCreateCurrentScene
    {
    }

    public struct AppStartInitFinish
    {
    }

    public struct LoginFinish
    {
    }

    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }

    public struct MatchSuccess
    {
    }

    public struct GameRoomStart
    {
        public List<long> PlayerIds;
    }

    public struct EnterGameRound
    {
        public int Round;
        public int TurnCountdown;
        public Dictionary<long, int> Score;
    }

    public struct BattleResult
    {
        public long WinnerId;
    }

    public struct BattleRoundResult
    {
        public int Round;
        public List<int> left;
        public long leftId;
        public List<int> right;
        public long rightId;
        public List<CardInfos> CardInfos;
    }
}