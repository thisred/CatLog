using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIControlComponent))]
    [FriendOf(typeof(UIControlComponent))]
    public static partial class UIControlSystem
    {
        [EntitySystem]
        public static void Awake(this UIControlComponent self)
        {
            var rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.moveJoystick = rc.Get<GameObject>("MoveJoystick").GetComponent<Joystick>();
            self.skill1 = rc.Get<GameObject>("SkillJoystick1").GetComponent<Joystick>();
            self.skill2 = rc.Get<GameObject>("SkillJoystick2").GetComponent<Joystick>();
            self.setting = rc.Get<Button>("Setting");
            self.shop = rc.Get<Button>("Shop");

            self.GameCamera = Camera.main;
            self.moveJoystick.OnJoystickDownEvent += vector2 => { self.JoystickMove = vector2; };
            self.moveJoystick.OnJoystickUpEvent += _ => { self.JoystickMove = Vector2.zero; };
            self.moveJoystick.OnJoystickMoveEvent += vector2 => { self.JoystickMove = vector2; };
            self.skill1.OnJoystickDownEvent += vector2 => { self.Skill1 = vector2; };
            self.skill1.OnJoystickUpEvent += vector2 =>
            {
                self.Skill1 = Vector2.zero;
                self.Skill1Up = vector2;
            };
            self.skill1.OnJoystickMoveEvent += vector2 => { self.Skill1 = vector2; };
            self.skill2.OnJoystickDownEvent += vector2 => { self.Skill2 = vector2; };
            self.skill2.OnJoystickUpEvent += vector2 =>
            {
                self.Skill2 = Vector2.zero;
                self.Skill2Up = vector2;
            };
            self.skill2.OnJoystickMoveEvent += vector2 => { self.Skill2 = vector2; };

            self.setting.onClick.AddListener(SettingClick);
            self.shop.onClick.AddListener(ShopClick);
        }

        private static void SettingClick()
        {
        }

        private static void ShopClick()
        {
        }

        [EntitySystem]
        private static void Update(this ET.Client.UIControlComponent self)
        {
        }
    }
}