// using System;
// using System.Collections.Generic;
// using System.Linq;
// using ET.Client;
//
// // 不传入参数的任务
// namespace ET.Server
// {
// 	[QuestHandler(QuestType.EquipUpgradeToLevelNum)]
// 	[FriendOf(typeof(EquipItemComponent))]
// 	[FriendOf(typeof(EquipItem))]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroComponent))]
// 	[FriendOf(typeof(HeroShareData))]
// 	public class QuestEquipUpgradeToLevelNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 将x个装备升级到y级
// 			await ETTask.CompletedTask;
// 			var heroCom = unit.GetComponent<HeroComponent>();
// 			long progress = 0;
//
// 			foreach (var shareData in heroCom.ShareEquipDatas.List)
// 			{
// 				foreach (var equipItem in shareData.EquipItems)
// 				{
// 					if (equipItem.Level >= quest.Config.Param[0])
// 					{
// 						progress++;
// 					}
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.GetHeroNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroComponent))]
// 	public class QuestGetHeroNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 获得英雄数量
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			long progress = heroComponent.Heroes.Count;
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.PowerUpdate)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroComponent))]
// 	public class QuestPowerUpdate : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 战力提升至x
// 			await ETTask.CompletedTask;
// 			long progress = unit.GetComponent<NumericComponent>()[NumericType.RolePower];
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroEvolutionToRankNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroComponent))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestHeroEvolutionToRankNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 将x个英雄升级到y阶
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			long progress = heroComponent.Heroes.Select(hero =>
// 				{
// 					int level = heroComponent.GetHeroLevel(hero);
// 					return HERO_UPGRADE_Table.Instance.GetOrDefault(level);
// 				})
// 				.LongCount(heroUpgrade => heroUpgrade.EvolutionLevel >= quest.Config.Param[0]);
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroUpgradeToStarNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroComponent))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestHeroUpgradeToStarNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 将x个英雄升级到y星
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			long progress = heroComponent.Heroes.LongCount(hero => hero.Star >= quest.Config.Param[0]);
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EquipEvolutionToRankNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(EquipItemComponent))]
// 	[FriendOf(typeof(EquipItem))]
// 	[FriendOf(typeof(HeroComponent))]
// 	[FriendOf(typeof(HeroShareData))]
// 	public class QuestEquipEvolutionToRankNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 将x个装备升级到y阶
// 			await ETTask.CompletedTask;
// 			var heroCom = unit.GetComponent<HeroComponent>();
// 			long progress = 0;
//
// 			foreach (var shareData in heroCom.ShareEquipDatas.List)
// 			{
// 				foreach (var equipItem in shareData.EquipItems)
// 				{
// 					var config = EQUIP_ITEM_UPGRADE_COST_Table.Instance.GetOrDefault(equipItem.Level);
// 					if (config.EvolutionLevel >= quest.Config.Param[0])
// 					{
// 						progress++;
// 					}
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	//[QuestHandler(QuestType.GetFruitNum)]
// 	//[FriendOf(typeof(Quest))]
// 	//[FriendOf(typeof(Item))]
// 	//public class QuestGetFruitNum : AQuestHandler
// 	//{
// 	//	protected override async ETTask Run(Unit unit, Quest quest)
// 	//	{
// 	//		// 获取不同种类果实数量
// 	//		await ETTask.CompletedTask;
// 	//		var bagComponent = unit.GetComponent<BagComponent>();
// 	//		var itemsByMainType = bagComponent.GetItemsByType(ItemMainType.Item, ItemSubType.EquipRune);
// 	//		var equipFruitComponent = unit.GetComponent<EquipFruitComponent>();
// 	//		var fruitItemIds = new HashSet<int>();
// 	//		foreach (var item in itemsByMainType)
// 	//		{
// 	//			fruitItemIds.Add(item.ConfigId);
// 	//		}
//
// 	//		foreach (int fruitConfigId in equipFruitComponent.EquipedFruits.Keys)
// 	//		{
// 	//			fruitItemIds.Add(fruitConfigId);
// 	//		}
//
// 	//		long progress = fruitItemIds.Count;
// 	//		quest.SetProgress(progress);
// 	//	}
// 	//}
//
//
// 	[QuestHandler(QuestType.ClimbingTowerNum, QuestType.EndlessRainforest)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(ClimbTowerComponent))]
// 	public class QuestClimbingTowerNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 通关爬塔第x层
// 			await ETTask.CompletedTask;
// 			var towerComponent = ClimbTowerHelper.GetDBInfo(unit);
// 			quest.SetProgress(towerComponent.Floor - 1);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.TreeLevel)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(TreeComponent))]
// 	public class QuestTreeLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 树精等级
// 			await ETTask.CompletedTask;
// 			long progress = unit.GetComponent<TreeComponent>().Level;
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.PassSmallStage)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(MainLineComponent))]
// 	[FriendOf(typeof(Chapter))]
// 	public class QuestPassSmallStage : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 通关小关第x章第y关
// 			await ETTask.CompletedTask;
// 			long progress = 0;
// 			var mainLineComponent = unit.GetComponent<MainLineComponent>();
// 			if (mainLineComponent.Chapters.TryGetValue(quest.Config.Param[0], out var chapter))
// 			{
// 				if (chapter.Stages.TryGetValue(quest.Config.Param[1], out var stage))
// 				{
// 					if (stage != null && stage.Pass)
// 					{
// 						progress = 1;
// 					}
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ClearSpecifiedHardLevel)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(MainLineComponent))]
// 	[FriendOf(typeof(Chapter))]
// 	public class QuestClearSpecifiedHardLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 通关指定困难关卡
// 			await ETTask.CompletedTask;
// 			var mainLineComponent = unit.GetComponent<MainLineComponent>();
// 			if (mainLineComponent.Chapters.TryGetValue(quest.Config.Param[0], out var chapter))
// 			{
// 				if (chapter.DifficultStages.TryGetValue(quest.Config.Param[1], out var stage))
// 				{
// 					if (stage is { Pass: true })
// 					{
// 						quest.Complete();
// 					}
// 				}
// 			}
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.HeroQualityNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroComponent))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestHeroQualityNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 获得x个y品质的英雄
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			long progress = heroComponent.Heroes.Select(hero => BATTLE_UNIT_Table.Instance.GetOrDefault(hero.UnitId))
// 				.LongCount(battleUnitConfig => battleUnitConfig.quality == (ItemQuality)quest.Config.Param[0]);
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroUpgradeToLevelNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroComponent))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestHeroUpgradeToLevelNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 将x个英雄升级到y级
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			long progress = heroComponent.Heroes.LongCount(hero =>
// 			{
// 				int level = heroComponent.GetHeroLevel(hero);
// 				return level >= quest.Config.Param[0];
// 			});
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopQualityNum)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBattleTroopQualityNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵x个y品质的动物
// 			await ETTask.CompletedTask;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			long progress = heroIds
// 				.Select(heroId => BATTLE_UNIT_Table.Instance.GetOrDefault(heroId))
// 				.Where(battleUnit => battleUnit != null)
// 				.LongCount(battleUnit => battleUnit.quality == (ItemQuality)quest.Config.Param[0]);
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopLevelNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestBattleTroopLevelNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵x个动物升级到y级
// 			await ETTask.CompletedTask;
// 			long progress = 0;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			foreach (int heroId in heroIds)
// 			{
// 				if (!heroComponent.TryGetHero(heroId, out var hero))
// 				{
// 					continue;
// 				}
//
// 				if (heroComponent.GetHeroLevel(hero) >= quest.Config.Param[0])
// 				{
// 					progress++;
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopRankNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestBattleTroopRankNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵x个动物升级到y阶
// 			await ETTask.CompletedTask;
// 			long progress = 0;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			foreach (int heroId in heroIds)
// 			{
// 				if (!heroComponent.TryGetHero(heroId, out var hero))
// 				{
// 					continue;
// 				}
//
// 				var heroUpgrade = HERO_UPGRADE_Table.Instance.GetOrDefault(heroComponent.GetHeroLevel(hero));
// 				if (heroUpgrade.EvolutionLevel >= quest.Config.Param[0])
// 				{
// 					progress++;
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopStarNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestBattleTroopStarNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵x个动物提升到y星
// 			await ETTask.CompletedTask;
// 			long progress = 0;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			foreach (int heroId in heroIds)
// 			{
// 				if (!heroComponent.TryGetHero(heroId, out var hero))
// 				{
// 					continue;
// 				}
//
// 				if (hero.Star >= quest.Config.Param[0])
// 				{
// 					progress++;
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopTotalLevel)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestBattleTroopTotalLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵英雄总等级达到x级
// 			await ETTask.CompletedTask;
// 			long progress = 0;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			foreach (int heroId in heroIds)
// 			{
// 				if (heroComponent.TryGetHero(heroId, out var hero))
// 				{
// 					progress += heroComponent.GetHeroLevel(hero);
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopTotalStar)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestBattleTroopTotalStar : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵英雄总星级达到x星
// 			await ETTask.CompletedTask;
// 			long progress = 0;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			foreach (int heroId in heroIds)
// 			{
// 				if (heroComponent.TryGetHero(heroId, out var hero))
// 				{
// 					progress += hero.Star;
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopTotalRank)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestBattleTroopTotalRank : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵英雄总等阶达到x阶
// 			await ETTask.CompletedTask;
// 			long progress = 0;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			foreach (int heroId in heroIds)
// 			{
// 				if (!heroComponent.TryGetHero(heroId, out var hero))
// 				{
// 					continue;
// 				}
//
// 				var heroUpgrade = HERO_UPGRADE_Table.Instance.GetOrDefault(heroComponent.GetHeroLevel(hero));
// 				progress += heroUpgrade.EvolutionLevel;
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.AllHeroTotalRank)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestAllHeroTotalRank : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 英雄总等阶达到x阶
// 			await ETTask.CompletedTask;
// 			long progress = 0;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			foreach ((int heroId, var hero) in heroComponent.HeroDict)
// 			{
// 				var heroUpgrade = HERO_UPGRADE_Table.Instance.GetOrDefault(heroComponent.GetHeroLevel(hero));
// 				progress += heroUpgrade.EvolutionLevel;
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.TurtleLevel)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(TurtleComponent))]
// 	public class QuestTurtleLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 龟壳等级提升至x级
// 			await ETTask.CompletedTask;
// 			var turtleComponent = unit.GetComponent<TurtleComponent>();
// 			long progress = turtleComponent.Level;
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.TeamRecommendCollection)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestTroopGetNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 获得x阵容里的y个英雄
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			int troopId = quest.Config.Param[0];
// 			var list = TEAM_RECOMMEND_Table.Instance.DataListById(troopId);
// 			if (list != null && list.Count > 0)
// 			{
// 				var troopRecommend = list[0];
// 				int progress = troopRecommend.HeroIds.Count(heroId => heroComponent.TryGetHero(heroId, out _));
// 				quest.SetProgress(progress);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.GetAccessory)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(AccessoryComponent))]
// 	public class QuestGetAccessory : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 获得x件配饰
// 			await ETTask.CompletedTask;
// 			var accComponent = unit.GetComponent<AccessoryComponent>();
// 			int count = accComponent.AccDic.Count;
// 			quest.SetProgress(count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopEquipMinLevel)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(AccessoryComponent))]
// 	[FriendOf(typeof(EquipItemComponent))]
// 	[FriendOf(typeof(EquipItem))]
// 	public class QuestBattleTroopEquipMinLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵六名角色装备最低达x级
// 			await ETTask.CompletedTask;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			var equipItemComponent = unit.GetComponent<EquipItemComponent>();
// 			int minEquipLevel = 0;
// 			if (heroIds.Count == 6)
// 			{
// 				foreach (int heroId in heroIds)
// 				{
// 					if (!heroComponent.TryGetHero(heroId, out var hero))
// 					{
// 						continue;
// 					}
//
// 					var equipItems = equipItemComponent.GetItems(heroId);
// 					//if (!equipItemComponent.ItemsMap.TryGetValue(heroId, out var equipItems))
// 					//{
// 					//	minEquipLevel = 1;
// 					//	continue;
// 					//}
//
// 					// 一个英雄有三个装备
// 					if (equipItems.Count >= 3)
// 					{
// 						foreach ((int key, var equipItem) in equipItems)
// 						{
// 							int level = heroComponent.GetEquipItemLevel(equipItem.UnitID, equipItem.ConfigID);
// 							if (minEquipLevel == 0 || minEquipLevel > level)
// 							{
// 								minEquipLevel = level;
// 							}
// 						}
// 					}
// 					else
// 					{
// 						minEquipLevel = 1;
// 					}
// 				}
//
// 				quest.SetProgress(minEquipLevel);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleTroopMinLevel)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(AccessoryComponent))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestBattleTroopMinLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 上阵六名角色等级最低达x级
// 			await ETTask.CompletedTask;
// 			var heroIds = ET.BattleTeamHelper.GetHeroIds(unit);
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			int minHeroLevel = 0;
// 			if (heroIds.Count == 6)
// 			{
// 				foreach (int heroId in heroIds)
// 				{
// 					if (!heroComponent.TryGetHero(heroId, out var hero))
// 					{
// 						continue;
// 					}
//
// 					if (minHeroLevel == 0 || minHeroLevel > heroComponent.GetHeroLevel(hero))
// 					{
// 						minHeroLevel = heroComponent.GetHeroLevel(hero);
// 					}
// 				}
//
// 				if (minHeroLevel == 0)
// 				{
// 					minHeroLevel = 1;
// 				}
//
// 				quest.SetProgress(minHeroLevel);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.AccessoryHeroNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(AccessoryComponent))]
// 	public class QuestHandBookTotalStar : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 给N个角色穿戴装扮
// 			await ETTask.CompletedTask;
// 			var accessoryComponent = unit.GetComponent<AccessoryComponent>();
// 			int count = accessoryComponent.UnitAccDic.Count;
// 			quest.SetProgress(count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.FruitHeroNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(EquipFruitComponent))]
// 	public class QuestFruitHeroNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 给N个角色穿戴果实
// 			await ETTask.CompletedTask;
// 			var fruitComponent = unit.GetComponent<EquipFruitComponent>();
// 			int count = fruitComponent.EquipedFruits.Count;
// 			quest.SetProgress(count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.LoginNextDay)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestLoginNextDay : AQuestHandler
// 	{
// 		protected override async ETTask Init(Unit unit, Quest quest)
// 		{
// 			await ETTask.CompletedTask;
// 			// 没有参数时任务初始化，设置参数为明天的时间
// 			long nextDayZeroTimestamp = TimeUtils.GetNextDayZeroTimestamp();
// 			quest.ProgressCache.Add(nextDayZeroTimestamp);
// 		}
//
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 明日登录
// 			await ETTask.CompletedTask;
// 			// 判断大于明日时间算完成任务
// 			long timeStamp = quest.ProgressCache[0];
// 			long serverNow = TimeHelper.ServerNow();
// 			if (serverNow > timeStamp)
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CampHeroNum)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroComponent))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestCampHeroNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 获取指定阵营英雄n个
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			long progress = heroComponent.Heroes.Select(hero => BATTLE_UNIT_Table.Instance.GetOrDefault(hero.UnitId))
// 				.LongCount(battleUnitConfig => BATTLE_UNIT_UITAG_Table.Instance.GetGenre(battleUnitConfig.id) ==
// 												(HeroGenre)quest.Config.Param[0]);
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.PvpToday)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(ArenaTierComponent))]
// 	public class QuestPvpToday : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 今日参与过竞技场
// 			await ETTask.CompletedTask;
// 			long todayUnixTimestamp = TimeUtils.GetTodayZeroTimestamp();
// 			if (unit.GetComponent<ArenaTierComponent>().LastTimeOfFight > todayUnixTimestamp)
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.LoginServerDay)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestLoginServerDay : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 开服n日完成任务
// 			await ETTask.CompletedTask;
// 			int regionOpen = ServerHelper.GetDaysSinceServerOpen(unit.DomainZone());
// 			if (regionOpen >= quest.Config.Param[0])
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroShareLevel)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestHeroShareLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 英雄共鸣等级提升至{0}级
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			int heroLevel = heroComponent.GetShareLevel(); // 获取共鸣等级
// 			quest.SetProgress(heroLevel);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EquipShareLevel)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(HeroShareEquipDatas))]
// 	[FriendOf(typeof(HeroComponent))]
// 	public class QuestEquipShareLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 装备共鸣等级达到{0}级
// 			await ETTask.CompletedTask;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			var shareData = heroComponent.ShareEquipDatas.GetData();
// 			int minLevel = 1;
// 			foreach (var equipItem in shareData.EquipItems)
// 			{
// 				minLevel = Math.Max(equipItem.Level, equipItem.Level);
// 			}
//
// 			quest.SetProgress(minLevel);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.UnlockDungeonNum)]
// 	[FriendOf(typeof(ForestSchoolComponent))]
// 	[FriendOf(typeof(ForestSchoolStage))]
// 	[FriendOf(typeof(ForestSchoolDungeon))]
// 	public class QuestUnlockDungeonNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 累计解锁{0}个区域的黑雾，解锁n个支线
// 			await ETTask.CompletedTask;
// 			int progress = 0;
// 			var forestSchoolComponent = unit.GetComponent<ForestSchoolComponent>();
// 			foreach ((int key, var stage) in forestSchoolComponent.ForestSchoolStage)
// 			{
// 				if (stage.DungeonStages.Count <= 0)
// 				{
// 					continue;
// 				}
//
// 				foreach (var list in stage.DungeonStages)
// 				{
// 					if (list.Value.Pass)
// 					{
// 						progress++;
// 					}
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CumulativePay)]
// 	public class QuestFirstPayment : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 累计付费n元
// 			await ETTask.CompletedTask;
// 			var totalCash = unit.GetComponent<NumericComponent>().GetAsLong(NumericType.TotalCash);
// 			if (quest.Config.RequireNum <= totalCash) quest.Complete();
// 			//bool checkBuyGiftById = unit.GetComponent<FirstPayGiftComponent>().CheckBuyGiftById(FirstPayGiftType.FirstCharge); // 首冲礼包
// 			// if (checkBuyGiftById)
// 			// {
// 			// 	quest.CompleteQuest();
// 			// }
// 		}
// 	}
//
// 	[QuestHandler(QuestType.GiftAfterVIP)]
// 	public class QuestGiftAfterVIP : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 抵达vip等级n
// 			await ETTask.CompletedTask;
// 			var vipComponent = unit.GetComponent<VipComponent>();
// 			quest.SetProgress(vipComponent.CurStage);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ConsecutiveDaysInAnimalArena)]
// 	public class QuestConsecutiveDaysInAnimalArena : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 连续参加动物擂台的天数
// 			await ETTask.CompletedTask;
// 			if (quest.ProgressCache.Count == 0)
// 			{
// 				quest.AddProgress(1);
// 				// 没有参数时任务初始化，设置参数为明天的时间
// 				long nextDayUnixTimestamp = TimeUtils.GetNextDayZeroTimestamp();
// 				quest.ProgressCache.Add(nextDayUnixTimestamp);
// 			}
// 			else
// 			{
// 				// 判断大于明日时间
// 				long timeStamp = quest.ProgressCache[0];
// 				long serverNow = TimeHelper.ServerNow();
// 				if (serverNow < timeStamp)
// 				{
// 					return;
// 				}
//
// 				quest.AddProgress(1);
// 				quest.ProgressCache[0] = TimeUtils.GetNextDayZeroTimestamp(); // 设置参数为明天的时间
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EarnStarsInAnimalArena)]
// 	[FriendOf(typeof(BattleAnimalComponent))]
// 	public class QuestEarnStarsInAnimalArena : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 在动物擂台中获得的星星数
// 			await ETTask.CompletedTask;
// 			var battleAnimalComponent = unit.GetComponent<BattleAnimalComponent>();
// 			int star = 0;
// 			foreach ((int key, var info) in battleAnimalComponent.StageInfos)
// 			{
// 				star += info.MaxStar;
// 			}
//
// 			quest.SetProgress(star);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.PassAnimalArenaLevel)]
// 	[FriendOf(typeof(BattleAnimalComponent))]
// 	public class QuestPassAnimalArenaLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 动物擂台通关第n关
// 			await ETTask.CompletedTask;
// 			var battleAnimalComponent = unit.GetComponent<BattleAnimalComponent>();
// 			if (battleAnimalComponent.CurStagePass >= quest.Config.Param[0])
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ReachRankedArenaPoints)]
// 	[FriendOf(typeof(ArenaTierComponent))]
// 	public class QuestReachRankedArenaPoints : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 段位竞技场达到n积分
// 			await ETTask.CompletedTask;
// 			var tierComponent = unit.GetComponent<ArenaTierComponent>();
// 			quest.SetProgress(tierComponent.Rating);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EgyptStageNormal)]
// 	public class QuestEgyptStageNormal : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 埃及活动通关简单关卡
// 			await ETTask.CompletedTask;
// 			var egyptComponent = unit.GetComponent<ActivityEgyptComponent>();
// 			int stageId = quest.Config.Param[0];
// 			if (egyptComponent.IsStagePass(stageId))
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EgyptStageDifficult)]
// 	public class QuestEgyptStageDifficult : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 埃及活动通关困难关卡
// 			await ETTask.CompletedTask;
// 			var egyptComponent = unit.GetComponent<ActivityEgyptComponent>();
// 			int stageId = quest.Config.Param[0];
// 			if (egyptComponent.IsStagePass(stageId))
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
//
// 	[FriendOf(typeof(HomelandTreeComponent))]
// 	[QuestHandler(QuestType.UpgradeHomeTreeToLevelX)]
// 	public class QuestUpgradeHomeTreeToLevelX : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 家园树等级提升至{0}级
// 			await ETTask.CompletedTask;
// 			var treeComponent = unit.GetComponent<HomelandTreeComponent>();
// 			quest.SetProgress(treeComponent.TreeLevel);
// 		}
// 	}
//
// 	[FriendOf(typeof(MainLineComponent))]
// 	[FriendOf(typeof(Chapter))]
// 	[FriendOf(typeof(Stage))]
// 	[QuestHandler(QuestType.ClearStagesMainline)]
// 	public class QuestClearStagesMainline : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 主线累计通关{0}关
// 			await ETTask.CompletedTask;
// 			long progress = GetProgress(unit, quest.Config);
// 			quest.SetProgress(progress);
// 		}
//
// 		public static long GetProgress(Unit unit, QUEST config)
// 		{
// 			bool hard = config.Param[0] == 1; // 难易程度
// 			long progress = 0;
// 			var mainLineComponent = unit.GetComponent<MainLineComponent>();
// 			if (hard)
// 			{
// 				foreach ((int key, var chapter) in mainLineComponent.Chapters)
// 				{
// 					foreach ((int i, var stage) in chapter.DifficultStages)
// 					{
// 						if (stage.Pass)
// 						{
// 							progress++;
// 						}
// 					}
// 				}
// 			}
// 			else
// 			{
// 				foreach ((int key, var chapter) in mainLineComponent.Chapters)
// 				{
// 					foreach ((int i, var stage) in chapter.Stages)
// 					{
// 						if (stage.Pass)
// 						{
// 							progress++;
// 						}
// 					}
// 				}
// 			}
//
// 			return progress;
// 		}
// 	}
//
// 	[FriendOf(typeof(MainLineComponent))]
// 	[FriendOf(typeof(Chapter))]
// 	[FriendOf(typeof(Stage))]
// 	[FriendOf(typeof(TimeTowerComponent))]
// 	[QuestHandler(QuestType.CollectStarsMainline)]
// 	public class QuestCollectStarsMainline : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 收集一定数量星星
// 			await ETTask.CompletedTask;
// 			long progress = GetProgress(unit, quest.Config);
// 			quest.SetProgress(progress);
// 		}
//
// 		public static long GetProgress(Unit unit, QUEST config)
// 		{
// 			bool hard = config.Param[0] == 1; // 难易程度
// 			long progress = 0;
// 			var mainLineComponent = unit.GetComponent<MainLineComponent>();
// 			if (hard)
// 			{
// 				foreach ((int key, var chapter) in mainLineComponent.Chapters)
// 				{
// 					foreach ((int i, var stage) in chapter.DifficultStages)
// 					{
// 						progress += stage.MaxStar;
// 					}
// 				}
// 			}
// 			else
// 			{
// 				foreach ((int key, var chapter) in mainLineComponent.Chapters)
// 				{
// 					foreach ((int i, var stage) in chapter.Stages)
// 					{
// 						progress += stage.MaxStar;
// 					}
//
// 					//foreach ((int i, var stage) in chapter.DungeonStages)
// 					//{
// 					//	progress += stage.MaxStar;
// 					//}
// 				}
// 			}
//
// 			return progress;
// 		}
// 	}
//
// 	[FriendOf(typeof(Quest))]
// 	[QuestHandler(QuestType.ClearStagesMainlineAcquired)]
// 	public class QuestClearStagesMainlineAcquired : AQuestHandler
// 	{
// 		protected override async ETTask Init(Unit unit, Quest quest)
// 		{
// 			// 主线通关{0}关在获取任务后
// 			await ETTask.CompletedTask;
// 			long progress = QuestClearStagesMainline.GetProgress(unit, quest.Config);
// 			quest.ProgressData = progress.ToString();
// 		}
//
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 主线通关{0}关在获取任务后
// 			await ETTask.CompletedTask;
// 			long progress = QuestClearStagesMainline.GetProgress(unit, quest.Config);
// 			long.TryParse(quest.ProgressData, out long oldProgress);
// 			quest.SetProgress(progress - oldProgress);
// 		}
// 	}
//
// 	[FriendOf(typeof(Quest))]
// 	[QuestHandler(QuestType.CollectStarsMainlineAcquired)]
// 	public class QuestCollectStarsMainlineAcquired : AQuestHandler
// 	{
// 		protected override async ETTask Init(Unit unit, Quest quest)
// 		{
// 			// 主线收集{0}个星星在获取任务后
// 			await ETTask.CompletedTask;
// 			long progress = QuestCollectStarsMainline.GetProgress(unit, quest.Config);
// 			quest.ProgressData = progress.ToString();
// 		}
//
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 主线收集{0}个星星在获取任务后
// 			await ETTask.CompletedTask;
// 			long progress = QuestCollectStarsMainline.GetProgress(unit, quest.Config);
// 			long.TryParse(quest.ProgressData, out long oldProgress);
// 			quest.SetProgress(progress - oldProgress);
// 		}
// 	}
//
// 	[FriendOf(typeof(Quest))]
// 	[QuestHandler(QuestType.ArenaChampionRank)]
// 	[FriendOfAttribute(typeof(ET.Server.ArenaRankComponent))]
// 	public class QuestArenaChampionRank : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 冠军竞技场排名达到N以内
// 			await ETTask.CompletedTask;
// 			int ranking = quest.Config.Param[0];
// 			var arenaComponent = unit.GetComponent<ArenaRankComponent>();
// 			if (arenaComponent.Ranking > 0 && arenaComponent.Ranking <= ranking)
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[FriendOf(typeof(Quest))]
// 	[QuestHandler(QuestType.HeroGemSuitLevelCount)]
// 	[FriendOfAttribute(typeof(ET.Server.ArenaRankComponent))]
// 	[FriendOfAttribute(typeof(ET.HeroComponent))]
// 	public class QuestHeroGemSuitLevelCount : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 英雄宝石套装达到等级数量
// 			await ETTask.CompletedTask;
// 			int needLevel = quest.Config.Param[0];
// 			int progress = HeroGemHelper.GetHeroGemsuitLvCount(unit, needLevel);
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroGemUpgradeToLevel)]
// 	[FriendOfAttribute(typeof(ET.Item))]
// 	public class QuestHeroGemUpgradeToLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 拥有x个y级宝石
// 			await ETTask.CompletedTask;
// 			int targetLevel = quest.Config.Param[0];
// 			int progress = 0;
// 			var bagComponent = unit.GetComponent<BagComponent>();
// 			var itemsByType = bagComponent.GetItemsByType(ItemMainType.Item, ItemSubType.HeroGem);
//
// 			foreach (var item in itemsByType)
// 			{
// 				var gemConfig = HERO_GEM_Table.Instance.GetByItemId(item.ConfigId);
// 				if (gemConfig == null)
// 					continue;
// 				if (gemConfig.Level == targetLevel)
// 				{
// 					progress += item.Count;
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.JoinGuild)]
// 	public class QuestJoinGuild : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 加入帮派
// 			await ETTask.CompletedTask;
// 			var roleInfo = unit.GetComponent<RoleInfo>();
// 			if (roleInfo.GuildId > 0)
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CompleteAllWeeklyQuests)]
// 	public class QuestCompleteAllWeeklyQuestsHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 完成周活的所有任务
// 			await ETTask.CompletedTask;
// 			var component = unit.GetComponent<QuestsComponent>();
// 			var list = component.GetByCategory(QuestCategory.Weekly);
// 			if (list.Count == 0)
// 			{
// 				return;
// 			}
//
// 			if (list.Any(q => !q.IsCompleted()))
// 			{
// 				return;
// 			}
//
// 			quest.Complete();
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.CampTowerReachLevel)]
// 	[FriendOfAttribute(typeof(ET.TimeTowerComponent))]
// 	public class QuestCampTowerReachLevelHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 任意阵营爬塔达到{0}关
// 			await ETTask.CompletedTask;
// 			var timeTowerComponent = unit.GetComponent<TimeTowerComponent>();
// 			// var cfg = quest.Config;
// 			// int towerId = cfg.Param[0];
// 			// if (timeTowerComponent.Towers.TryGetValue(towerId, out var tower))
// 			// {
// 			// 	int sum = tower.Floors.Count(f => f.Pass);
// 			// 	quest.SetProgress(sum);
// 			// }
// 			int max = 0;
// 			foreach ((int key, var tower) in timeTowerComponent.Towers)
// 			{
// 				int sum = tower.Floors.Count(f => f.Pass);
// 				if (max < sum)
// 				{
// 					max = sum;
// 				}
// 			}
//
// 			quest.SetProgress(max);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroUpgradeToStar)]
// 	[FriendOfAttribute(typeof(ET.HeroComponent))]
// 	[FriendOfAttribute(typeof(ET.Hero))]
// 	public class QuestHeroUpgradeToStarHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 将{0}个{1}品质英雄升至{2}星
// 			await ETTask.CompletedTask;
// 			var questConfig = quest.Config;
// 			int quality = questConfig.Param[0];
// 			int star = questConfig.Param[1];
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			long progress = heroComponent.Heroes.Where(hero => hero.GetQuality() == quality)
// 				.LongCount(hero => hero.Star >= star);
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CharacterFriendshipLevel)]
// 	[FriendOf(typeof(FavorabilityComponent))]
// 	public class QuestCharacterFriendshipLevelHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// {0}个角色好感度达到{1}级
// 			await ETTask.CompletedTask;
// 			var questConfig = quest.Config;
// 			int level = questConfig.Param[0];
// 			var favorabilityComponent = unit.GetComponent<FavorabilityComponent>();
// 			int count = 0;
// 			foreach (var (_, info) in favorabilityComponent.HeroFavorabilityDict)
// 			{
// 				if (info.LikelyLv >= level)
// 				{
// 					count++;
// 				}
// 			}
//
// 			quest.SetProgress(count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CharacterFriendshipReach)]
// 	[FriendOf(typeof(FavorabilityComponent))]
// 	public class QuestCharacterFriendshipReachHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// {0}个角色好感度达到{1}级
// 			await ETTask.CompletedTask;
// 			var questConfig = quest.Config;
// 			int heroId = questConfig.Param[0];
// 			var favorabilityComponent = unit.GetComponent<FavorabilityComponent>();
// 			int level = 1;
// 			if (favorabilityComponent.HeroFavorabilityDict.TryGetValue(heroId, out var info))
// 			{
// 				level = info.LikelyLv;
// 			}
//
// 			quest.SetProgress(level);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CraftEquipmentsToYQuality)]
// 	[FriendOfAttribute(typeof(ET.HeroComponent))]
// 	public class QuestCraftEquipmentsToYQualityHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 将{0}件装备打造至{1}品质
// 			await ETTask.CompletedTask;
// 			int quality = quest.Config.Param[0];
// 			int minLevel = 0;
// 			foreach (var item in EQUIP_ITEM_UPGRADE_Table.Instance.DataList)
// 			{
// 				if (item.Quality < quality)
// 				{
// 					continue;
// 				}
//
// 				minLevel = item.MinLevel;
// 				break;
// 			}
//
// 			var heroCom = unit.GetComponent<HeroComponent>();
// 			int progress = 0;
// 			foreach (var data in heroCom.ShareEquipDatas.List)
// 			{
// 				foreach (var item in data.EquipItems)
// 				{
// 					if (item.Level >= minLevel)
// 					{
// 						progress++;
// 					}
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CreateEquipComponents)]
// 	[FriendOfAttribute(typeof(ET.HeroComponent))]
// 	public class QuestCreateEquipComponentsHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 打造{0}个{1}部件
// 			await ETTask.CompletedTask;
// 			int suitId = quest.Config.Param[0];
// 			int suitType = quest.Config.Param[1];
// 			var heroCom = unit.GetComponent<HeroComponent>();
// 			int progress = 0;
// 			foreach (var data in heroCom.ShareEquipDatas.List)
// 			{
// 				var equipConfigs = EQUIP_ITEM_Table.Instance.DataListByUnitID(data.UnitId);
// 				foreach (var value in data.EquipItems)
// 				{
// 					var equipItemCfg = equipConfigs.Find(a => a.Part == value.Part);
// 					if (equipItemCfg == null)
// 						continue;
// 					var suitConfigs =
// 						EQUIP_ITEM_UPGRADE_SUIT_Table.Instance.DataListByUpgradeId(equipItemCfg.UpgradeId);
// 					if (suitConfigs != null)
// 					{
// 						var suitConfig =
// 							suitConfigs.Find(a => a.MinLevel <= value.Level && a.MaxLevel >= value.Level);
// 						if (suitConfig.SuitType < suitType)
// 						{
// 							continue;
// 						}
//
// 						progress++;
// 					}
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EquipmentRefinedLevel)]
// 	[FriendOfAttribute(typeof(ET.EquipItemComponent))]
// 	[FriendOfAttribute(typeof(ET.EquipItem))]
// 	[FriendOfAttribute(typeof(ET.HeroComponent))]
// 	public class QuestEquipmentRefinedLevelHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// {0}件装备精炼至+{1}
// 			await ETTask.CompletedTask;
// 			int level = quest.Config.Param[0];
//
// 			var heroCom = unit.GetComponent<HeroComponent>();
// 			int progress = 0;
// 			foreach (var refineData in heroCom.ShareEquipRefineDatas.List)
// 			{
// 				foreach (var item in refineData.Items)
// 				{
// 					if (item.Level >= level)
// 					{
// 						progress++;
// 					}
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.WearUnspecifiedLevelAndTypeGem)]
// 	[FriendOfAttribute(typeof(ET.HeroComponent))]
// 	public class QuestWearUnspecifiedLevelAndTypeGemHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 镶嵌{0}个{1}级{2}类型宝石
// 			await ETTask.CompletedTask;
// 			var config = quest.Config;
// 			int level = config.Param[0];
// 			int type = config.Param[1];
//
// 			var heroCom = unit.GetComponent<HeroComponent>();
// 			int progress = 0;
// 			foreach (var data in heroCom.ShareGemDatas)
// 			{
// 				foreach (var gem in data.Gems)
// 				{
// 					var gemConfig = gem.Config;
// 					if (type > 0 && gemConfig.Type != type)
// 					{
// 						continue;
// 					}
//
// 					if (gemConfig.Level >= level)
// 					{
// 						progress++;
// 					}
// 				}
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CumulativeMonthlyCardDays)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestCumulativeMonthlyCardDays : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 累计拥有月卡{0}天
// 			// 逻辑：每次登录，检查这个人是否有月卡没过期；开通月卡时也走一遍逻辑
// 			await ETTask.CompletedTask;
// 			long todayZeroTime = TimeUtils.GetTodayZeroTimestamp();
// 			long lastLoginZeroTime = 0;
// 			if (!string.IsNullOrWhiteSpace(quest.ProgressData))
// 			{
// 				long.TryParse(quest.ProgressData, out lastLoginZeroTime);
// 			}
//
// 			if (lastLoginZeroTime != todayZeroTime)
// 			{
// 				if (ET.BusinessCardsHelper.IsValid(unit, BusinessCardType.Monthly))
// 				{
// 					quest.AddProgress(1);
// 					quest.ProgressData = todayZeroTime.ToString();
// 				}
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ConsecutiveRechargeDays)]
// 	[FriendOfAttribute(typeof(ET.Quest))]
// 	public class QuestConsecutiveRechargeDays : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 连续充值{0}天
// 			// 逻辑：当天有充值，则进度加1
// 			await ETTask.CompletedTask;
// 			long todayZeroTime = TimeUtils.GetTodayZeroTimestamp();
// 			long lastRechargeZeroTime = 0;
// 			if (!string.IsNullOrWhiteSpace(quest.ProgressData))
// 			{
// 				long.TryParse(quest.ProgressData, out lastRechargeZeroTime);
// 			}
//
// 			if (lastRechargeZeroTime != todayZeroTime)
// 			{
// 				quest.AddProgress(1);
// 				quest.ProgressData = todayZeroTime.ToString();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CumulativeRechargeAmountReached)]
// 	public class QuestCumulativeRechargeAmountReached : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 累计充值额度达到{0}
// 			await ETTask.CompletedTask;
// 			var numericComponent = unit.GetComponent<NumericComponent>();
// 			long progress = numericComponent[NumericType.TotalCash]; // 充值总额，国内是人民币分，国外是美元分
// 			decimal cash = (decimal)progress / 100;
// 			quest.SetProgress((int)cash);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.RechargeTimesInSpecifiedPeriod)]
// 	[FriendOfAttribute(typeof(ET.Quest))]
// 	public class QuestRechargeTimesInSpecifiedPeriod : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// {指定周期内}充值{1}次
// 			await ETTask.CompletedTask;
// 			// 逻辑：记录指定充值的时间戳，当超出指定周期的时候，重置进度
// 			var config = quest.Config;
// 			int range = config.Param[0];
// 			var list = new List<long>();
// 			if (!string.IsNullOrWhiteSpace(quest.ProgressData))
// 			{
// 				var fromJson = JsonHelper.FromJson<List<long>>(quest.ProgressData);
// 				list.AddRange(fromJson);
// 			}
//
// 			long serverNow = TimeHelper.ServerNow();
// 			list.Add(serverNow);
// 			list.RemoveAll(l => l < serverNow - TimeHelper.OneDay * range);
// 			quest.SetProgress(list.Count);
// 			quest.ProgressData = JsonHelper.ToJson(list);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.CampSkillCount)]
// 	[FriendOf(typeof(BattleGeneraSkillComponent))]
// 	public class QuestCampSkillCount : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 拥有x个阵营技
// 			await ETTask.CompletedTask;
// 			var com = unit.GetComponent<BattleGeneraSkillComponent>();
// 			quest.SetProgress(com.Items.Count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.FettersLevelReach)]
// 	[FriendOf(typeof(FavorabilityComponent))]
// 	public class FavorabilityFettersLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// 好感度总等级达到x
// 			await ETTask.CompletedTask;
// 			var favorCom = unit.GetComponent<FavorabilityComponent>();
// 			quest.SetProgress(favorCom.FettersLv);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CombatPowerReach)]
// 	[FriendOfAttribute(typeof(ET.HeroComponent))]
// 	[FriendOfAttribute(typeof(ET.TurtleComponent))]
// 	[FriendOfAttribute(typeof(ET.Hero))]
// 	public class QuestCombatPowerReach : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			await ETTask.CompletedTask;
// 			long power = unit.GetComponent<NumericComponent>()[NumericType.BattleTroopPower];
// 			quest.SetProgress(power);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.PlayerLevelReach)]
// 	[FriendOfAttribute(typeof(ET.TurtleComponent))]
// 	public class QuestPlayerLevelReach : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			await ETTask.CompletedTask;
// 			var level = unit.GetComponent<TurtleComponent>().Level;
// 			quest.SetProgress(level);
// 		}
// 	}
// }