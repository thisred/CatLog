using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIResultComponent))]
    [FriendOf(typeof(UIResultComponent))]
    public static partial class UIResultSystem
    {
        [EntitySystem]
        public static void Awake(this UIResultComponent self)
        {
            var rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.exitBtn = rc.Get<GameObject>("ExitBtn").GetComponent<Button>();
            self.winner = rc.Get<GameObject>("Winner").GetComponent<TextMeshProUGUI>();
            self.loser = rc.Get<GameObject>("Loser").GetComponent<TextMeshProUGUI>();
            self.result = rc.Get<GameObject>("Result").GetComponent<TextMeshProUGUI>();
            self.FailBackground = rc.Get<GameObject>("FailBackground");
            self.SuccessBackground = rc.Get<GameObject>("SuccessBackground");
            self.DeuceBackground = rc.Get<GameObject>("DeuceBackground");

            self.exitBtn.onClick.AddListener(() => { Call(self.Scene()).Coroutine(); });
        }

        private static async ETTask Call(Scene scene)
        {
            await UIHelper.Remove(scene, UIType.UISelect);
            await UIHelper.Remove(scene, UIType.UIMatch);
            await UIHelper.Remove(scene, UIType.UIResult);
            await UIHelper.Create(scene, UIType.UILobby, UILayer.Mid);
        }

        public static void SetResult(this UIResultComponent self, BattleResult result)
        {
            long myId = self.Root().GetComponent<PlayerComponent>().MyId;
            self.DeuceBackground.SetActive(false);
            self.SuccessBackground.SetActive(false);
            self.FailBackground.SetActive(false);
            if (result.WinnerId == 0)
            {
                self.DeuceBackground.SetActive(true);
            }
            else
            {
                if (result.WinnerId == myId)
                {
                    self.SuccessBackground.SetActive(true);
                }
                else
                {
                    self.FailBackground.SetActive(true);
                }
            }

            // self.result.text = result.WinnerId == 0 ? "平手" : result.WinnerId == myId ? "胜利" : "失败";
        }
    }
}