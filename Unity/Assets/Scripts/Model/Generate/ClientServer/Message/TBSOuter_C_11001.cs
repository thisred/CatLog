using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(TBSOuter.C2G_Match)]
    [ResponseType(nameof(G2C_Match))]
    public partial class C2G_Match : MessageObject, ISessionRequest
    {
        public static C2G_Match Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_Match), isFromPool) as C2G_Match;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.G2C_Match)]
    public partial class G2C_Match : MessageObject, ISessionResponse
    {
        public static G2C_Match Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Match), isFromPool) as G2C_Match;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.C2G_CancelMatch)]
    [ResponseType(nameof(G2C_CancelMatch))]
    public partial class C2G_CancelMatch : MessageObject, ISessionRequest
    {
        public static C2G_CancelMatch Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_CancelMatch), isFromPool) as C2G_CancelMatch;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.G2C_CancelMatch)]
    public partial class G2C_CancelMatch : MessageObject, ISessionResponse
    {
        public static G2C_CancelMatch Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_CancelMatch), isFromPool) as G2C_CancelMatch;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    /// <summary>
    /// 匹配成功，通知客户端切换场景
    /// </summary>
    [MemoryPackable]
    [Message(TBSOuter.Match2G_NotifyMatchSuccess)]
    public partial class Match2G_NotifyMatchSuccess : MessageObject, IMessage
    {
        public static Match2G_NotifyMatchSuccess Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Match2G_NotifyMatchSuccess), isFromPool) as Match2G_NotifyMatchSuccess;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        /// <summary>
        /// 房间的ActorId
        /// </summary>
        [MemoryPackOrder(1)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    /// <summary>
    /// 客户端通知房间切换场景完成
    /// </summary>
    [MemoryPackable]
    [Message(TBSOuter.C2Room_ChangeSceneFinish)]
    public partial class C2Room_ChangeSceneFinish : MessageObject, IRoomMessage
    {
        public static C2Room_ChangeSceneFinish Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2Room_ChangeSceneFinish), isFromPool) as C2Room_ChangeSceneFinish;
        }

        [MemoryPackOrder(0)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.TBSUnitInfo)]
    public partial class TBSUnitInfo : MessageObject
    {
        public static TBSUnitInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TBSUnitInfo), isFromPool) as TBSUnitInfo;
        }

        [MemoryPackOrder(0)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    /// <summary>
    /// 房间通知客户端进入战斗
    /// </summary>
    [MemoryPackable]
    [Message(TBSOuter.Room2C_Start)]
    public partial class Room2C_Start : MessageObject, IMessage
    {
        public static Room2C_Start Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2C_Start), isFromPool) as Room2C_Start;
        }

        [MemoryPackOrder(0)]
        public long StartTime { get; set; }

        [MemoryPackOrder(1)]
        public List<TBSUnitInfo> UnitInfo { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.StartTime = default;
            this.UnitInfo.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.G2C_Reconnect)]
    public partial class G2C_Reconnect : MessageObject, IMessage
    {
        public static G2C_Reconnect Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Reconnect), isFromPool) as G2C_Reconnect;
        }

        /// <summary>
        /// 房间的ActorId
        /// </summary>
        [MemoryPackOrder(1)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 服务器通知客户端回合开始
    [MemoryPackable]
    [Message(TBSOuter.Room2C_RoundStart)]
    public partial class Room2C_RoundStart : MessageObject, IMessage
    {
        public static Room2C_RoundStart Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2C_RoundStart), isFromPool) as Room2C_RoundStart;
        }

        [MemoryPackOrder(0)]
        public int Round { get; set; }

        /// <summary>
        /// 回合倒计时，单位：秒
        /// </summary>
        [MemoryPackOrder(1)]
        public int TurnCountdown { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(2)]
        public Dictionary<long, int> Score { get; set; } = new();
        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Round = default;
            this.TurnCountdown = default;
            this.Score.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 客户端通知服务器开始战斗
    [MemoryPackable]
    [Message(TBSOuter.C2Room_StartBattle)]
    public partial class C2Room_StartBattle : MessageObject, IRoomMessage
    {
        public static C2Room_StartBattle Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2Room_StartBattle), isFromPool) as C2Room_StartBattle;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(1)]
        public List<int> CardId { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;
            this.CardId.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.UnitCardInfo)]
    public partial class UnitCardInfo : MessageObject
    {
        public static UnitCardInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnitCardInfo), isFromPool) as UnitCardInfo;
        }

        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(0)]
        public Dictionary<int, int> Info { get; set; } = new();
        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Info.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.CardInfos)]
    public partial class CardInfos : MessageObject
    {
        public static CardInfos Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(CardInfos), isFromPool) as CardInfos;
        }

        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(0)]
        public Dictionary<long, UnitCardInfo> UnitCardInfos { get; set; } = new();
        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitCardInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 服务器通知客户端当前回合结果
    [MemoryPackable]
    [Message(TBSOuter.Room2C_BattleRoundsResult)]
    public partial class Room2C_BattleRoundsResult : MessageObject, IMessage
    {
        public static Room2C_BattleRoundsResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2C_BattleRoundsResult), isFromPool) as Room2C_BattleRoundsResult;
        }

        [MemoryPackOrder(0)]
        public int Round { get; set; }

        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(1)]
        public Dictionary<long, SelectInfo> SelectInfos { get; set; } = new();
        [MemoryPackOrder(2)]
        public List<CardInfos> Infos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Round = default;
            this.SelectInfos.Clear();
            this.Infos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.SelectInfo)]
    public partial class SelectInfo : MessageObject
    {
        public static SelectInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(SelectInfo), isFromPool) as SelectInfo;
        }

        [MemoryPackOrder(0)]
        public List<int> HeroIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.HeroIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 客户端播放动画完成
    [MemoryPackable]
    [Message(TBSOuter.C2Room_AnimationComplete)]
    public partial class C2Room_AnimationComplete : MessageObject, IRoomMessage
    {
        public static C2Room_AnimationComplete Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2Room_AnimationComplete), isFromPool) as C2Room_AnimationComplete;
        }

        [MemoryPackOrder(0)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(TBSOuter.Room2C_BattleResult)]
    public partial class Room2C_BattleResult : MessageObject, IMessage
    {
        public static Room2C_BattleResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2C_BattleResult), isFromPool) as Room2C_BattleResult;
        }

        [MemoryPackOrder(0)]
        public long WinPlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.WinPlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static class TBSOuter
    {
        public const ushort C2G_Match = 11002;
        public const ushort G2C_Match = 11003;
        public const ushort C2G_CancelMatch = 11004;
        public const ushort G2C_CancelMatch = 11005;
        public const ushort Match2G_NotifyMatchSuccess = 11006;
        public const ushort C2Room_ChangeSceneFinish = 11007;
        public const ushort TBSUnitInfo = 11008;
        public const ushort Room2C_Start = 11009;
        public const ushort G2C_Reconnect = 11010;
        public const ushort Room2C_RoundStart = 11011;
        public const ushort C2Room_StartBattle = 11012;
        public const ushort UnitCardInfo = 11013;
        public const ushort CardInfos = 11014;
        public const ushort Room2C_BattleRoundsResult = 11015;
        public const ushort SelectInfo = 11016;
        public const ushort C2Room_AnimationComplete = 11017;
        public const ushort Room2C_BattleResult = 11018;
    }
}