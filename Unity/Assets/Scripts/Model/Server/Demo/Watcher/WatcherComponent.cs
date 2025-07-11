using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class WatcherComponent: Entity, IAwake
    {
        public readonly Dictionary<int, System.Diagnostics.Process> Processes = new Dictionary<int, System.Diagnostics.Process>();
    }
}