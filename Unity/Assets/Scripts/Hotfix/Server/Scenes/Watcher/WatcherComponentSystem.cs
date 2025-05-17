namespace ET.Server
{
    [EntitySystemOf(typeof(WatcherComponent))]
    [FriendOf(typeof(WatcherComponent))]
    public static partial class WatcherComponentSystem
    {
        [EntitySystem]
        public static void Awake(this WatcherComponent self)
        {
            string[] localIP = NetworkHelper.GetAddressIPs();
            var processConfigs = StartProcessConfigCategory.Instance.DataMap;
            foreach (var startProcessConfig in processConfigs.Values)
            {
                if (!WatcherHelper.IsThisMachine(startProcessConfig.InnerIP, localIP))
                {
                    continue;
                }
                var process = WatcherHelper.StartProcess(startProcessConfig.Id);
                self.Processes.Add(startProcessConfig.Id, process);
            }
        }
    }
}