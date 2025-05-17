using System;
using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class DataSaveComponent : Entity, IAwake, IDestroy, IGetComponentSys
    {
        public List<Type> ChangeTypes = new List<Type>();
        public long Timer;
    }
}