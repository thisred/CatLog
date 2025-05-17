namespace ET
{
    public struct EntryEvent1
    {
    }   
    
    public struct EntryEvent2
    {
    } 
    
    public struct EntryEvent3
    {
    }
    
    public static class Entry
    {
        public static void Init()
        {
            
        }
        
        public static void Start()
        {
            StartAsync().Coroutine();
        }
        
        private static async ETTask StartAsync()
        {
            WinPeriod.Init();

            // 注册Mongo type
            MongoRegister.Init();
            // 注册Entity序列化器
            EntitySerializeRegister.Init();
            GameRoot.Instance.AddSingleton<IdGenerater>();
            GameRoot.Instance.AddSingleton<OpcodeType>();
            GameRoot.Instance.AddSingleton<ObjectPool>();
            GameRoot.Instance.AddSingleton<MessageQueue>();
            GameRoot.Instance.AddSingleton<NetServices>();
            GameRoot.Instance.AddSingleton<NavmeshComponent>();
            GameRoot.Instance.AddSingleton<LogMsg>();
            
            // 创建需要reload的code singleton
            CodeTypes.Instance.CreateCode();
            
            await GameRoot.Instance.AddSingleton<ConfigLoader>().LoadAsync();

            await FiberManager.Instance.Create(SchedulerType.Main, ConstFiberId.Main, 0, SceneType.Main, "");
        }
    }
}