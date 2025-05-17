using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIMatchComponent : Entity, IAwake
    {
        public Button cancelBtn;
        public TextMeshProUGUI progress;
        public GameObject cat;
    }
}