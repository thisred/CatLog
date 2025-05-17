/// <summary>
/// 固定时间计数器类，用于计算和管理基于固定时间间隔的帧计数。
/// </summary>
namespace ET
{
    public class FixedTimeCounter
    {
        private long startTime; // 开始时间
        private int startFrame; // 开始帧数
        public int Interval { get; private set; } // 固定时间间隔

        /// <summary>
        /// 构造函数，初始化固定时间计数器。
        /// </summary>
        /// <param name="startTime">开始时间。</param>
        /// <param name="startFrame">开始帧数。</param>
        /// <param name="interval">固定时间间隔。</param>
        public FixedTimeCounter(long startTime, int startFrame, int interval)
        {
            this.startTime = startTime;
            this.startFrame = startFrame;
            this.Interval = interval;
        }
        
        /// <summary>
        /// 更改时间间隔，并重新设定开始帧数和时间。
        /// </summary>
        /// <param name="interval">新的时间间隔。</param>
        /// <param name="frame">当前帧数，用于计算新的开始时间。</param>
        public void ChangeInterval(int interval, int frame)
        {
            this.startTime += (frame - this.startFrame) * this.Interval;
            this.startFrame = frame;
            this.Interval = interval;
        }

        /// <summary>
        /// 计算指定帧数的时间。
        /// </summary>
        /// <param name="frame">目标帧数。</param>
        /// <returns>目标帧数对应的时间。</returns>
        public long FrameTime(int frame)
        {
            return this.startTime + (frame - this.startFrame) * this.Interval;
        }
        
        /// <summary>
        /// 重置计数器的开始时间和帧数。
        /// </summary>
        /// <param name="time">新的开始时间。</param>
        /// <param name="frame">新的开始帧数。</param>
        public void Reset(long time, int frame)
        {
            this.startTime = time;
            this.startFrame = frame;
        }
    }
}