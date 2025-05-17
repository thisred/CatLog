using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIAnnouncementComponent))]
    [FriendOfAttribute(typeof(ET.Client.UIAnnouncementComponent))]
    public static partial class UIAnnouncementSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.UIAnnouncementComponent self)
        {
            var rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.CloseBtn = rc.Get<GameObject>("Close").GetComponent<Button>();
            self.CloseBtn2 = rc.Get<GameObject>("Close2").GetComponent<Button>();
            self.Text = rc.Get<GameObject>("Text").GetComponent<TextMeshProUGUI>();

            self.CloseBtn.onClick.AddListener(() => { UIHelper.Remove(self.Root(), UIType.UIAnnouncement).Coroutine(); });
            self.CloseBtn2.onClick.AddListener(() => { UIHelper.Remove(self.Root(), UIType.UIAnnouncement).Coroutine(); });
        }
    }
}