using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(TBSRoom))]
    public class RoomServerComponent: Entity, IAwake<List<long>>, IAwake
    {
    }
}