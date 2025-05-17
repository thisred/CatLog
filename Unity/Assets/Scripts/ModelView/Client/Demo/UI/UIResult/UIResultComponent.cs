using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIResultComponent : Entity, IAwake
    {
        public Button exitBtn;
        public TextMeshProUGUI winner;
        public TextMeshProUGUI loser;
        public TextMeshProUGUI result;
        public GameObject FailBackground;
        public GameObject SuccessBackground;
        public GameObject DeuceBackground;
    }
}