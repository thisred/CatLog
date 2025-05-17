using System;
using ET.Client;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET
{
    public class CardItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image icon;
        public TextMeshProUGUI selectText;
        public GameObject selectObj;
        public TextMeshProUGUI nameText;
        public Button ClickButton;
        public GameObject cardTip;
        public TextMeshProUGUI cardTipText;

        [NonSerialized]
        public bool isSelect;

        [NonSerialized]
        public int id;

        public Action<UISelectCardComponent, bool, int> clickAction;

        public void OnPointerEnter(PointerEventData eventData)
        {
            this.cardTip.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.cardTip.SetActive(false);
        }
    }
}