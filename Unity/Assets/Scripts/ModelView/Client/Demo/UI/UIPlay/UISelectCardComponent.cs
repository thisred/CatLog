using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UISelectCardComponent : Entity, IAwake
    {
        public Button enterBattle;
        public Transform content1;
        public Transform content2;
        public CardItem cardItemPrefab;
        public TextMeshProUGUI turnCountdownText;
        public TextMeshProUGUI turnSelectTips;
        public GameObject wait;
        
        public int selectNum;
        public List<int> selectIds = new List<int>();
        public List<CardItem> cardItems = new List<CardItem>();

        public const int CardNum = 9;
        public const int CardNum1 = 3;
        public const int CardNum2 = 6;
        public int round;
        public int TurnCountdown { get; set; }
    }
}