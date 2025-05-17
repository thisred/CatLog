namespace ET
{
    /// <summary>
    /// 游戏房间
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class TBSRoom : Entity, IScene, IAwake, IUpdate
    {
        public Fiber Fiber { get; set; }
        public SceneType SceneType { get; set; } = SceneType.Room;
        public int AuthorityFrame { get; set; }
        public long StartTime { get; set; }
        public FixedTimeCounter FixedTimeCounter { get; set; }
    }
}