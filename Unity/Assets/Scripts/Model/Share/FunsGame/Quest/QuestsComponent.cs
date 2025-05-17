using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
	[ComponentOf(typeof(Unit))]
	public class QuestsComponent : Entity, IAwake, IDestroy, //IUnitCache, 
			IDeserialize
	{
		/// <summary>
		/// 所有任务，包括已完成的未完成的
		/// </summary>
		[BsonIgnore] public Dictionary<int, EntityRef<Quest>> QuestDic = new();

		
		
		/// <summary>
		/// 暂存有修改后需要同步给客户端的任务
		/// </summary>
		[BsonIgnore] public HashSet<int> ChangedQuestIds = new();
	}
}