using TMPro;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIMatchSuccessComponent))]
    [FriendOfAttribute(typeof(ET.Client.UIMatchSuccessComponent))]
    public static partial class UIMatchSuccessSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.UIMatchSuccessComponent self)
        {
            var rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Player1 = rc.Get<GameObject>("Player1").GetComponent<TextMeshProUGUI>();
            self.Player2 = rc.Get<GameObject>("Player2").GetComponent<TextMeshProUGUI>();
        }
    }
}