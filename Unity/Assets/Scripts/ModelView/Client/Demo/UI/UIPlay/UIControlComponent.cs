using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIControlComponent : Entity, IAwake, IUpdate
    {
        public Joystick moveJoystick;
        public Joystick skill1;
        public Joystick skill2;
        public Button setting;
        public Button shop;

        public Vector2 JoystickMove { get; set; }
        public Vector2 Skill1 { get; set; }
        public Vector2 Skill1Up { get; set; }
        public Vector2 Skill2 { get; set; }
        public Vector2 Skill2Up { get; set; }

        /// <summary>
        /// 游戏场景中的相机
        /// </summary>
        public Camera GameCamera { get; set; }
    }
}