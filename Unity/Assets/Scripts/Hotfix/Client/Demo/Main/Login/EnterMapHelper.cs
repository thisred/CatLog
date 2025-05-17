using System;


namespace ET.Client
{
    public static partial class EnterMapHelper
    {
        public static async ETTask Match(Fiber fiber, ETCancellationToken token)
        {
            try
            {
                await ETTask.CompletedTask;
                var g2CEnterMap = await fiber.Root.GetComponent<ClientSenderComponent>().Call(C2G_Match.Create()) as G2C_Match;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }	
        }
    }
}