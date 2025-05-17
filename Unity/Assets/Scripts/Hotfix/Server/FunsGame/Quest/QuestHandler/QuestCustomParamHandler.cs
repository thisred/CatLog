// using System.Collections.Generic;
// using System.Linq;
// using ET.Client.Battle;
//
// // 自定义参数的任务
// namespace ET.Server
// {
// 	[QuestHandler(QuestType.OpenBoxTypeTimes)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestOpenBoxTypeTimes : AQuestHandler<OpenBoxTypeTimes>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, OpenBoxTypeTimes args)
// 		{
// 			// 开启指定宝箱x次
// 			await ETTask.CompletedTask;
// 			var boxType = (TreasureBoxType)quest.Config.Param[0];
// 			if (boxType != args.BoxType)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.Count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.FightWithHero)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestFightWithHero : AQuestHandler<FightWithHero>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FightWithHero args)
// 		{
// 			// 用x英雄战斗一次
// 			await ETTask.CompletedTask;
// 			var hashSet = args.HeroSet;
// 			if (!hashSet.Contains(quest.Config.Param[0]))
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(1);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HangUpGetItem)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestHangUpGetItem : AQuestHandler<HangUpGetItem>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HangUpGetItem args)
// 		{
// 			// 挂机获得x物品
// 			await ETTask.CompletedTask;
// 			if (args.TargetId != quest.Config.Param[0])
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.Count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleSuccessHeroNum)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBattleSuccessHeroNum : AQuestHandler<BattleSuccessHeroNum>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BattleSuccessHeroNum args)
// 		{
// 			// 使用x个英雄战斗胜利
// 			await ETTask.CompletedTask;
// 			int useHeroNum = args.UseHeroNum;
// 			if (useHeroNum != quest.Config.RequireNum)
// 			{
// 				return;
// 			}
//
// 			quest.SetProgress(useHeroNum);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EasterEggHero)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestEasterEggHero : AQuestHandler<EasterEggHero>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, EasterEggHero args)
// 		{
// 			// 触发英雄彩蛋
// 			await ETTask.CompletedTask;
// 			int heroId = args.HeroId;
// 			if (quest.Config.Param[0] != heroId)
// 			{
// 				return;
// 			}
//
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			if (!heroComponent.HeroDict.ContainsKey(heroId))
// 			{
// 				// 没有这个英雄
// 				return;
// 			}
//
// 			quest.AddProgress(args.Count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EasterEggHeroAnimation)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestEasterEggHeroAnimation : AQuestHandler<EasterEggHeroAnimation>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, EasterEggHeroAnimation args)
// 		{
// 			// 触发英雄彩蛋
// 			await ETTask.CompletedTask;
// 			int heroId = args.HeroId;
//
// 			// Gx_#erha_bug，策划配表问题导致的。等策划配表正确后删掉这一批(全局搜 Gx_#erha_bug)打印。
// 			// Log.Warning($"二哈彩蛋_ 伊隆亲王 ！ {heroId}    看下配置：{quest.Config.Id}");
//
//
// 			if (!quest.Config.Param.Contains(heroId))
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.Count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EasterEggUI)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestEasterEggUI : AQuestHandler<EasterEggUI>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, EasterEggUI args)
// 		{
// 			// 触发UI界面彩蛋
// 			await ETTask.CompletedTask;
// 			int uiConstId = args.UIConstId;
// 			if (quest.Config.Param[0] != uiConstId)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.Count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.KillNumUseHeroOneBattle)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestKillNumUseHeroOneBattle : AQuestHandler<KillNumUseHeroOneBattle>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, KillNumUseHeroOneBattle args)
// 		{
// 			// 单场战斗用x英雄击败y个敌人
// 			await ETTask.CompletedTask;
// 			var unitKillNumDic = args.KillNumDic;
// 			int sum = 0;
//
// 			//foreach (var item in unitKillNumDic)
// 			//{
// 			//	Log.Warning($"##英雄ID: {item.Key} 、     击杀敌人个数: {item.Value}");
// 			//}
//
// 			foreach (int unitId in quest.Config.Param)
// 			{
// 				// Log.Warning($"-------- 参数: {unitId}");
// 				if (unitKillNumDic.TryGetValue(unitId, out int num))
// 				{
// 					sum += num;
// 				}
// 			}
//
// 			quest.SetProgress(sum);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.KillNumUseHero)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestKillNumUseHero : AQuestHandler<KillNumUseHero>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, KillNumUseHero args)
// 		{
// 			// 用x英雄击败y个敌人
// 			await ETTask.CompletedTask;
// 			var unitKillNumDic = args.KillNumDic;
// 			int sum = 0;
// 			foreach (int unitId in quest.Config.Param)
// 			{
// 				if (unitKillNumDic.TryGetValue(unitId, out int num))
// 				{
// 					sum += num;
// 				}
// 			}
//
// 			quest.AddProgress(sum);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.DestroyBuilding)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestDestroyBuilding : AQuestHandler<DestroyBuilding>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, DestroyBuilding args)
// 		{
// 			// 摧毁敌方x个建筑
// 			await ETTask.CompletedTask;
// 			var killNumDic = args.KillNumDic;
// 			int sum = 0;
// 			foreach ((int monsterId, int num) in killNumDic)
// 			{
// 				var battleUnit = BATTLE_UNIT_Table.Instance.GetOrDefault(monsterId);
// 				if (battleUnit.unit_tag.Contains(Tags.Tower))
// 				{
// 					sum += num;
// 				}
// 			}
//
// 			quest.AddProgress(sum);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroDieNum)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestHeroDieNum : AQuestHandler<HeroDieNum>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HeroDieNum args)
// 		{
// 			// x英雄共死亡y次
// 			await ETTask.CompletedTask;
// 			var beKillNum = args.BeKillNum;
// 			if (!beKillNum.TryGetValue(quest.Config.Param[0], out int dieNum))
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(dieNum);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroDieNumOneBattle)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestHeroDieNumOneBattle : AQuestHandler<HeroDieNumOneBattle>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HeroDieNumOneBattle args)
// 		{
// 			// 单场战斗x英雄死亡y次
// 			await ETTask.CompletedTask;
// 			var beKillNum = args.BeKillNum;
// 			if (!beKillNum.TryGetValue(quest.Config.Param[0], out int dieNum))
// 			{
// 				return;
// 			}
//
// 			quest.SetProgress(dieNum);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SkillView)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSkillView : AQuestHandler<SkillView>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SkillView args)
// 		{
// 			// 技能详情界面停留时间触发
// 			await ETTask.CompletedTask;
// 			quest.AddProgress(args.Value);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.KillTargetEnemy)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestKillTargetEnemy : AQuestHandler<KillTargetEnemy>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, KillTargetEnemy args)
// 		{
// 			// 击杀指定敌人
// 			await ETTask.CompletedTask;
// 			var killNumDic = args.KillNumDic;
// 			if (!killNumDic.TryGetValue(quest.Config.Param[0], out int value))
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(value);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SkillIconClickNoRepeat)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSkillIconClickNoRepeat : AQuestHandler<SkillIconClickNoRepeat>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SkillIconClickNoRepeat args)
// 		{
// 			// 点击不重复技能图标次数
// 			await ETTask.CompletedTask;
// 			int heroId = args.HeroId;
// 			int skillIndex = args.SkillIndex;
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			if (!heroComponent.HeroDict.ContainsKey(heroId))
// 			{
// 				// 没有这个英雄
// 				return;
// 			}
//
// 			int skillParam = heroId * 10 + skillIndex; // 英雄id * 10 + 技能index，用来区分不同英雄的不同技能
// 			if (!quest.ProgressCache.Contains(skillParam))
// 			{
// 				quest.AddProgress(args.Count);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SkillIconClickOneHero)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSkillIconClickOneHero : AQuestHandler<SkillIconClickOneHero>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SkillIconClickOneHero args)
// 		{
// 			// 点击x英雄技能图标次数
// 			await ETTask.CompletedTask;
// 			int heroId = args.HeroId;
// 			int skillIndex = args.SkillIndex;
// 			if (heroId != quest.Config.Param[0])
// 			{
// 				return;
// 			}
//
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			if (!heroComponent.HeroDict.ContainsKey(heroId))
// 			{
// 				// 没有这个英雄
// 				return;
// 			}
//
// 			if (!quest.ProgressCache.Contains(skillIndex))
// 			{
// 				quest.AddProgress(args.Count);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SkillViewNoRepeat)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSkillViewNoRepeat : AQuestHandler<SkillViewNoRepeat>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SkillViewNoRepeat args)
// 		{
// 			// 不重复技能详情界面停留时间触发成就
// 			await ETTask.CompletedTask;
// 			int time = args.Time;
// 			int heroId = args.HeroId;
// 			int skillIndex = args.SkillIndex;
// 			if (time < quest.Config.Param[0])
// 			{
// 				return;
// 			}
//
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			if (!heroComponent.HeroDict.ContainsKey(heroId))
// 			{
// 				// 没有这个英雄
// 				return;
// 			}
//
// 			int skillParam = heroId * 10 + skillIndex; // 英雄id * 10 + 技能index，用来区分不同英雄的不同技能
// 			if (!quest.ProgressCache.Contains(skillParam))
// 			{
// 				quest.AddProgress(args.Count);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SkillViewOneHero)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSkillViewOneHero : AQuestHandler<SkillViewOneHero>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SkillViewOneHero args)
// 		{
// 			// x英雄技能详情界面停留时间触发成就
// 			await ETTask.CompletedTask;
// 			int time = args.Time;
// 			int heroId = args.HeroId;
// 			if (heroId != quest.Config.Param[1])
// 			{
// 				return;
// 			}
//
// 			int skillIndex = args.SkillIndex;
// 			if (time < quest.Config.Param[0])
// 			{
// 				return;
// 			}
//
// 			var heroComponent = unit.GetComponent<HeroComponent>();
// 			if (!heroComponent.HeroDict.ContainsKey(heroId))
// 			{
// 				// 没有这个英雄
// 				return;
// 			}
//
// 			if (!quest.ProgressCache.Contains(skillIndex))
// 			{
// 				quest.AddProgress(args.Count);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SkillCastCount)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSkillCastCount : AQuestHandler<SkillCastCount>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SkillCastCount args)
// 		{
// 			// 技能释放次数
// 			await ETTask.CompletedTask;
// 			var skillNumDic = args.SkillNumDic;
// 			if (skillNumDic.TryGetValue(quest.Config.ParamString[0], out int value))
// 			{
// 				quest.AddProgress(value);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SkillCastCountOneBattle)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSkillCastCountOneBattle : AQuestHandler<SkillCastCountOneBattle>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SkillCastCountOneBattle args)
// 		{
// 			// 单场战斗技能释放次数
// 			await ETTask.CompletedTask;
// 			var skillNumDic = args.SkillNumDic;
//
//
// 			//foreach (var item in skillNumDic)
// 			//{
// 			//	Log.Warning($"技能名称: {item.Key} 、     次数: {item.Value}");
// 			//}
// 			//if (!skillNumDic.TryGetValue(quest.Config.ParamString[0], out int vss))
// 			//{
// 			//	Log.Warning($"-------  没有找到猪猪技能  -------: {quest.Config.ParamString[0]} ");
// 			//}
//
//
// 			if (skillNumDic.TryGetValue(quest.Config.ParamString[0], out int value))
// 			{
// 				quest.SetProgress(value);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleSuccessStar)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBattleSuccessStar : AQuestHandler<BattleSuccessStar>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BattleSuccessStar args)
// 		{
// 			// 战斗获胜星级
// 			await ETTask.CompletedTask;
// 			int stageType = (int)args.BattleType;
// 			int stageId = args.StageId;
// 			int questStageType = quest.Config.Param[1];
// 			int questStageId = quest.Config.Param[2];
// 			if (questStageType == stageType && questStageId == stageId)
// 			{
// 				quest.SetProgress(args.SuccessStar);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleWithTroop)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBattleWithTroop : AQuestHandler<BattleWithTroop>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BattleWithTroop args)
// 		{
// 			// 用x阵容完成y次战斗
// 			await ETTask.CompletedTask;
// 			// int troopId = quest.Config.Param[0];
// 			// var troopRecommend = BATTLE_TROOP_RECOMMEND_Table.Instance.DataListById(troopId)[0];
// 			// bool complete = troopRecommend.HeroIds.All(heroId => args.HeroSet.Contains(heroId));
// 			// if (complete)
// 			// {
// 			// 	quest.AddProgress(1);
// 			// }
// 		}
// 	}
//
// 	[QuestHandler(QuestType.GetItemInTimePeriod)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestGetItem : AQuestHandler<GetItemInTimePeriod>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, GetItemInTimePeriod args)
// 		{
// 			//获得某物品x个
// 			await ETTask.CompletedTask;
// 			int itemId = quest.Config.Param[0];
// 			if (args.ItemId != itemId)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.AddNum);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.GetItemCount)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestGetItemCount : AQuestHandler<GetItemCount>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, GetItemCount args)
// 		{
// 			//当前获得某物品x个
// 			await ETTask.CompletedTask;
// 			var numericComponent = unit.GetComponent<NumericComponent>();
// 			var bagComponent = unit.GetComponent<BagComponent>();
// 			int itemId = quest.Config.Param[0];
// 			if (args.ItemId != itemId || args.AddNum <= 0)
// 			{
// 				return;
// 			}
//
// 			var item = ITEM_Table.Instance.GetOrDefault(itemId);
// 			long progress = 0;
// 			switch (item.MainType)
// 			{
// 				case ItemMainType.Coin:
// 					progress = numericComponent.GetAsLong(itemId);
// 					break;
// 				case ItemMainType.Item:
// 					progress = bagComponent.GetItemCountByConfigID(itemId);
// 					break;
// 			}
//
// 			quest.SetProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.DrawCardGetHero)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestDrawCardGetHero : AQuestHandler<DrawCardGetHero>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, DrawCardGetHero args)
// 		{
// 			//累计获得完整角色卡牌
// 			await ETTask.CompletedTask;
// 			int count = args.Result.Select(drawItemInfo => ITEM_Table.Instance.Get(drawItemInfo.ItemId))
// 				.Count(item => item.SubType == ItemSubType.Card);
// 			quest.AddProgress(count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HitFlyNumBattleType)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestHitFlyNum : AQuestHandler<HitFlyNum>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HitFlyNum args)
// 		{
// 			//累计在x类型战斗中击飞y个敌人
// 			await ETTask.CompletedTask;
// 			if (!quest.Config.Param.Contains((int)args.BattleType))
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.Num);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HitBackNumBattleType)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestHitBackNum : AQuestHandler<HitBackNum>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HitBackNum args)
// 		{
// 			//累计在x类型战斗中击退y个敌人
// 			await ETTask.CompletedTask;
// 			if (!quest.Config.Param.Contains((int)args.BattleType))
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.Num);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CharmNumBattleType)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestCharmNum : AQuestHandler<CharmNum>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, CharmNum args)
// 		{
// 			//累计魅惑x个敌人
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param[0] != (int)args.StageType)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.Num);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BuyItemNumWithQuality)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBuyItemNumWithQuality : AQuestHandler<BuyItemNumWithQuality>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BuyItemNumWithQuality args)
// 		{
// 			//累计购买红色品质物品x次
// 			await ETTask.CompletedTask;
// 			bool hasQuality = false;
// 			foreach (var itemInfo in args.ItemInfos)
// 			{
// 				var itemCfg = ITEM_Table.Instance.Get(itemInfo.ItemConfigId);
// 				if (itemCfg.Quality == (ItemQuality)quest.Config.Param[0])
// 				{
// 					hasQuality = true;
// 					break;
// 				}
// 			}
//
// 			if (hasQuality)
// 			{
// 				quest.AddProgress(1);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HighDifficulty)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestHighDifficulty : AQuestHandler<HighDifficulty>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HighDifficulty args)
// 		{
// 			//高难度挑战关卡
// 			await ETTask.CompletedTask;
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BuyItemWithShop)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBuyItemWithShop : AQuestHandler<BuyItemWithShop>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BuyItemWithShop args)
// 		{
// 			//指定商店购买一次物品
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param[0] != args.ShopId)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.ItemInfos.Count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BuyItemWithTopShop)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBuyItemWithTopShop : AQuestHandler<BuyItemWithTopShop>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BuyItemWithTopShop args)
// 		{
// 			//指定商店购买一次物品
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param[0] != args.TopShopId)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.ItemInfos.Count);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.CompleteAssignedQuest)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestCompleteAssignedQuestHandler : AQuestHandler<CompleteAssignedQuest>
// 	{
// 		protected override async ETTask Init(Unit unit, Quest quest)
// 		{
// 			await ETTask.CompletedTask;
// 			var questsComponent = unit.GetComponent<QuestsComponent>();
// 			var targetQuest = questsComponent.GetQuest(quest.Config.Param[0]);
// 			if (targetQuest != null && targetQuest.IsCompleted())
// 			{
// 				quest.Complete();
// 			}
// 		}
//
// 		protected override async ETTask Run(Unit unit, Quest quest, CompleteAssignedQuest args)
// 		{
// 			//完成指定任务
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param[0] != args.ConfigId)
// 			{
// 				return;
// 			}
//
// 			quest.Complete();
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BossBattleLevelTimes)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBossBattleLevelQuestHandler : AQuestHandler<BossBattleLevelTimes>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BossBattleLevelTimes args)
// 		{
// 			//参与{0}难度BOSS挑战{0}次,主要是无尽模式
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param[0] != args.Level)
// 			{
// 				return;
// 			}
//
// 			quest.Complete();
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BossKillLevel)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBossKillLevelQuestHandler : AQuestHandler<BossKillLevel>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BossKillLevel args)
// 		{
// 			//击败任意{0}难度BOSS挑战的首领
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param[0] != args.Level)
// 			{
// 				return;
// 			}
//
// 			quest.Complete();
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ArenaTimesToday)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestArenaTimesTodayQuestHandler : AQuestHandler<ArenaTimesToday>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, ArenaTimesToday args)
// 		{
// 			//当天参与竞技场{0}次
// 			await ETTask.CompletedTask;
// 			long todayZeroTimestamp = TimeUtils.GetTodayZeroTimestamp();
// 			if (quest.ProgressCache.Count == 0)
// 			{
// 				quest.ProgressCache.Add(todayZeroTimestamp);
// 				quest.AddProgress(1);
// 			}
// 			else
// 			{
// 				if (quest.ProgressCache[0] != todayZeroTimestamp)
// 				{
// 					quest.ProgressCache[0] = todayZeroTimestamp;
// 					quest.SetProgress(1);
// 				}
// 				else
// 				{
// 					quest.AddProgress(1);
// 				}
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EndlessRainforestTimesToday)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestEndlessRainforestTimesTodayHandler : AQuestHandler<EndlessRainforestTimesToday>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, EndlessRainforestTimesToday args)
// 		{
// 			//当天挑战{0}次挂机关卡，就是爬塔
// 			await ETTask.CompletedTask;
// 			long todayZeroTimestamp = TimeUtils.GetTodayZeroTimestamp();
// 			if (quest.ProgressCache.Count == 0)
// 			{
// 				quest.ProgressCache.Add(todayZeroTimestamp);
// 				quest.AddProgress(1);
// 			}
// 			else
// 			{
// 				if (quest.ProgressCache[0] != todayZeroTimestamp)
// 				{
// 					quest.ProgressCache[0] = todayZeroTimestamp;
// 					quest.SetProgress(1);
// 				}
// 				else
// 				{
// 					quest.AddProgress(1);
// 				}
// 			}
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.LimitTowerTimesToday)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestLimitTowerTimesTodayHandler : AQuestHandler<LimitTowerTimesToday>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, LimitTowerTimesToday args)
// 		{
// 			//当天挑战{0}次分阵营爬塔
// 			await ETTask.CompletedTask;
// 			long todayZeroTimestamp = TimeUtils.GetTodayZeroTimestamp();
// 			if (quest.ProgressCache.Count == 0)
// 			{
// 				quest.ProgressCache.Add(todayZeroTimestamp);
// 				quest.AddProgress(1);
// 			}
// 			else
// 			{
// 				if (quest.ProgressCache[0] != todayZeroTimestamp)
// 				{
// 					quest.ProgressCache[0] = todayZeroTimestamp;
// 					quest.SetProgress(1);
// 				}
// 				else
// 				{
// 					quest.AddProgress(1);
// 				}
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BossBattleTimesToday)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBossBattleTimesTodayHandler : AQuestHandler<BossBattleTimesToday>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BossBattleTimesToday args)
// 		{
// 			//今日boss挑战n次
// 			await ETTask.CompletedTask;
// 			long todayZeroTimestamp = TimeUtils.GetTodayZeroTimestamp();
// 			if (quest.ProgressCache.Count == 0)
// 			{
// 				quest.ProgressCache.Add(todayZeroTimestamp);
// 				quest.AddProgress(1);
// 			}
// 			else
// 			{
// 				if (quest.ProgressCache[0] != todayZeroTimestamp)
// 				{
// 					quest.ProgressCache[0] = todayZeroTimestamp;
// 					quest.SetProgress(1);
// 				}
// 				else
// 				{
// 					quest.AddProgress(1);
// 				}
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BattleSuccessWithType)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestBattleSuccessWithTypeHandler : AQuestHandler<BattleSuccessWithType>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BattleSuccessWithType args)
// 		{
// 			//完成{0}场任意战斗
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param.Count > 0 && (StageType)quest.Config.Param[0] != args.StageType)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(1);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SpinSameSealTimes)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestSpinSameSealTimesHandler : AQuestHandler<SpinSameSealTimes>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SpinSameSealTimes args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			if (quest.Config.Param[0] != args.SameCount)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(1);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.ItemCost)]
// 	[FriendOf(typeof(Quest))]
// 	public class ItemCostHandler : AQuestHandler<QuestCostItem>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, QuestCostItem args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			if (quest.Config.Param[0] != args.ItemId)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(args.Count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CardsInTenDraw)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestCardsInTenDrawHandler : AQuestHandler<CardsInTenDraw>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, CardsInTenDraw args)
// 		{
// 			// 单次十连出了两张及以上红卡整卡
// 			await ETTask.CompletedTask;
// 			quest.SetProgress(args.AdvancedCount);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.NoAdvancedCardsInDraw)]
// 	public class QuestNoAdvancedCardsInDrawHandler : AQuestHandler<NoAdvancedCardsInDraw>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, NoAdvancedCardsInDraw args)
// 		{
// 			//连续三次十连没出整卡
// 			await ETTask.CompletedTask;
// 			if (args.ContainsCard)
// 			{
// 				// 如果抽到了卡，那就归零
// 				quest.SetProgress(0);
// 			}
// 			else
// 			{
// 				// 如果没抽到卡，那就加1
// 				quest.AddProgress(1);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ConsecutiveVictories)]
// 	public class QuestConsecutiveVictoriesHandler : AQuestHandler<ConsecutiveVictories>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, ConsecutiveVictories args)
// 		{
// 			//连续胜利次数30次
// 			await ETTask.CompletedTask;
// 			if (args.Victory)
// 			{
// 				quest.AddProgress(1);
// 			}
// 			else
// 			{
// 				quest.SetProgress(0);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ConsecutiveDefeats)]
// 	public class QuestConsecutiveDefeatsHandler : AQuestHandler<ConsecutiveDefeats>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, ConsecutiveDefeats args)
// 		{
// 			//连续失败次数30次
// 			await ETTask.CompletedTask;
// 			if (args.Victory)
// 			{
// 				quest.SetProgress(0);
// 			}
// 			else
// 			{
// 				quest.AddProgress(1);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.EarnPointsInMiniGame)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestEarnPointsInMiniGameHandler : AQuestHandler<EarnPointsInMiniGame>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, EarnPointsInMiniGame args)
// 		{
// 			//在xxx小游戏中获得xxx积分
// 			await ETTask.CompletedTask;
// 			if (args.CasualGameType == (CasualGameType)quest.Config.Param[0])
// 			{
// 				//if (args.CasualGameType == CasualGameType.Game2048)
// 				//{
// 				//	Log.Warning($"this is tmd 2048 :   {args.Points}");
// 				//}
// 				//else
// 				//{
// 				//	Log.Warning($"成就任务(老虎机积分)   看下加没加 :   {args.Points}");
// 				//}
//
// 				// 别忘了在对应的小游戏结束后更新任务进度
// 				// 不过小游戏不是(鸭子，脖子，上勾拳，消消乐么)， 这儿怎么是：老虎机 和 2048 ?  先改bug ..
// 				// QuestHelper.Run(player, QuestType.MaxDamage, info.MaxDamage);
//
// 				quest.AddProgress(args.Points);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.BossFirstKill)]
// 	public class QuestBossFirstKillHandler : AQuestHandler<BossFirstKill>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, BossFirstKill args)
// 		{
// 			//Boss全服首次击杀
// 			await ETTask.CompletedTask;
// 			if (args.BossId == quest.Config.Param[0] &&
// 				args.Difficulty == quest.Config.Param[1])
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroLevelUpgrade)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestHeroLevelUpgradeHandler : AQuestHandler<HeroLevelUpgrade>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HeroLevelUpgrade args)
// 		{
// 			// 将x个英雄升级y级
// 			await ETTask.CompletedTask;
// 			var data = new Dictionary<int, long>();
// 			if (!string.IsNullOrWhiteSpace(quest.ProgressData))
// 			{
// 				data = JsonHelper.Deserialize<Dictionary<int, long>>(quest.ProgressData);
// 			}
//
// 			if (!data.TryAdd(args.Hero.UnitId, args.LevelUpCount))
// 			{
// 				data[args.Hero.UnitId] += args.LevelUpCount;
// 			}
//
// 			quest.ProgressData = JsonHelper.Serialize(data);
// 			int count = data.Count(pair => pair.Value >= quest.Config.Param[0]);
// 			quest.SetProgress(count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroStarUpgrade)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(Hero))]
// 	public class QuestHeroStarUpgradeHandler : AQuestHandler<HeroStarUpgrade>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HeroStarUpgrade args)
// 		{
// 			// 将x个英雄升级y星
// 			await ETTask.CompletedTask;
// 			var data = new Dictionary<int, long>();
// 			if (!string.IsNullOrWhiteSpace(quest.ProgressData))
// 			{
// 				data = JsonHelper.Deserialize<Dictionary<int, long>>(quest.ProgressData);
// 			}
//
// 			if (!data.TryAdd(args.Hero.UnitId, args.StarUpCount))
// 			{
// 				data[args.Hero.UnitId] += args.StarUpCount;
// 			}
//
// 			quest.ProgressData = JsonHelper.Serialize(data);
// 			int count = data.Count(pair => pair.Value >= quest.Config.Param[0]);
// 			quest.SetProgress(count);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ArenaRankUsePickChallengeCount)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestArenaRankUsePickChallengeCountHandler : AQuestHandler<QuestValueParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, QuestValueParam args)
// 		{
// 			await ETTask.CompletedTask;
// 			int needPickNum = quest.Config.Param[0];
// 			if (args.Value < needPickNum) return;
// 			quest.AddProgress(1);
// 		}
// 	}
// 	
// 	[QuestHandler(QuestType.ArenaRankUsePickWinCount)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestArenaRankUsePickWinCountHandler : AQuestHandler<QuestValueParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, QuestValueParam args)
// 		{
// 			await ETTask.CompletedTask;
// 			int needPickNum = quest.Config.Param[0];
// 			if (args.Value < needPickNum) return;
// 			quest.AddProgress(1);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ArenaRankRankingTop)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestArenaRankRankingTopHandler : AQuestHandler<QuestValueParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, QuestValueParam args)
// 		{
// 			await ETTask.CompletedTask;
// 			if (args.Value <= quest.Config.RequireNum)
// 			{
// 				quest.SetProgress(quest.Config.RequireNum);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CheckInAccumulated)]
// 	public class QuestCheckInAccumulatedHandler : AQuestHandler<QuestValueParam>
// 	{
// 		protected override async ETTask Init(Unit unit, Quest quest)
// 		{
// 			await ETTask.CompletedTask;
// 			long value = unit.GetComponent<NumericComponent>()[NumericType.CheckInTimes];
// 			quest.SetProgress(value);
// 		}
//
// 		protected override async ETTask Run(Unit unit, Quest quest, QuestValueParam args)
// 		{
// 			await ETTask.CompletedTask;
// 			quest.SetProgress(args.Value);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.TeamRecommendWatchVideo)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestRecTroopBattle : AQuestHandler<TeamRecommendWatchVideo>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, TeamRecommendWatchVideo args)
// 		{
// 			// 阵容收集查看演示视频
// 			await ETTask.CompletedTask;
// 			int troopId = quest.Config.Param[0];
// 			if (troopId != args.RecTroopId)
// 			{
// 				return;
// 			}
//
// 			quest.AddProgress(1);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.PurchaseItemInHomeStoreXTimes)]
// 	public class QuestPurchaseItemInHomeStoreXTimes : AQuestHandler<PurchaseItemInHomeStoreXTimes>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, PurchaseItemInHomeStoreXTimes args)
// 		{
// 			// 在家园商城购买指定物品{0}次
// 			await ETTask.CompletedTask;
// 			int itemId = quest.Config.Param[0];
// 			long progress = args.ItemDict.GetValueOrDefault(itemId);
// 			quest.AddProgress(progress);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.CollectCoinsInHomeXTimes)]
// 	public class QuestCollectCoinsInHomeXTimes : AQuestHandler<CollectCoinsInHomeXTimes>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, CollectCoinsInHomeXTimes args)
// 		{
// 			// 在家园中累计拾取金币{0}枚
// 			await ETTask.CompletedTask;
// 			int itemId = quest.Config.Param[0]; // 金币Id
// 			long progress = args.ItemDict.GetValueOrDefault(itemId);
// 			quest.AddProgress(progress);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.HatchHeroesOfQualityXTimes)]
// 	public class QuestHatchHeroesOfQualityXTimes : AQuestHandler<HatchHeroesOfQualityXTimes>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, HatchHeroesOfQualityXTimes args)
// 		{
// 			// 完成指定品质英雄的孵化{0}次
// 			await ETTask.CompletedTask;
// 			int quality = quest.Config.Param[0];
// 			int progress = 0;
// 			foreach ((int heroId, int num) in args.HatchHeroesOfQualityNum)
// 			{
// 				var heroCfg = HOMELAND_HERO_Table.Instance.GetByHeroId(heroId);
// 				var unitCfg = BATTLE_UNIT_Table.Instance.GetOrDefault(heroCfg.DeckHeroId);
// 				if ((int)unitCfg.quality == quality)
// 				{
// 					progress += num;
// 				}
// 			}
//
// 			quest.AddProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.SatisfyHeroNeedsInHomeXTimes)]
// 	public class QuestSatisfyHeroNeedsInHomeXTimes : AQuestHandler<SatisfyHeroNeedsInHomeXTimes>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, SatisfyHeroNeedsInHomeXTimes args)
// 		{
// 			// 在家园中满足英雄的任意/ 指定需求{0}次
// 			await ETTask.CompletedTask;
// 			int progress = 0;
// 			// 指定需求
// 			if (quest.Config.Param.Count > 0)
// 			{
// 				int targetNeedId = quest.Config.Param[0];
// 				args.SatisfyHeroNeedsInHomeNumDict.TryGetValue(targetNeedId, out progress);
// 			}
// 			// 任意需求
// 			else
// 			{
// 				foreach ((_, int num) in args.SatisfyHeroNeedsInHomeNumDict)
// 				{
// 					progress += num;
// 				}
// 			}
//
// 			quest.AddProgress(progress);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.NoJobFinishStage)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestNoJobFinishStage : AQuestHandler<NoJobFinishStage>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, NoJobFinishStage args)
// 		{
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param.Count < 2) return;
// 			int stageId = quest.Config.Param[1];
// 			if (stageId != args.StageId) return;
// 			var jobtag = TagsUtil.HeroOccupation2BattleTag((Occupation)quest.Config.Param[0]);
// 			foreach (var value in args.UsedHeroIds)
// 			{
// 				var unitCfg = BATTLE_UNIT_Table.Instance.GetOrDefault(value);
// 				if (unitCfg.unit_tag.Contains(jobtag)) return;
// 			}
//
// 			quest.AddProgress(1);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.NoCampFinishStage)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestNoCampFinishStage : AQuestHandler<NoCampFinishStage>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, NoCampFinishStage args)
// 		{
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param.Count < 2) return;
// 			var genre = TagsUtil.HeroGenre2AbilityTag((HeroGenre)quest.Config.Param[0]);
// 			foreach (var value in args.UsedHeroIds)
// 			{
// 				var unitCfg = BATTLE_UNIT_Table.Instance.GetOrDefault(value);
// 				if (unitCfg.unit_tag.Contains(genre)) return;
// 			}
//
// 			if (quest.Config.Param[1] > args.Damage) return;
// 			quest.AddProgress(1);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ChapterFinish)]
// 	[FriendOf(typeof(Quest))]
// 	[FriendOf(typeof(MainLineComponent))]
// 	public class QuestChapterFinish : AQuestHandler<ChapterFinish>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, ChapterFinish args)
// 		{
// 			await ETTask.CompletedTask;
// 			if (args.ChapterId != quest.Config.Param[1]) return;
// 			var cfg = MAINLINE_CHAPTER_Table.Instance.Get(args.ChapterId);
// 			if (cfg.SmallStageIds[^1] == args.StageId && quest.Config.Param[0] == 0)
// 			{
// 				var mlc = unit.GetComponent<MainLineComponent>();
// 				if(!mlc.Chapters.TryGetValue(args.ChapterId,out var chapter)) return;
// 				if(!chapter.IsAllStagePass()) return;
// 				quest.AddProgress(1);
// 			}
// 			else if (cfg.DifficultStageId[^1] == args.StageId && quest.Config.Param[0] == 1)
// 			{
// 				var mlc = unit.GetComponent<MainLineComponent>();
// 				if(!mlc.Chapters.TryGetValue(args.ChapterId,out var chapter)) return;
// 				if(!chapter.IsAllDifficultStagePass()) return;
// 				quest.AddProgress(1);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.AdventureRays)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestAdventureRays : AQuestHandler<AdventureRays>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, AdventureRays args)
// 		{
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param[0] != args.Factory) return;
// 			quest.AddProgress(1);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.TreasureCaveLevel)]
// 	[FriendOf(typeof(Quest))]
// 	public class QuestTreasureCaveLevel : AQuestHandler<TreasureCaveLevel>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, TreasureCaveLevel args)
// 		{
// 			await ETTask.CompletedTask;
// 			if (quest.Config.Param[0] != args.Floor) return;
// 			quest.AddProgress(1);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.SpiritPokedexLevel)]
// 	public class QuestSpiritPokedexLevel : AQuestHandler<QuestValueParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, QuestValueParam maxSpriteId)
// 		{
// 			await ETTask.CompletedTask;
// 			var targetLevel = quest.Config.Param[0];
// 			if (targetLevel <= (int)maxSpriteId.Value)
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.GetFruitQualityNum)]
// 	public class QuestGetFruitQualityNum : AQuestHandler<FruitQualityNumParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FruitQualityNumParam args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			var quality = quest.Config.Param[0];
// 			var targetNum = quest.Config.RequireNum;
// 			if (args.QuailiyNums.TryGetValue(quality, out var num))
// 			{
// 				//if (num >= targetNum)
// 				quest.SetProgress(num);
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CampSkillUpgrade)]
// 	[FriendOf(typeof(BattleGeneraSkillComponent))]
// 	public class QuestCampSkillUpgrade : AQuestHandler<CampSkillUpgradeParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, CampSkillUpgradeParam args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			var com = unit.GetComponent<BattleGeneraSkillComponent>();
// 			var targetId = quest.Config.Param[0];
// 			var targetEvo = quest.Config.Param[1];
// 			var targetLevel = quest.Config.Param[2];
//
// 			var item = com.GetBattleGeneraSkillItem(args.ConfigId);
// 			if (item == null)
// 				return;
// 			if (args.ConfigId != targetId)
// 				return;
// 			if (item.EvolutionLevel == targetEvo && item.Level == targetLevel)
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CampSkillUpToStarLevel)]
// 	[FriendOf(typeof(BattleGeneraSkillComponent))]
// 	public class QuestCampSkillUpToStarLevel : AQuestHandler<CampSkillUpToStarLevelParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, CampSkillUpToStarLevelParam args)
// 		{
// 			// x个阵营技提升到y星
// 			await ETTask.CompletedTask;
//
// 			var com = unit.GetComponent<BattleGeneraSkillComponent>();
// 			var targetCount = quest.Config.RequireNum;
// 			var targetStarLevel = quest.Config.Param[0];
// 			var targetStar = quest.Config.Param[1];
//
// 			var currCount = 0;
// 			for (int i = 0; i < com.Items.Count; i++)
// 			{
// 				var item = com.Items[i];
// 				if(item.Star > targetStar)
// 				{
// 					currCount++;
// 				}
// 				else if (item.Star == targetStar && item.StarLevel >= targetStarLevel)
// 				{
// 					currCount++;
// 				}
// 			}
// 			//if (currCount >= targetCount)
// 			quest.SetProgress(currCount);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CampSkillEvolve)]
// 	[FriendOf(typeof(BattleGeneraSkillComponent))]
// 	public class QuestCampSkillEvolve : AQuestHandler<CampSkillEvolveParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, CampSkillEvolveParam args)
// 		{
// 			// {0}阵营技进化至{1}色{2}星
// 			await ETTask.CompletedTask;
// 			var com = unit.GetComponent<BattleGeneraSkillComponent>();
//
// 			var targetId = quest.Config.Param[0];
// 			var targetStarLevel = quest.Config.Param[1];
// 			var targetStar = quest.Config.Param[2];
//
// 			var item = com.GetBattleGeneraSkillItem(args.ConfigId);
// 			if (item == null)
// 				return;
// 			if (args.ConfigId != targetId)
// 				return;
// 			if (item.StarLevel == targetStarLevel && item.Star == targetStar)
// 			{
// 				quest.Complete();
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CampSkillLevelUp)]
// 	[FriendOf(typeof(BattleGeneraSkillComponent))]
// 	public class QuestCampSkillLevelUp : AQuestHandler<CampSkillLevelUpParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, CampSkillLevelUpParam args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			var com = unit.GetComponent<BattleGeneraSkillComponent>();
// 			var targetCount = quest.Config.RequireNum;
// 			var targetEvo = quest.Config.Param[0];
// 			var targetLevel = quest.Config.Param[1];
//
// 			var currCount = 0;
// 			for (int i = 0; i < com.Items.Count; i++)
// 			{
// 				var item = com.Items[i];
// 				if(item.EvolutionLevel > targetEvo)
// 				{
// 					currCount++;
// 				}
// 				else if (item.EvolutionLevel == targetEvo && item.Level >= targetLevel)
// 				{
// 					currCount++;
// 				}
// 			}
// 			//if (currCount >= targetCount)
// 			quest.SetProgress(currCount);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroReachStage)]
// 	[FriendOf(typeof(HeroComponent))]
// 	public class QuestHeroReachStageHandler : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			// {0}名英雄达到{1}阶
// 			await ETTask.CompletedTask;
// 			var com = unit.GetComponent<HeroComponent>();
// 			var shareDatas = com.ShareDatas;
// 			var targetNum = quest.Config.RequireNum;
// 			var targetEvoLevel = quest.Config.Param[0];
// 			int currCount = 0;
// 			for (int i = 0; i < shareDatas.Count; i++)
// 			{
// 				var shareData = shareDatas[i];
// 				var config = HERO_UPGRADE_Table.Instance.Get(shareData.Level);
// 				if (config.EvolutionLevel >= targetEvoLevel)
// 					currCount++;
// 			}
// 			quest.SetProgress(currCount);
// 			//if (currCount >= targetNum)
// 			//{
// 			//	quest.Complete();
// 			//}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HeroAwakenLevel)]
// 	[FriendOf(typeof(HeroComponent))]
// 	public class QuestHeroAwakenLevel : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			await ETTask.CompletedTask;
// 			var com = unit.GetComponent<HeroComponent>();
// 			var targetNum = quest.Config.RequireNum;
// 			var targetLevel = quest.Config.Param[0];
// 			int currCount = 0;
// 			for (int i = 0; i < com.ShareAwakenDatas.Count; i++)
// 			{
// 				var shareData = com.ShareAwakenDatas[i];
// 				if (shareData.Level >= targetLevel)
// 					currCount++;
// 			}
// 			//if (currCount >= targetNum)
// 			quest.SetProgress(currCount);
// 		}
// 	}
//
//
//
// 	[QuestHandler(QuestType.FruitUpgradeToStage)]
// 	[FriendOf(typeof(FruitComponent))]
// 	public class QuestFruitEvolutionToRankNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			await ETTask.CompletedTask;
// 			var com = unit.GetComponent<FruitComponent>();
// 			var targetCount = quest.Config.RequireNum;
// 			var targetLevel = quest.Config.Param[0];
// 			var currCount = 0;
// 			for (int i = 0; i < com.Items.Count; i++)
// 			{
// 				if (com.Items[i].Level >= targetLevel)
// 				{
// 					currCount++;
// 				}
// 			}
// 			//if (currCount >= targetCount)
// 			quest.SetProgress(currCount);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.FruitUpgradeToStar)]
// 	[FriendOf(typeof(FruitComponent))]
// 	public class QuestFruitUpdateToStarNum : AQuestHandler
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest)
// 		{
// 			await ETTask.CompletedTask;
// 			var com = unit.GetComponent<FruitComponent>();
// 			var targetCount = quest.Config.RequireNum;
// 			var targetLevel = quest.Config.Param[0];
// 			var currCount = 0;
// 			for (int i = 0; i < com.Items.Count; i++)
// 			{
// 				if (com.Items[i].Star >= targetLevel)
// 				{
// 					currCount++;
// 				}
// 			}
// 			//if (currCount >= targetCount)
// 			quest.SetProgress(currCount);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.ClearMainStoryDungeonLevel)]
// 	[FriendOfAttribute(typeof(ET.UnitHeroEventComponent))]
// 	[FriendOfAttribute(typeof(ET.UnitHeroEventData))]
// 	public class QuestClearMainStoryDungeonLevel : AQuestHandler<MainStoryBattleOnSuccess>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, MainStoryBattleOnSuccess args)
// 		{
// 			// 限时活动主线副本中通关第{0}关
// 			await ETTask.CompletedTask;
// 			var config = quest.Config;
// 			int themeId = config.Param[0];
// 			int chapterId = config.Param[1];
// 			int stageId = config.Param[2];
// 			if (args.ChapterId != chapterId || args.StageId != stageId)
// 			{
// 				return;
// 			}
//
// 			var com = unit.GetComponent<UnitHeroEventComponent>();
// 			if (com.ThemeDatas.TryGetValue(themeId, out var data))
// 			{
// 				if (data.Chapters.TryGetValue(chapterId, out var chapter))
// 				{
// 					if (chapter.Stages.TryGetValue(stageId, out var stage))
// 					{
// 						if (stage.Passed)
// 						{
// 							quest.Complete();
// 						}
// 					}
// 				}
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.RechargeAmountReachedInSpecifiedPeriod)]
// 	[FriendOfAttribute(typeof(ET.Quest))]
// 	public class QuestRechargeAmountReachedInSpecifiedPeriod : AQuestHandler<RechargeAmount>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, RechargeAmount args)
// 		{
// 			// {指定周期内}充值额度达到{1}
// 			await ETTask.CompletedTask;
// 			// 逻辑：记录指定充值的时间戳，当超出指定周期的时候，重置进度
// 			var config = quest.Config;
// 			int range = config.Param[0];
// 			var dictionary = new Dictionary<long, long>();
// 			if (!string.IsNullOrWhiteSpace(quest.ProgressData))
// 			{
// 				var fromJson = JsonHelper.Deserialize<Dictionary<long, long>>(quest.ProgressData);
// 				dictionary.AddRange(fromJson);
// 			}
//
// 			long serverNow = TimeHelper.ServerNow();
// 			dictionary.Add(serverNow, args.Amount);
// 			long sum = 0;
// 			var temp = new Dictionary<long, long>();
// 			foreach ((long key, long value) in dictionary)
// 			{
// 				if (key >= serverNow - TimeHelper.OneDay * range)
// 				{
// 					continue;
// 				}
//
// 				temp.Add(key, value);
// 				sum += value;
// 			}
//
// 			quest.SetProgress(sum);
// 			quest.ProgressData = JsonHelper.Serialize(temp);
// 		}
// 	}
//
//
// 	[QuestHandler(QuestType.FollowersLoyaltyGreaterThanOrEqualTo)]
// 	public class QuestFollowersLoyaltyGreaterThanOrEqualTo : AQuestHandler<FollowersLoyaltyUpdate>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FollowersLoyaltyUpdate args)
// 		{
// 			// {0}个追随者忠诚度大于等于{1}
// 			await ETTask.CompletedTask;
//
// 			var config = quest.Config;
// 			if (config.Param.Count > 0)
// 			{
// 				int num = config.Param[0];
// 				int progress = args.FollowersLoyalty.Count(i => i >= num);
// 				quest.SetProgress(progress);
// 			}
// 			else
// 			{
// 				Log.Warning($"##X#L#E#N#CCC##  神秘代码1  这都直接报错了，表这个参数需要填写。");
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.FollowersLoyaltyLessThanOrEqualTo)]
// 	public class QuestFollowersLoyaltyLessThanOrEqualTo : AQuestHandler<FollowersLoyaltyUpdate>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FollowersLoyaltyUpdate args)
// 		{
// 			// {0}个追随者忠诚度小于等于{1}
// 			await ETTask.CompletedTask;
// 			
// 			var config = quest.Config;
// 			if (config.Param.Count > 0)
// 			{
// 				int num = config.Param[0];
// 				int progress = args.FollowersLoyalty.Count(i => i <= num);
// 				quest.SetProgress(progress);
// 			}
// 			else
// 			{
// 				Log.Warning($"##X#L#E#N#CCC##  神秘代码2  这都直接报错了，表这个参数需要填写。");
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.FollowersLoyaltyEqualTo)]
// 	public class QuestFollowersLoyaltyEqualTo : AQuestHandler<FollowersLoyaltyUpdate>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FollowersLoyaltyUpdate args)
// 		{
// 			// {0}个追随者忠诚度等于{1}
// 			await ETTask.CompletedTask; 
// 			var config = quest.Config;
//
// 			if (config.Param.Count > 0)
// 			{
// 				int num = config.Param[0];
// 				int progress = args.FollowersLoyalty.Count(i => i == num);
// 				quest.SetProgress(progress);
// 			}
// 			else
// 			{
// 				Log.Warning($"##X#L#E#N#CCC##  神秘代码3  这都直接报错了，表这个参数需要填写。");
// 			}
// 		}
// 	}
//
// 	[QuestHandler(QuestType.ChallengePlayer)]
// 	public class QuestFSChallengePlayer : AQuestHandler<FollowerSysCommonParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FollowerSysCommonParam args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			// Log.Warning($"##F#I#N#A#L## 挑战玩家任务： 直接增加1次、  传来的:{args.ParamL[0]}");
//
// 			quest.AddProgress(1); // 这个类型的，这里直接增加1。
// 		}
// 	}
//
// 	[QuestHandler(QuestType.HaveFollower)]
// 	public class QuestFSHaveFollower : AQuestHandler<FollowerSysCommonParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FollowerSysCommonParam args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			Log.Warning($"##F#I#N#A#L## 有几个小弟： 直接设置、  传来的:{args.ParamL[0]}");
// 			quest.SetProgress(args.ParamL[0]);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.CollectTributeResource)]
// 	public class QuestFSClctTribute : AQuestHandler<FollowerSysCommonParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FollowerSysCommonParam args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			Log.Warning($"##F#I#N#A#L## 收取上贡资源： 增加、  传来的:{args.ParamL[0]}");
// 			quest.AddProgress(args.ParamL[0]);
// 		}
// 	}
//
// 	[QuestHandler(QuestType.GiveFollowReward)]
// 	public class QuestFSGiveReward : AQuestHandler<FollowerSysCommonParam>
// 	{
// 		protected override async ETTask Run(Unit unit, Quest quest, FollowerSysCommonParam args)
// 		{
// 			await ETTask.CompletedTask;
//
// 			Log.Warning($"##F#I#N#A#L## 赠送小弟奖励： 增加、  传来的:{args.ParamL[0]}");
// 			quest.AddProgress(args.ParamL[0]);
// 		}
// 	}
// }
