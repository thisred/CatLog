namespace ET.Client
{
    public static class LoginHelper
    {
        public static async ETTask Login(Scene root, string account, string password)
        {
            var clientSenderComponent = root.GetComponent<ClientSenderComponent>();
            if (clientSenderComponent != null)
            {
                await clientSenderComponent.DisposeAsync();
            }

            clientSenderComponent = root.AddComponent<ClientSenderComponent>();

            long playerId = await clientSenderComponent.LoginAsync(account, password);

            root.GetComponent<PlayerComponent>().MyId = playerId;

            GameRoot.Instance.scene = root;
            
            
            await EventSystem.Instance.PublishAsync(root, new LoginFinish());
        }
    }
}