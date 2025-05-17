using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class DataCacheComponent : Entity, IAwake
    {
        /// <summary>
        /// collectionName => collectionName
        /// </summary>
        public Dictionary<string, Collection> Collections = new();
    }

    public class Collection
    {
        /// <summary>
        /// id => entity
        /// </summary>
        public Dictionary<long, EntityRef<Entity>> Rows = new();
    }
}