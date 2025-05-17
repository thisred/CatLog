using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UILoginComponent))]
    [FriendOf(typeof(UILoginComponent))]
    public static partial class UILoginComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UILoginComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.loginBtn = rc.Get<GameObject>("LoginBtn");
            self.announceBtn = rc.Get<GameObject>("Announce").GetComponent<Button>();

            self.loginBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnLogin(); });
            self.account = rc.Get<GameObject>("Account");
            self.password = rc.Get<GameObject>("Password");
            self.announceBtn.onClick.AddListener((() => { UIHelper.Create(self.Root(), UIType.UIAnnouncement, UILayer.High).Coroutine(); }));
        }

        public static void OnLogin(this UILoginComponent self)
        {
            string playerName = PlayerPrefs.GetString("Account");
            string text = self.account.GetComponent<InputField>().text;
            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = Guid.NewGuid().ToString();
                PlayerPrefs.SetString("Account", playerName);
                PlayerPrefs.Save();
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                playerName = text;
            }

            LoginHelper.Login(self.Root(), playerName, self.password.GetComponent<InputField>().text).Coroutine();
        }
    }
}