// using System.Collections.Generic;
//
// namespace ET.Server
// {
//     [FriendOf(typeof(NumericComponent))]
//     public static partial class UnitHelper
//     {
//         public static UnitInfo CreateUnitInfo(Unit unit)
//         {
//             var unitInfo = UnitInfo.Create();
//             var nc = unit.GetComponent<NumericComponent>();
//             unitInfo.UnitId = unit.Id;
//             // unitInfo.ConfigId = unit.ConfigId;
//             // unitInfo.Type = (int)unit.Type();
//             // unitInfo.Position = unit.Position;
//             // unitInfo.Forward = unit.Forward;
//             //
//             // var moveComponent = unit.GetComponent<MoveComponent>();
//             // if (moveComponent != null)
//             // {
//             //     if (!moveComponent.IsArrived())
//             //     {
//             //         unitInfo.MoveInfo = MoveInfo.Create();
//             //         unitInfo.MoveInfo.Points.Add(unit.Position);
//             //         for (int i = moveComponent.N; i < moveComponent.Targets.Count; ++i)
//             //         {
//             //             var pos = moveComponent.Targets[i];
//             //             unitInfo.MoveInfo.Points.Add(pos);
//             //         }
//             //     }
//             // }
//
//             foreach ((int key, long value) in nc.NumericDic)
//             {
//                 // unitInfo.KV.Add(key, value);
//             }
//
//             return unitInfo;
//         }
//     }
// }