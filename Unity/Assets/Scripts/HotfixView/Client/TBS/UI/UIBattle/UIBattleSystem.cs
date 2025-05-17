using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIBattleComponent))]
    [FriendOf(typeof(UIBattleComponent))]
    [FriendOfAttribute(typeof(ET.Client.ClientRoomComponent))]
    public static partial class UIBattleSystem
    {
        [EntitySystem]
        public static void Awake(this UIBattleComponent self)
        {
            var rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.BattlePanel = rc.Get<GameObject>("BattlePanel").GetComponent<BattlePanel>();
            self.Score = rc.Get<GameObject>("Score").GetComponent<TextMeshProUGUI>();
            self.Player1 = rc.Get<GameObject>("Player1").GetComponent<TextMeshProUGUI>();
            self.Player2 = rc.Get<GameObject>("Player2").GetComponent<TextMeshProUGUI>();

            ClientRoomComponent clientRoomComponent = self.Root().GetComponent<ClientRoomComponent>();
            var dictionary = clientRoomComponent.Score;
            int left = 0;
            int right = 0;
            long myId = self.Root().GetComponent<PlayerComponent>().MyId;
            foreach ((long key, int value) in dictionary)
            {
                if (key == myId)
                {
                    left = value;
                }
                else
                {
                    right = value;
                }
            }

            self.Score.text = $"{left} : {right}";
            long targetId = 0;
            foreach (long playerId in clientRoomComponent.PlayerIds)
            {
                if (playerId != myId)
                {
                    targetId = playerId;
                    break;
                }
            }

            int myDigits = (int)(myId % 10000);
            int targetDigits = (int)( targetId % 10000);
            self.Player1.text = $"活鼠人{myDigits}";
            self.Player2.text = $"活鼠人{targetDigits}";
        }

        [EntitySystem]
        private static void Update(this ET.Client.UIBattleComponent self)
        {
            if (self.BattlePanel.Update1())
            {
                C2Room_AnimationComplete c2RoomAnimationComplete = C2Room_AnimationComplete.Create();
                c2RoomAnimationComplete.PlayerId = self.Root().GetComponent<PlayerComponent>().MyId;
                self.Root().Fiber.Root.GetComponent<ClientSenderComponent>().Send(c2RoomAnimationComplete);
            }
        }
    }
}