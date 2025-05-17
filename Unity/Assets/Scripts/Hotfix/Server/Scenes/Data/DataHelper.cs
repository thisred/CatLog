using System.Collections.Generic;

namespace ET.Server
{
    public static class DataHelper
    {
        public static async ETTask Update(Scene scene, long roleId, Dictionary<string, Entity> entities)
        {
            var addOrUpdateCacheRequest = AddOrUpdateCacheRequest.Create();
            addOrUpdateCacheRequest.Zone = scene.Zone();
            addOrUpdateCacheRequest.RoleId = roleId;
            foreach ((string key, var value) in entities)
            {
                addOrUpdateCacheRequest.EntityMap.Add(key, MongoHelper.Serialize(value));
            }

            await CallDataCache(scene, roleId, addOrUpdateCacheRequest);
        }

        public static async ETTask<IResponse> CallDataCache(Scene scene, long roleId, IRequest request)
        {
            ulong hash = (ulong)roleId.GetHashCode();
            var dataCaches = StartSceneConfigCategory.Instance.DataCaches;
            var sceneConfig = dataCaches[(int)(hash % (ulong)dataCaches.Count)];
            var response = await scene.GetComponent<MessageSender>().Call(sceneConfig.ActorId, request);
            return response;
        }
    }
}