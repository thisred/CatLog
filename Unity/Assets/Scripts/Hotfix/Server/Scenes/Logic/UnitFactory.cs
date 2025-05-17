using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static async ETTask<Unit> LoadOrCreatePlayer(Scene scene, long roleId)
        {
            var unitComponent = scene.GetComponent<UnitComponent>();
            var unit = unitComponent.GetChild<Unit>(roleId);
            if (unit != null)
            {
                return unit;
            }

            unit = unitComponent.AddChildWithId<Unit>(roleId);
            var getPlayerCacheRequest = GetPlayerCacheRequest.Create();
            getPlayerCacheRequest.Zone = scene.Zone();
            getPlayerCacheRequest.RoleId = roleId;

            var response = (GetPlayerCacheResponse)await DataHelper.CallDataCache(scene, roleId, getPlayerCacheRequest);
            var cacheTypes = CodeTypes.Instance.GetCacheTypes();
            var dictionary = cacheTypes.ToDictionary(cacheType => cacheType.Name);
            foreach ((string key, byte[] value) in response.EntityMap)
            {
                dictionary.TryGetValue(key, out var type);
                var deserialize = (Entity)MongoHelper.Deserialize(type, value);
                unit.AddComponent(deserialize);
            }

            bool hasNewComponent = false;
            var entities = new Dictionary<string, Entity>();
            foreach (var cacheType in cacheTypes.Where(cacheType => unit.GetComponent(cacheType) == null))
            {
                var addComponent = unit.AddComponent(cacheType);
                entities.Add(cacheType.Name, addComponent);
                hasNewComponent = true;
            }

            if (hasNewComponent)
            {
                await DataHelper.Update(scene, roleId, entities);
            }

            return unit;
        }

        public static void Init(Unit unit)
        {
        }

        public static void SyncData(Unit unit)
        {
        }
    }
}