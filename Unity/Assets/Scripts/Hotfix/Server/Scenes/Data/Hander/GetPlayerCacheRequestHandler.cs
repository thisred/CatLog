namespace ET.Server
{
    [MessageHandler(SceneType.DataCache)]
    public class GetPlayerCacheRequestHandler : MessageHandler<Scene, GetPlayerCacheRequest, GetPlayerCacheResponse>
    {
        protected override async ETTask Run(Scene scene, GetPlayerCacheRequest request, GetPlayerCacheResponse response)
        {
            await scene.GetComponent<DataCacheComponent>().QueryById(request.Zone, request.DBNames, request.RoleId);
        }
    }
}