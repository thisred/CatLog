namespace ET.Server
{
	public static partial class RealmGateAddressHelper
	{
		public static StartSceneConfig GetGate(int zone, string account)
		{
			ulong hash = (ulong)account.GetLongHashCode();
			
			var zoneGates = StartSceneConfigCategory.Instance.Gates[zone];
			
			return zoneGates[(int)(hash % (ulong)zoneGates.Count)];
		}
	}
}
