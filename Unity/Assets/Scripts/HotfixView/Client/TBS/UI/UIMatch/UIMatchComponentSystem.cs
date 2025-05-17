using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIMatchComponent))]
    [FriendOf(typeof(UIMatchComponent))]
    public static partial class UIMatchComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.UIMatchComponent self)
        {
            var rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.progress = rc.Get<GameObject>("Players").GetComponent<TextMeshProUGUI>();
            self.cancelBtn = rc.Get<GameObject>("CancelBtn").GetComponent<Button>();
            self.cat = rc.Get<GameObject>("Cat");

            self.cancelBtn.GetComponent<Button>().onClick.AddListener(self.OnCancel);
            DotAnimation(self).Coroutine();
        }

        public static void OnCancel(this UIMatchComponent self)
        {
            C2G_CancelMatch c2GCancelMatch = C2G_CancelMatch.Create();
            self.Root().GetComponent<ClientSenderComponent>().Send(c2GCancelMatch);
            UIHelper.Remove(self.Root(), UIType.UIMatch).Coroutine();
        }

        public static async ETTask DotAnimation(this UIMatchComponent self)
        {
            string text = "正在寻找对局，请耐心等待";
            int i = 0;
            while (true)
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
                if (self.IsDisposed)
                {
                    return;
                }

                if (i < 3)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                string t = string.Empty;
                for (int j = 0; j < i; j++)
                {
                    t += ".";
                }

                self.progress.text = text + t;
                self.cat.SetActive(!self.cat.activeSelf);
            }
        }
    }
}