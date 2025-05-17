// namespace ET
// {
// 	public static class QuestHelper
// 	{
// 		/// <summary>
// 		/// 获取任务积分
// 		/// </summary>
// 		/// <param name="unit"></param>
// 		/// <param name="category"></param>
// 		public static int GetQuestLiveness(Unit unit, QuestCategory category)
// 		{
// 			int livenessValue;
// 			switch (category)
// 			{
// 				case QuestCategory.Daily:
// 					livenessValue = (int)CoinType.LivenessDaily;
// 					break;
// 				case QuestCategory.Weekly:
// 					livenessValue = (int)CoinType.LivenessWeekly;
// 					break;
// 				case QuestCategory.NoviceTarget:
// 					livenessValue = NumericType.LivenessNoviceTarget;
// 					break;
// 				case QuestCategory.HeroCultivateTarget:
// 					livenessValue = NumericType.LivenessHeroCultivateTarget;
// 					break;
// 				case QuestCategory.FruitCultivateTarget:
// 					livenessValue = NumericType.LivenessFruitCultivateTarget;
// 					break;
// 				case QuestCategory.HeroEquipCultivateTarget:
// 					livenessValue = NumericType.LivenessHeroEquipCultivateTarget;
// 					break;
// 				case QuestCategory.GemCultivateTarget:
// 					livenessValue = NumericType.LivenessGemCultivateTarget;
// 					break;
// 				case QuestCategory.JunglePrestige:
// 					livenessValue = NumericType.JunglePrestigeWeeklyLiveness;
// 					break;
// 				case QuestCategory.FollowerSys:
// 					Log.Debug("QuestCategory.FollowerSys 没有");
// 					return 0;
// 				default:
// 					Log.Error("任务积分  在获取一个未定义的任务积分。 " + category);
// 					return 0;
// 			}
//
// 			var numericCom = unit.GetComponent<NumericComponent>();
// 			return (int)numericCom[livenessValue];
// 		}
//
//
// 		/// <summary>
// 		/// 获取任务积分存储对应的 NumberType
// 		/// </summary>
// 		/// <param name="category"></param>
// 		public static int GetQuestLivenessType(QuestCategory category)
// 		{
// 			switch (category)
// 			{
// 				case QuestCategory.Daily:
// 					return (int)CoinType.LivenessDaily;
// 				case QuestCategory.Weekly:
// 					return (int)CoinType.LivenessWeekly;
// 				case QuestCategory.NoviceTarget:
// 					return NumericType.LivenessNoviceTarget;
// 				case QuestCategory.HeroCultivateTarget:
// 					return NumericType.LivenessHeroCultivateTarget;
// 				case QuestCategory.FruitCultivateTarget:
// 					return NumericType.LivenessFruitCultivateTarget;
// 				case QuestCategory.HeroEquipCultivateTarget:
// 					return NumericType.LivenessHeroEquipCultivateTarget;
// 				case QuestCategory.GemCultivateTarget:
// 					return NumericType.LivenessGemCultivateTarget;
// 				case QuestCategory.JunglePrestige:
// 					return NumericType.JunglePrestigeWeeklyLiveness;
// 				case QuestCategory.FollowerSys:
// 					Log.Debug("QuestCategory.FollowerSys 不需要");
// 					return 0;
// 				default:
// 					Log.Error("任务积分  在获取一个未定义的任务积分。 " + category);
// 					return 0;
// 			}
// 		}
// 	}
// }