namespace ET
{
    public static class GameConst
    {
        /// <summary>
        /// 匹配人数
        /// </summary>
        public const int MatchCount = 2;

        /// <summary>
        /// 更新间隔，毫秒
        /// </summary>
        public const int UpdateInterval = 50;

        /// <summary>
        /// 每秒帧数
        /// </summary>
        public const int FrameCountPerSecond = 1000 / UpdateInterval;

        /// <summary>
        /// 最大等待时间
        /// </summary>
        public const int MaxRoundWait = 30_000;
        /// <summary>
        /// 结束回合等待时间，设置个大一点儿的保证客户端播放完
        /// </summary>
        public const int EndRoundWait = 60_000;

        /// <summary>
        /// 最大回合数
        /// </summary>
        public const int MaxRound = 3;
    }
}