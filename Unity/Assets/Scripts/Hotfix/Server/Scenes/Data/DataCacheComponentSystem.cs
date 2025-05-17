using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(DataCacheComponent))]
    public static class DataCacheComponentSystem
    {
        public static async ETTask<Dictionary<string, Entity>> QueryById(this DataCacheComponent self, int zone, List<string> dbNames, long id)
        {
            if (dbNames == null || dbNames.Count == 0)
            {
                var cacheTypes = CodeTypes.Instance.GetCacheTypes();
                dbNames = cacheTypes.Select(cacheType => cacheType.Name).ToList();
            }

            var entities = new Dictionary<string, Entity>();
            foreach (string dbName in dbNames)
            {
                var entity = self.GetCache(dbName, id);
                entities.Add(dbName, entity);
            }

            dbNames.RemoveAll(dbName => entities.ContainsKey(dbName));
            await self.Scene().GetComponent<DBManagerComponent>().GetZoneDB(zone).Query(id, dbNames, entities);

            foreach (string dbName in dbNames)
            {
                if (entities.TryGetValue(dbName, out Entity entity))
                {
                    self.AddCache(dbName, entity);
                }
            }

            return entities;
        }

        public static async ETTask<Entity> QueryById(this DataCacheComponent self, int zone, string collectionName, long id)
        {
            var entity = self.GetCache(collectionName, id);
            if (entity != null)
            {
                return entity;
            }

            var query = await self.Scene().GetComponent<DBManagerComponent>().GetZoneDB(zone).Query(id, collectionName);
            return query;
        }

        public static async ETTask AddOrUpdate(this DataCacheComponent self, int zone, long id, Dictionary<string, Entity> entitys)
        {
            foreach (var entity in entitys)
            {
                self.AddCache(entity.Key, entity.Value);
            }

            await self.Scene().GetComponent<DBManagerComponent>().GetZoneDB(zone).Save(id, entitys.Values.ToList());
        }

        public static async ETTask AddOrUpdate(this DataCacheComponent self, int zone, string collectionName, Entity entity)
        {
            self.AddCache(collectionName, entity);
            await self.Scene().GetComponent<DBManagerComponent>().GetZoneDB(zone).Save(entity);
        }

        private static void AddCache(this DataCacheComponent self, string collectionName, Entity entity)
        {
            if (!self.Collections.TryGetValue(collectionName, out var collection))
            {
                self.Collections.Add(collectionName, collection = new Collection());
            }

            collection.Rows[entity.Id] = entity;
        }

        private static Entity GetCache(this DataCacheComponent self, string collectionName, long id)
        {
            if (!self.Collections.TryGetValue(collectionName, out var collection))
            {
                return null;
            }

            if (collection.Rows.TryGetValue(id, out var value))
            {
                return value;
            }

            return null;
        }
    }
}