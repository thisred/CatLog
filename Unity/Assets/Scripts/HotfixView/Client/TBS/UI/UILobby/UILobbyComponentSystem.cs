using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UILobbyComponent))]
    [FriendOf(typeof(UILobbyComponent))]
    [FriendOf(typeof(UIMatchComponent))]
    public static partial class UILobbyComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UILobbyComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Button = rc.Get<GameObject>("MatchButton").GetComponent<Button>();
            self.PlayerName = rc.Get<GameObject>("PlayerName").GetComponent<TextMeshProUGUI>();

            self.Button.GetComponent<Button>().onClick.AddListener(() => { self.Match().Coroutine(); });
            long myId = self.Root().GetComponent<PlayerComponent>().MyId;
            int lastFourDigits = (int)(myId % 10000);
            self.PlayerName.text = "活鼠人" + lastFourDigits.ToString();
        }

        public static async ETTask Match(this UILobbyComponent self)
        {
            var root = self.Root();
            var token = new ETCancellationToken();
            await EnterMapHelper.Match(root.Fiber, token);
            await UIHelper.TryCreate(root, UIType.UIMatch, UILayer.Mid);
        }
    }
}