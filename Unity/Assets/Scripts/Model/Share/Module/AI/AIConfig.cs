using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
	public partial class AIConfigCategory
	{
		[BsonIgnore]
		public Dictionary<int, SortedDictionary<int, AIConfig>> AIConfigs = new Dictionary<int, SortedDictionary<int, AIConfig>>();

		public SortedDictionary<int, AIConfig> GetAI(int aiConfigId)
		{
			return this.AIConfigs[aiConfigId];
		}

		public override void EndInit()
		{
			foreach (var kv in this.DataMap)
			{
				SortedDictionary<int, AIConfig> aiNodeConfig;
				if (!this.AIConfigs.TryGetValue(kv.Value.AIConfigId, out aiNodeConfig))
				{
					aiNodeConfig = new SortedDictionary<int, AIConfig>();
					this.AIConfigs.Add(kv.Value.AIConfigId, aiNodeConfig);
				}
				
				aiNodeConfig.Add(kv.Key, kv.Value);
			}
		}
	}
}
