using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.NewWorld.QuestGame
{
    public class QuestDailyComponent : Entity, IAwake
    {
        /// <summary>
        /// 每日任务的刷新时间
        /// </summary>
        public long DailyRefreshTime = 0;

        /// <summary>
        /// 每周任务的刷新时间
        /// </summary>
        public long WeeklyRefreshTime = 0;

        /// <summary>
        /// 领取过的活跃度宝箱id
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, HashSet<int>> ClaimedLiveness = new();
    }
}