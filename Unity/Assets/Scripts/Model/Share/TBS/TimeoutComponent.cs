namespace ET
{
    [ComponentOf(typeof(TBSRoom))]
    public class TimeoutComponent : Entity, IAwake
    {
        /// <summary>
        /// 记录超时时间
        /// </summary>
        public float Time;
    }
}