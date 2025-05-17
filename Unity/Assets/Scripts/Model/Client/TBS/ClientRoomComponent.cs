using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class ClientRoomComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, int> Score = new Dictionary<long, int>();
        public List<long> PlayerIds = new List<long>();
    }
}