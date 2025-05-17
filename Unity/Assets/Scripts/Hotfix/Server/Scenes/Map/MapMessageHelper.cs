﻿namespace ET.Server
{
    public static partial class MapMessageHelper
    {
        public static void NoticeUnitAdd(Unit unit, Unit sendUnit)
        {
            // M2C_CreateUnits createUnits = M2C_CreateUnits.Create();
            // createUnits.Units.Add(UnitHelper.CreateUnitInfo(sendUnit));
            // MapMessageHelper.SendToClient(unit, createUnits);
        }
        
        public static void NoticeUnitRemove(Unit unit, Unit sendUnit)
        {
            // M2C_RemoveUnits removeUnits = M2C_RemoveUnits.Create();
            // removeUnits.Units.Add(sendUnit.Id);
            // MapMessageHelper.SendToClient(unit, removeUnits);
        }
        
        public static void SendToClient(Unit unit, IMessage message)
        {
            unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(unit.Id, message);
        }
        
        /// <summary>
        /// 发送协议给Actor
        /// </summary>
        public static void Send(Scene root, ActorId actorId, IMessage message)
        {
            root.GetComponent<MessageSender>().Send(actorId, message);
        }
    }
}