using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UISelectCardComponent))]
    [FriendOf(typeof(UISelectCardComponent))]
    public static partial class UISelectCardSystem
    {
        [EntitySystem]
        public static void Awake(this UISelectCardComponent self)
        {
            var rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.enterBattle = rc.Get<GameObject>("StartBtn").GetComponent<Button>();
            self.cardItemPrefab = rc.Get<GameObject>("CardItem").GetComponent<CardItem>();
            self.content1 = rc.Get<GameObject>("Panel1").GetComponent<Transform>();
            self.content2 = rc.Get<GameObject>("Panel2").GetComponent<Transform>();
            self.turnCountdownText = rc.Get<GameObject>("TurnCountdown").GetComponent<TextMeshProUGUI>();
            self.turnSelectTips = rc.Get<GameObject>("SelectTips").GetComponent<TextMeshProUGUI>();
            self.wait = rc.Get<GameObject>("WaitTarget");

            self.enterBattle.onClick.AddListener(self.StartGame);
        }

        public static void Init(this UISelectCardComponent self, EnterGameRound args)
        {
            self.round = args.Round;
            self.TurnCountdown = args.TurnCountdown;
            self.selectNum = Const.Round2SelectNum[self.round];
            self.turnSelectTips.text = $"当前回合为第{args.Round}回合，请选择{self.selectNum}张牌";
            self.selectIds = new List<int>(self.selectNum);
            self.cardItems = new List<CardItem>(UISelectCardComponent.CardNum);
            self.wait.SetActive(false);
            for (int i = 0; i < UISelectCardComponent.CardNum1; i++)
            {
                CardItem cardItem = UnityEngine.Object.Instantiate(self.cardItemPrefab, self.content1);
                self.cardItems.Add(cardItem);
                cardItem.Init(i, OnClickItem);
                cardItem.ClickButton.onClick.AddListener(() =>
                {
                    if (IsFull(self) && !cardItem.isSelect)
                    {
                        return;
                    }

                    cardItem.isSelect = !cardItem.isSelect;
                    OnClickItem(self, cardItem.isSelect, cardItem.id);
                });
            }

            for (int i = 3; i < UISelectCardComponent.CardNum2 + 3; i++)
            {
                CardItem cardItem = UnityEngine.Object.Instantiate(self.cardItemPrefab, self.content2);
                self.cardItems.Add(cardItem);
                cardItem.Init(i, OnClickItem);
                cardItem.ClickButton.onClick.AddListener(() =>
                {
                    if (IsFull(self) && !cardItem.isSelect)
                    {
                        return;
                    }

                    cardItem.isSelect = !cardItem.isSelect;
                    OnClickItem(self, cardItem.isSelect, cardItem.id);
                });
            }

            UpdateText(self);
            self.StartTurnCountdown().Coroutine();
        }

        public static async ETTask StartTurnCountdown(this UISelectCardComponent self)
        {
            while (self.TurnCountdown > 0)
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
                self.TurnCountdown--;
                self.turnCountdownText.text = $"倒计时: {self.TurnCountdown}秒";
            }
        }

        public static bool IsFull(this UISelectCardComponent self)
        {
            return self.selectIds.Count >= self.selectNum;
        }

        private static void OnClickItem(this UISelectCardComponent self, bool select, int id)
        {
            if (select)
            {
                self.selectIds.Add(id);
            }
            else
            {
                self.selectIds.Remove(id);
            }

            UpdateText(self);
        }

        private static void UpdateText(this UISelectCardComponent self)
        {
            foreach (var item in self.cardItems)
            {
                item.UpdateText("");
            }

            for (int i = 0; i < self.selectIds.Count; i++)
            {
                self.cardItems[self.selectIds[i]].UpdateText((i + 1).ToString());
            }
        }

        public static void DestoryALl(this UISelectCardComponent self)
        {
            for (int i = 0; i < self.cardItems.Count; i++)
            {
                UnityEngine.Object.Destroy(self.cardItems[i].gameObject);
            }
        }

        /// <summary>
        /// 开始游戏回合
        /// </summary>
        public static void StartGame(this UISelectCardComponent self)
        {
            if (self.selectIds.Count == self.selectNum)
            {
                C2Room_StartBattle c2RoomStartBattle = C2Room_StartBattle.Create();
                long myId = self.Root().GetComponent<PlayerComponent>().MyId;
                c2RoomStartBattle.PlayerId = myId;
                var ints = new List<int>();
                foreach (int selfSelectId in self.selectIds)
                {
                    ints.Add(selfSelectId + 1);
                }

                c2RoomStartBattle.CardId.AddRange(ints);
                self.Root().Fiber.Root.GetComponent<ClientSenderComponent>().Send(c2RoomStartBattle);
                self.content1.parent.gameObject.SetActive(false);
                self.content2.parent.gameObject.SetActive(false);
                self.wait.SetActive(true);
            }
            else
            {
                Debug.LogError($"请选择{self.selectNum}张卡牌开始战斗！！！");
            }
        }
    }
}