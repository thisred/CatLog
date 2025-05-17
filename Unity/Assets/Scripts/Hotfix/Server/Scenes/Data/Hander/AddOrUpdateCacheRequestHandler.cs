using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.DataCache)]
    public class AddOrUpdateCacheRequestHandler : MessageHandler<Scene, AddOrUpdateCacheRequest, AddOrUpdateCacheResponse>
    {
        protected override async ETTask Run(Scene scene, AddOrUpdateCacheRequest request, AddOrUpdateCacheResponse response)
        {
            var entities = new Dictionary<string, Entity>();
            foreach ((string key, byte[] value) in request.EntityMap)
            {
                var entity = MongoHelper.Deserialize<Entity>(value);
                entities.Add(key, entity);
            }

            await scene.GetComponent<DataCacheComponent>().AddOrUpdate(request.Zone, request.RoleId, entities);
        }
    }
}