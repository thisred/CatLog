using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"DOTween.dll",
		"MemoryPack.dll",
		"MongoDB.Bson.dll",
		"Newtonsoft.Json.dll",
		"System.Core.dll",
		"System.Runtime.CompilerServices.Unsafe.dll",
		"System.dll",
		"Unity.Core.dll",
		"Unity.ThirdParty.dll",
		"UnityEngine.CoreModule.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// ET.AEvent<object,ET.ChangePosition>
	// ET.AEvent<object,ET.ChangeRotation>
	// ET.AEvent<object,ET.Client.AfterCreateClientScene>
	// ET.AEvent<object,ET.Client.AfterCreateCurrentScene>
	// ET.AEvent<object,ET.Client.AfterUnitCreate>
	// ET.AEvent<object,ET.Client.AppStartInitFinish>
	// ET.AEvent<object,ET.Client.BattleResult>
	// ET.AEvent<object,ET.Client.BattleRoundResult>
	// ET.AEvent<object,ET.Client.EnterGameRound>
	// ET.AEvent<object,ET.Client.GameRoomStart>
	// ET.AEvent<object,ET.Client.LoginFinish>
	// ET.AEvent<object,ET.Client.MatchSuccess>
	// ET.AEvent<object,ET.Client.SceneChangeFinish>
	// ET.AEvent<object,ET.Client.SceneChangeStart>
	// ET.AEvent<object,ET.EntryEvent1>
	// ET.AEvent<object,ET.EntryEvent3>
	// ET.AEvent<object,ET.NumbericChange>
	// ET.AInvokeHandler<ET.FiberInit,object>
	// ET.AInvokeHandler<ET.MailBoxInvoker>
	// ET.AInvokeHandler<ET.NetComponentOnRead>
	// ET.AInvokeHandler<ET.TimerCallback>
	// ET.AwakeSystem<object,int,int>
	// ET.AwakeSystem<object,int>
	// ET.AwakeSystem<object,object,int>
	// ET.AwakeSystem<object,object,object>
	// ET.AwakeSystem<object,object>
	// ET.AwakeSystem<object>
	// ET.DestroySystem<object>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>
	// ET.ETAsyncTaskMethodBuilder<long>
	// ET.ETAsyncTaskMethodBuilder<object>
	// ET.ETAsyncTaskMethodBuilder<uint>
	// ET.ETTask<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETTask<ET.Client.Wait_CreateMyUnit>
	// ET.ETTask<ET.Client.Wait_SceneChangeFinish>
	// ET.ETTask<System.ValueTuple<uint,object>>
	// ET.ETTask<int>
	// ET.ETTask<long>
	// ET.ETTask<object>
	// ET.ETTask<uint>
	// ET.EntityRef<object>
	// ET.IAwake<int,int>
	// ET.IAwake<int>
	// ET.IAwake<object,int>
	// ET.IAwake<object,object>
	// ET.IAwake<object>
	// ET.IAwakeSystem<int,int>
	// ET.IAwakeSystem<int>
	// ET.IAwakeSystem<object,int>
	// ET.IAwakeSystem<object,object>
	// ET.IAwakeSystem<object>
	// ET.Singleton<object>
	// ET.StateMachineWrap<ET.Client.A2NetClient_MessageHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.A2NetClient_RequestHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.BattleResultEvent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<Call>d__6>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>
	// ET.StateMachineWrap<ET.Client.EnterGameRoundEvent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.EnterMapHelper.<Match>d__0>
	// ET.StateMachineWrap<ET.Client.EntryEvent3_InitClient.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.FiberInit_NetClient.<Handle>d__0>
	// ET.StateMachineWrap<ET.Client.G2C_DataSyncFinishHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.G2C_ReconnectHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.GameRoomStartEvent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.HttpClientHelper.<Get>d__0>
	// ET.StateMachineWrap<ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<Login>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Main2NetClient_LoginHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.MatchSuccessEvent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.PingComponentSystem.<PingAsync>d__2>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__4<object>>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__5>
	// ET.StateMachineWrap<ET.Client.Room2C_BattleResultHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Room2C_BattleRoundsResultHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Room2C_EnterMapHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Room2C_RoundStartHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.RoundResultEvent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<Init>d__1>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>
	// ET.StateMachineWrap<ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<Connect>d__2>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<CreateRouterSession>d__0>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<GetRouterAddress>d__1>
	// ET.StateMachineWrap<ET.Client.SceneChangeHelper.<EnterWorldScene>d__0>
	// ET.StateMachineWrap<ET.Client.SceneChangeStart_AddComponent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.UIAnnouncementEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIBattleEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIComponentSystem.<Create>d__1>
	// ET.StateMachineWrap<ET.Client.UIControlEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIGlobalComponentSystem.<OnCreate>d__1>
	// ET.StateMachineWrap<ET.Client.UIHelper.<Create>d__0>
	// ET.StateMachineWrap<ET.Client.UIHelper.<Remove>d__1>
	// ET.StateMachineWrap<ET.Client.UIHelper.<TryCreate>d__2>
	// ET.StateMachineWrap<ET.Client.UILobbyComponentSystem.<Match>d__1>
	// ET.StateMachineWrap<ET.Client.UILobbyEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UILoginEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIMatchComponentSystem.<DotAnimation>d__2>
	// ET.StateMachineWrap<ET.Client.UIMatchEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIMatchSuccessEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIResultEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIResultSystem.<Call>d__1>
	// ET.StateMachineWrap<ET.Client.UISelectCardEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UISelectCardSystem.<StartTurnCountdown>d__2>
	// ET.StateMachineWrap<ET.ConsoleComponentSystem.<Start>d__1>
	// ET.StateMachineWrap<ET.Entry.<StartAsync>d__2>
	// ET.StateMachineWrap<ET.EntryEvent1_InitShare.<Run>d__0>
	// ET.StateMachineWrap<ET.FiberInit_Main.<Handle>d__0>
	// ET.StateMachineWrap<ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>
	// ET.StateMachineWrap<ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>
	// ET.StateMachineWrap<ET.MessageHandler.<Handle>d__1<object,object,object>>
	// ET.StateMachineWrap<ET.MessageHandler.<Handle>d__1<object,object>>
	// ET.StateMachineWrap<ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>
	// ET.StateMachineWrap<ET.MessageSessionHandler.<HandleAsync>d__2<object>>
	// ET.StateMachineWrap<ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<Wait>d__4<object>>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<Wait>d__5<object>>
	// ET.StateMachineWrap<ET.ReloadConfigConsoleHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.ReloadDllConsoleHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.RpcInfo.<Wait>d__7>
	// ET.StateMachineWrap<ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>
	// ET.StateMachineWrap<ET.SessionSystem.<Call>d__3>
	// ET.StateMachineWrap<ET.SessionSystem.<Call>d__4>
	// ET.StructBsonSerialize<object>
	// ET.UpdateSystem<object>
	// MemoryPack.Formatters.ArrayFormatter<object>
	// MemoryPack.Formatters.DictionaryFormatter<int,int>
	// MemoryPack.Formatters.DictionaryFormatter<long,int>
	// MemoryPack.Formatters.DictionaryFormatter<long,object>
	// MemoryPack.Formatters.ListFormatter<int>
	// MemoryPack.Formatters.ListFormatter<object>
	// MemoryPack.IMemoryPackFormatter<int>
	// MemoryPack.IMemoryPackFormatter<object>
	// MemoryPack.IMemoryPackable<object>
	// MemoryPack.MemoryPackFormatter<System.UIntPtr>
	// MemoryPack.MemoryPackFormatter<object>
	// MongoDB.Bson.Serialization.IBsonSerializer<object>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<object>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<object>
	// System.Action<DotRecast.Detour.StraightPathItem>
	// System.Action<ET.MessageSessionDispatcherInfo>
	// System.Action<ET.NumericWatcherInfo>
	// System.Action<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Action<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Action<UnityEngine.Vector2>
	// System.Action<byte>
	// System.Action<int>
	// System.Action<long,int>
	// System.Action<long,object>
	// System.Action<long>
	// System.Action<object,byte,int>
	// System.Action<object,object>
	// System.Action<object>
	// System.ArraySegment.Enumerator<byte>
	// System.ArraySegment<byte>
	// System.ByReference<byte>
	// System.Collections.Concurrent.ConcurrentDictionary.<GetEnumerator>d__35<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.DictionaryEnumerator<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Node<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Tables<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary<object,object>
	// System.Collections.Concurrent.ConcurrentQueue.<Enumerate>d__28<object>
	// System.Collections.Concurrent.ConcurrentQueue.Segment<object>
	// System.Collections.Concurrent.ConcurrentQueue<object>
	// System.Collections.Generic.ArraySortHelper<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ArraySortHelper<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ArraySortHelper<ET.NumericWatcherInfo>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<long>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.Comparer<ET.ActorId>
	// System.Collections.Generic.Comparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.Comparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<long>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Comparer<uint>
	// System.Collections.Generic.Comparer<ushort>
	// System.Collections.Generic.ComparisonComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ComparisonComparer<ET.ActorId>
	// System.Collections.Generic.ComparisonComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ComparisonComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ComparisonComparer<int>
	// System.Collections.Generic.ComparisonComparer<long>
	// System.Collections.Generic.ComparisonComparer<object>
	// System.Collections.Generic.ComparisonComparer<uint>
	// System.Collections.Generic.ComparisonComparer<ushort>
	// System.Collections.Generic.Dictionary.Enumerator<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<long,int>
	// System.Collections.Generic.Dictionary.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<long,int>
	// System.Collections.Generic.Dictionary.KeyCollection<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<long,int>
	// System.Collections.Generic.Dictionary.ValueCollection<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<ushort,object>
	// System.Collections.Generic.Dictionary<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.Dictionary<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary<int,int>
	// System.Collections.Generic.Dictionary<int,long>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<long,int>
	// System.Collections.Generic.Dictionary<long,object>
	// System.Collections.Generic.Dictionary<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.Dictionary<ushort,object>
	// System.Collections.Generic.EqualityComparer<ET.ActorId>
	// System.Collections.Generic.EqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.EqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<long>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.EqualityComparer<uint>
	// System.Collections.Generic.EqualityComparer<ushort>
	// System.Collections.Generic.HashSet.Enumerator<int>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet.Enumerator<ushort>
	// System.Collections.Generic.HashSet<int>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.HashSet<ushort>
	// System.Collections.Generic.HashSetEqualityComparer<int>
	// System.Collections.Generic.HashSetEqualityComparer<object>
	// System.Collections.Generic.HashSetEqualityComparer<ushort>
	// System.Collections.Generic.ICollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ICollection<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ICollection<ET.NumericWatcherInfo>
	// System.Collections.Generic.ICollection<ET.RpcInfo>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.ValueTuple<int,int>,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<long>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.ICollection<ushort>
	// System.Collections.Generic.IComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<long>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IDictionary<object,object>
	// System.Collections.Generic.IEnumerable<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerable<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IEnumerable<ET.NumericWatcherInfo>
	// System.Collections.Generic.IEnumerable<ET.RpcInfo>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.ValueTuple<int,int>,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<long>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerable<ushort>
	// System.Collections.Generic.IEnumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerator<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IEnumerator<ET.NumericWatcherInfo>
	// System.Collections.Generic.IEnumerator<ET.RpcInfo>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.ValueTuple<int,int>,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<long>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEnumerator<ushort>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEqualityComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<long>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IEqualityComparer<ushort>
	// System.Collections.Generic.IList<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IList<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IList<ET.NumericWatcherInfo>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<long>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.IReadOnlyDictionary<long,object>
	// System.Collections.Generic.KeyValuePair<System.ValueTuple<int,int>,object>
	// System.Collections.Generic.KeyValuePair<int,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.KeyValuePair<int,long>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<long,int>
	// System.Collections.Generic.KeyValuePair<long,object>
	// System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.KeyValuePair<ushort,object>
	// System.Collections.Generic.List.Enumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List.Enumerator<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.List.Enumerator<ET.NumericWatcherInfo>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<long>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.List<ET.NumericWatcherInfo>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<long>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ObjectComparer<ET.ActorId>
	// System.Collections.Generic.ObjectComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ObjectComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<long>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectComparer<uint>
	// System.Collections.Generic.ObjectComparer<ushort>
	// System.Collections.Generic.ObjectEqualityComparer<ET.ActorId>
	// System.Collections.Generic.ObjectEqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.ObjectEqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<int,int>>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<long>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<uint>
	// System.Collections.Generic.ObjectEqualityComparer<ushort>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<int,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<long,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<int,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<long,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<long,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<int,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<long,object>
	// System.Collections.Generic.SortedDictionary<int,object>
	// System.Collections.Generic.SortedDictionary<long,object>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Stack.Enumerator<object>
	// System.Collections.Generic.Stack<object>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.MessageSessionDispatcherInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.NumericWatcherInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<long>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<DotRecast.Detour.StraightPathItem>
	// System.Comparison<ET.ActorId>
	// System.Comparison<ET.MessageSessionDispatcherInfo>
	// System.Comparison<ET.NumericWatcherInfo>
	// System.Comparison<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Comparison<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Comparison<int>
	// System.Comparison<long>
	// System.Comparison<object>
	// System.Comparison<uint>
	// System.Comparison<ushort>
	// System.Func<int,byte>
	// System.Func<object,byte>
	// System.Func<object,int>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.Linq.Buffer<ET.RpcInfo>
	// System.Linq.Buffer<object>
	// System.Linq.Enumerable.Iterator<int>
	// System.Linq.Enumerable.Iterator<object>
	// System.Linq.Enumerable.WhereEnumerableIterator<int>
	// System.Linq.Enumerable.WhereSelectArrayIterator<object,int>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<object,int>
	// System.Linq.Enumerable.WhereSelectListIterator<object,int>
	// System.Predicate<DotRecast.Detour.StraightPathItem>
	// System.Predicate<ET.MessageSessionDispatcherInfo>
	// System.Predicate<ET.NumericWatcherInfo>
	// System.Predicate<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Predicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Predicate<int>
	// System.Predicate<long>
	// System.Predicate<object>
	// System.Predicate<ushort>
	// System.ReadOnlySpan.Enumerator<byte>
	// System.ReadOnlySpan<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Span.Enumerator<byte>
	// System.Span<byte>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskFactory.<>c<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass32_0<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<object>
	// System.ValueTuple<ET.ActorId,object>
	// System.ValueTuple<int,int>
	// System.ValueTuple<uint,object>
	// System.ValueTuple<uint,uint>
	// System.ValueTuple<ushort,object>
	// }}

	public void RefMethods()
	{
		// object DG.Tweening.TweenExtensions.Play<object>(object)
		// object DG.Tweening.TweenSettingsExtensions.OnComplete<object>(object,DG.Tweening.TweenCallback)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.A2NetClient_MessageHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.A2NetClient_MessageHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.EnterMapHelper.<Match>d__0>(ET.ETTaskCompleted&,ET.Client.EnterMapHelper.<Match>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.FiberInit_NetClient.<Handle>d__0>(ET.ETTaskCompleted&,ET.Client.FiberInit_NetClient.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.G2C_DataSyncFinishHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.G2C_DataSyncFinishHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.G2C_ReconnectHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.G2C_ReconnectHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GameRoomStartEvent.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.GameRoomStartEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CreateMyUnitHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.Room2C_EnterMapHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.Room2C_EnterMapHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.Room2C_RoundStartHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.Room2C_RoundStartHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIHelper.<Remove>d__1>(ET.ETTaskCompleted&,ET.Client.UIHelper.<Remove>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.EntryEvent1_InitShare.<Run>d__0>(ET.ETTaskCompleted&,ET.EntryEvent1_InitShare.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>(ET.ETTaskCompleted&,ET.NumericChangeEvent_NotifyWatcher.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.ReloadConfigConsoleHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.ReloadDllConsoleHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.ReloadDllConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__5>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ET.ConsoleComponentSystem.<Start>d__1>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.A2NetClient_RequestHandler.<Run>d__0>(object&,ET.Client.A2NetClient_RequestHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>(object&,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>(object&,ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.BattleResultEvent.<Run>d__0>(object&,ET.Client.BattleResultEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>(object&,ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>(object&,ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EnterGameRoundEvent.<Run>d__0>(object&,ET.Client.EnterGameRoundEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EnterMapHelper.<Match>d__0>(object&,ET.Client.EnterMapHelper.<Match>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EntryEvent3_InitClient.<Run>d__0>(object&,ET.Client.EntryEvent3_InitClient.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.G2C_ReconnectHandler.<Run>d__0>(object&,ET.Client.G2C_ReconnectHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>(object&,ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>(object&,ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<Login>d__0>(object&,ET.Client.LoginHelper.<Login>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Main2NetClient_LoginHandler.<Run>d__0>(object&,ET.Client.Main2NetClient_LoginHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0>(object&,ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MatchSuccessEvent.<Run>d__0>(object&,ET.Client.MatchSuccessEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.PingComponentSystem.<PingAsync>d__2>(object&,ET.Client.PingComponentSystem.<PingAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__5>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Room2C_BattleResultHandler.<Run>d__0>(object&,ET.Client.Room2C_BattleResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Room2C_BattleRoundsResultHandler.<Run>d__0>(object&,ET.Client.Room2C_BattleRoundsResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Room2C_RoundStartHandler.<Run>d__0>(object&,ET.Client.Room2C_RoundStartHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RoundResultEvent.<Run>d__0>(object&,ET.Client.RoundResultEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>(object&,ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<Init>d__1>(object&,ET.Client.RouterAddressComponentSystem.<Init>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>(object&,ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>(object&,ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.SceneChangeHelper.<EnterWorldScene>d__0>(object&,ET.Client.SceneChangeHelper.<EnterWorldScene>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.SceneChangeStart_AddComponent.<Run>d__0>(object&,ET.Client.SceneChangeStart_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UILobbyComponentSystem.<Match>d__1>(object&,ET.Client.UILobbyComponentSystem.<Match>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIMatchComponentSystem.<DotAnimation>d__2>(object&,ET.Client.UIMatchComponentSystem.<DotAnimation>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIResultSystem.<Call>d__1>(object&,ET.Client.UIResultSystem.<Call>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UISelectCardSystem.<StartTurnCountdown>d__2>(object&,ET.Client.UISelectCardSystem.<StartTurnCountdown>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ConsoleComponentSystem.<Start>d__1>(object&,ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Entry.<StartAsync>d__2>(object&,ET.Entry.<StartAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.FiberInit_Main.<Handle>d__0>(object&,ET.FiberInit_Main.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>(object&,ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>(object&,ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageHandler.<Handle>d__1<object,object,object>>(object&,ET.MessageHandler.<Handle>d__1<object,object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageHandler.<Handle>d__1<object,object>>(object&,ET.MessageHandler.<Handle>d__1<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>(object&,ET.MessageSessionHandler.<HandleAsync>d__2<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageSessionHandler.<HandleAsync>d__2<object>>(object&,ET.MessageSessionHandler.<HandleAsync>d__2<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>(object&,ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ReloadConfigConsoleHandler.<Run>d__0>(object&,ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>(object&,ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<GetRouterAddress>d__1>(object&,ET.Client.RouterHelper.<GetRouterAddress>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4>(object&,ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIAnnouncementEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UIAnnouncementEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIBattleEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UIBattleEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIControlEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UIControlEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UILobbyEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UILobbyEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMatchEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UIMatchEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMatchSuccessEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UIMatchSuccessEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIResultEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UIResultEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UISelectCardEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UISelectCardEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__4<object>>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ET.Client.HttpClientHelper.<Get>d__0>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ET.Client.HttpClientHelper.<Get>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<Call>d__6>(object&,ET.Client.ClientSenderComponentSystem.<Call>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__4<object>>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<CreateRouterSession>d__0>(object&,ET.Client.RouterHelper.<CreateRouterSession>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIAnnouncementEvent.<OnCreate>d__0>(object&,ET.Client.UIAnnouncementEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIBattleEvent.<OnCreate>d__0>(object&,ET.Client.UIBattleEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIComponentSystem.<Create>d__1>(object&,ET.Client.UIComponentSystem.<Create>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIControlEvent.<OnCreate>d__0>(object&,ET.Client.UIControlEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIGlobalComponentSystem.<OnCreate>d__1>(object&,ET.Client.UIGlobalComponentSystem.<OnCreate>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIHelper.<Create>d__0>(object&,ET.Client.UIHelper.<Create>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIHelper.<TryCreate>d__2>(object&,ET.Client.UIHelper.<TryCreate>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UILobbyEvent.<OnCreate>d__0>(object&,ET.Client.UILobbyEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UILoginEvent.<OnCreate>d__0>(object&,ET.Client.UILoginEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIMatchEvent.<OnCreate>d__0>(object&,ET.Client.UIMatchEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIMatchSuccessEvent.<OnCreate>d__0>(object&,ET.Client.UIMatchSuccessEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIResultEvent.<OnCreate>d__0>(object&,ET.Client.UIResultEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UISelectCardEvent.<OnCreate>d__0>(object&,ET.Client.UISelectCardEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<Wait>d__4<object>>(object&,ET.ObjectWaitSystem.<Wait>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<Wait>d__5<object>>(object&,ET.ObjectWaitSystem.<Wait>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.RpcInfo.<Wait>d__7>(object&,ET.RpcInfo.<Wait>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<Call>d__3>(object&,ET.SessionSystem.<Call>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<Call>d__4>(object&,ET.SessionSystem.<Call>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<Connect>d__2>(object&,ET.Client.RouterHelper.<Connect>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.A2NetClient_MessageHandler.<Run>d__0>(ET.Client.A2NetClient_MessageHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.A2NetClient_RequestHandler.<Run>d__0>(ET.Client.A2NetClient_RequestHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0>(ET.Client.AfterCreateClientScene_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0>(ET.Client.AfterCreateCurrentScene_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>(ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>(ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.BattleResultEvent.<Run>d__0>(ET.Client.BattleResultEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>(ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>(ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>(ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>(ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EnterGameRoundEvent.<Run>d__0>(ET.Client.EnterGameRoundEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EnterMapHelper.<Match>d__0>(ET.Client.EnterMapHelper.<Match>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EntryEvent3_InitClient.<Run>d__0>(ET.Client.EntryEvent3_InitClient.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.FiberInit_NetClient.<Handle>d__0>(ET.Client.FiberInit_NetClient.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.G2C_DataSyncFinishHandler.<Run>d__0>(ET.Client.G2C_DataSyncFinishHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.G2C_ReconnectHandler.<Run>d__0>(ET.Client.G2C_ReconnectHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.GameRoomStartEvent.<Run>d__0>(ET.Client.GameRoomStartEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>(ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>(ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginHelper.<Login>d__0>(ET.Client.LoginHelper.<Login>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>(ET.Client.M2C_CreateMyUnitHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Main2NetClient_LoginHandler.<Run>d__0>(ET.Client.Main2NetClient_LoginHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0>(ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MatchSuccessEvent.<Run>d__0>(ET.Client.MatchSuccessEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>(ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.PingComponentSystem.<PingAsync>d__2>(ET.Client.PingComponentSystem.<PingAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__5>(ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Room2C_BattleResultHandler.<Run>d__0>(ET.Client.Room2C_BattleResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Room2C_BattleRoundsResultHandler.<Run>d__0>(ET.Client.Room2C_BattleRoundsResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Room2C_EnterMapHandler.<Run>d__0>(ET.Client.Room2C_EnterMapHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Room2C_RoundStartHandler.<Run>d__0>(ET.Client.Room2C_RoundStartHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RoundResultEvent.<Run>d__0>(ET.Client.RoundResultEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>(ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<Init>d__1>(ET.Client.RouterAddressComponentSystem.<Init>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>(ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>(ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SceneChangeHelper.<EnterWorldScene>d__0>(ET.Client.SceneChangeHelper.<EnterWorldScene>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SceneChangeStart_AddComponent.<Run>d__0>(ET.Client.SceneChangeStart_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIHelper.<Remove>d__1>(ET.Client.UIHelper.<Remove>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UILobbyComponentSystem.<Match>d__1>(ET.Client.UILobbyComponentSystem.<Match>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMatchComponentSystem.<DotAnimation>d__2>(ET.Client.UIMatchComponentSystem.<DotAnimation>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIResultSystem.<Call>d__1>(ET.Client.UIResultSystem.<Call>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UISelectCardSystem.<StartTurnCountdown>d__2>(ET.Client.UISelectCardSystem.<StartTurnCountdown>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ConsoleComponentSystem.<Start>d__1>(ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Entry.<StartAsync>d__2>(ET.Entry.<StartAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EntryEvent1_InitShare.<Run>d__0>(ET.EntryEvent1_InitShare.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.AppStartInitFinish>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.AppStartInitFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.BattleResult>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.BattleResult>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.BattleRoundResult>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.BattleRoundResult>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.EnterGameRound>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.EnterGameRound>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.GameRoomStart>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.GameRoomStart>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LoginFinish>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LoginFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.SceneChangeStart>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.SceneChangeStart>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.FiberInit_Main.<Handle>d__0>(ET.FiberInit_Main.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>(ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>(ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageHandler.<Handle>d__1<object,object,object>>(ET.MessageHandler.<Handle>d__1<object,object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageHandler.<Handle>d__1<object,object>>(ET.MessageHandler.<Handle>d__1<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>(ET.MessageSessionHandler.<HandleAsync>d__2<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageSessionHandler.<HandleAsync>d__2<object>>(ET.MessageSessionHandler.<HandleAsync>d__2<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>(ET.NumericChangeEvent_NotifyWatcher.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>(ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ReloadConfigConsoleHandler.<Run>d__0>(ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ReloadDllConsoleHandler.<Run>d__0>(ET.ReloadDllConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>(ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start>.Start<ET.ObjectWaitSystem.<Wait>d__4<ET.Client.WaitType.Wait_Room2C_Start>>(ET.ObjectWaitSystem.<Wait>d__4<ET.Client.WaitType.Wait_Room2C_Start>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.Start<ET.Client.RouterHelper.<GetRouterAddress>d__1>(ET.Client.RouterHelper.<GetRouterAddress>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.Start<ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4>(ET.Client.ClientSenderComponentSystem.<LoginAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ClientSenderComponentSystem.<Call>d__6>(ET.Client.ClientSenderComponentSystem.<Call>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.HttpClientHelper.<Get>d__0>(ET.Client.HttpClientHelper.<Get>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__4<object>>(ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>>(ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__3<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.RouterHelper.<CreateRouterSession>d__0>(ET.Client.RouterHelper.<CreateRouterSession>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIAnnouncementEvent.<OnCreate>d__0>(ET.Client.UIAnnouncementEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIBattleEvent.<OnCreate>d__0>(ET.Client.UIBattleEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIComponentSystem.<Create>d__1>(ET.Client.UIComponentSystem.<Create>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIControlEvent.<OnCreate>d__0>(ET.Client.UIControlEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIGlobalComponentSystem.<OnCreate>d__1>(ET.Client.UIGlobalComponentSystem.<OnCreate>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIHelper.<Create>d__0>(ET.Client.UIHelper.<Create>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIHelper.<TryCreate>d__2>(ET.Client.UIHelper.<TryCreate>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UILobbyEvent.<OnCreate>d__0>(ET.Client.UILobbyEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UILoginEvent.<OnCreate>d__0>(ET.Client.UILoginEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIMatchEvent.<OnCreate>d__0>(ET.Client.UIMatchEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIMatchSuccessEvent.<OnCreate>d__0>(ET.Client.UIMatchSuccessEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIResultEvent.<OnCreate>d__0>(ET.Client.UIResultEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UISelectCardEvent.<OnCreate>d__0>(ET.Client.UISelectCardEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.ObjectWaitSystem.<Wait>d__4<object>>(ET.ObjectWaitSystem.<Wait>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.ObjectWaitSystem.<Wait>d__5<object>>(ET.ObjectWaitSystem.<Wait>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.RpcInfo.<Wait>d__7>(ET.RpcInfo.<Wait>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.SessionSystem.<Call>d__3>(ET.SessionSystem.<Call>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.SessionSystem.<Call>d__4>(ET.SessionSystem.<Call>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.Start<ET.Client.RouterHelper.<Connect>d__2>(ET.Client.RouterHelper.<Connect>d__2&)
		// object ET.Entity.AddChild<object,object,object>(object,object,bool)
		// object ET.Entity.AddChildWithId<object,object>(long,object,bool)
		// object ET.Entity.AddChildWithId<object>(long,bool)
		// object ET.Entity.AddComponent<object,int,int>(int,int,bool)
		// object ET.Entity.AddComponent<object,int>(int,bool)
		// object ET.Entity.AddComponent<object,object,int>(object,int,bool)
		// object ET.Entity.AddComponent<object>(bool)
		// object ET.Entity.AddComponentWithId<object,int,int>(long,int,int,bool)
		// object ET.Entity.AddComponentWithId<object,int>(long,int,bool)
		// object ET.Entity.AddComponentWithId<object,object,int>(long,object,int,bool)
		// object ET.Entity.AddComponentWithId<object>(long,bool)
		// object ET.Entity.GetChild<object>(long)
		// object ET.Entity.GetComponent<object>()
		// object ET.Entity.GetParent<object>()
		// System.Void ET.Entity.RemoveComponent<object>()
		// System.Void ET.EntitySystemSingleton.Awake<int,int>(ET.Entity,int,int)
		// System.Void ET.EntitySystemSingleton.Awake<int>(ET.Entity,int)
		// System.Void ET.EntitySystemSingleton.Awake<object,int>(ET.Entity,object,int)
		// System.Void ET.EntitySystemSingleton.Awake<object,object>(ET.Entity,object,object)
		// System.Void ET.EntitySystemSingleton.Awake<object>(ET.Entity,object)
		// long ET.EnumHelper.FromString<long>(string)
		// System.Void ET.EventSystem.Invoke<ET.NetComponentOnRead>(long,ET.NetComponentOnRead)
		// System.Void ET.EventSystem.Publish<object,ET.Client.AfterCreateCurrentScene>(object,ET.Client.AfterCreateCurrentScene)
		// System.Void ET.EventSystem.Publish<object,ET.Client.MatchSuccess>(object,ET.Client.MatchSuccess)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeFinish>(object,ET.Client.SceneChangeFinish)
		// System.Void ET.EventSystem.Publish<object,ET.NumbericChange>(object,ET.NumbericChange)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.AppStartInitFinish>(object,ET.Client.AppStartInitFinish)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.BattleResult>(object,ET.Client.BattleResult)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.BattleRoundResult>(object,ET.Client.BattleRoundResult)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.EnterGameRound>(object,ET.Client.EnterGameRound)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.GameRoomStart>(object,ET.Client.GameRoomStart)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LoginFinish>(object,ET.Client.LoginFinish)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.SceneChangeStart>(object,ET.Client.SceneChangeStart)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent1>(object,ET.EntryEvent1)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent2>(object,ET.EntryEvent2)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent3>(object,ET.EntryEvent3)
		// object ET.GameRoot.AddSingleton<object>()
		// object ET.MongoHelper.FromJson<object>(string)
		// System.Void ET.RandomGenerator.BreakRank<int>(System.Collections.Generic.List<int>)
		// System.Void ET.RandomGenerator.BreakRank<object>(System.Collections.Generic.List<object>)
		// int ET.RandomGenerator.RandomArray<int>(System.Collections.Generic.List<int>)
		// string Luban.StringUtil.CollectionToString<int>(System.Collections.Generic.IEnumerable<int>)
		// string Luban.StringUtil.CollectionToString<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.List<object> MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&)
		// System.Void MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&,System.Collections.Generic.List<object>&)
		// System.Void MemoryPack.Formatters.ListFormatter.SerializePackable<object>(MemoryPack.MemoryPackWriter&,System.Collections.Generic.List<object>&)
		// MemoryPack.MemoryPackFormatter<object> MemoryPack.MemoryPackFormatterProvider.GetFormatter<object>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<object>()
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<object>(MemoryPack.MemoryPackFormatter<object>)
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackReader.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.ActorId>(ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,ET.ActorId>(byte&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,ET.ActorId>(byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int>(byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long,long>(byte&,int&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int>(byte&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long>(byte&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,uint>(byte&,uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte>(byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<uint>(uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadValue<object>(object&)
		// object MemoryPack.MemoryPackReader.ReadValue<object>()
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackWriter.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,ET.ActorId>(byte,byte&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,ET.ActorId>(byte,byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int>(byte,byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long,long>(byte,byte&,int&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int>(byte,byte&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long>(byte,byte&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,uint>(byte,byte&,uint&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte>(byte,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<object>(object&)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(MongoDB.Bson.IO.IBsonReader,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(string,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// MongoDB.Bson.Serialization.IBsonSerializer<object> MongoDB.Bson.Serialization.BsonSerializer.LookupSerializer<object>()
		// object MongoDB.Bson.Serialization.IBsonSerializerExtensions.Deserialize<object>(MongoDB.Bson.Serialization.IBsonSerializer<object>,MongoDB.Bson.Serialization.BsonDeserializationContext)
		// object Newtonsoft.Json.JsonConvert.DeserializeObject<object>(string)
		// object Newtonsoft.Json.JsonConvert.DeserializeObject<object>(string,Newtonsoft.Json.JsonSerializerSettings)
		// object System.Activator.CreateInstance<object>()
		// object[] System.Array.Empty<object>()
		// object System.Collections.Generic.CollectionExtensions.GetValueOrDefault<long,object>(System.Collections.Generic.IReadOnlyDictionary<long,object>,long)
		// object System.Collections.Generic.CollectionExtensions.GetValueOrDefault<long,object>(System.Collections.Generic.IReadOnlyDictionary<long,object>,long,object)
		// System.Collections.Generic.IEnumerable<int> System.Linq.Enumerable.Select<object,int>(System.Collections.Generic.IEnumerable<object>,System.Func<object,int>)
		// ET.RpcInfo[] System.Linq.Enumerable.ToArray<ET.RpcInfo>(System.Collections.Generic.IEnumerable<ET.RpcInfo>)
		// object[] System.Linq.Enumerable.ToArray<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.List<int> System.Linq.Enumerable.ToList<int>(System.Collections.Generic.IEnumerable<int>)
		// System.Collections.Generic.IEnumerable<int> System.Linq.Enumerable.Iterator<object>.Select<int>(System.Func<object,int>)
		// byte& System.Runtime.CompilerServices.Unsafe.Add<byte>(byte&,int)
		// object& System.Runtime.CompilerServices.Unsafe.AsRef<object>(object&)
		// ET.ActorId System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.ActorId>(byte&)
		// byte System.Runtime.CompilerServices.Unsafe.ReadUnaligned<byte>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.ReadUnaligned<int>(byte&)
		// long System.Runtime.CompilerServices.Unsafe.ReadUnaligned<long>(byte&)
		// uint System.Runtime.CompilerServices.Unsafe.ReadUnaligned<uint>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.ActorId>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<byte>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<int>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<long>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<uint>()
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.ActorId>(byte&,ET.ActorId)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<byte>(byte&,byte)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<int>(byte&,int)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<long>(byte&,long)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<uint>(byte&,uint)
		// System.Threading.Tasks.Task<object> System.Threading.Tasks.TaskFactory.StartNew<object>(System.Func<object>,System.Threading.CancellationToken)
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// object UnityEngine.Resources.Load<object>(string)
		// YooAsset.AllAssetsHandle YooAsset.ResourcePackage.LoadAllAssetsAsync<object>(string,uint)
		// YooAsset.AssetHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string,uint)
		// string string.Join<int>(string,System.Collections.Generic.IEnumerable<int>)
		// string string.Join<object>(string,System.Collections.Generic.IEnumerable<object>)
		// string string.JoinCore<int>(System.Char*,int,System.Collections.Generic.IEnumerable<int>)
		// string string.JoinCore<object>(System.Char*,int,System.Collections.Generic.IEnumerable<object>)
	}
}