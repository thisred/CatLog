using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UILobbyComponent : Entity, IAwake
    {
        public Button Button;
        public TextMeshProUGUI PlayerName;
    }
}