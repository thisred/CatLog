using System;
using UnityEngine;

namespace ET.Client
{
    public static class CardItemSystem
    {
        public static void Init(this CardItem self, int id, Action<UISelectCardComponent, bool, int> onClickItem)
        {
            self.id = id;
            self.icon.sprite = Resources.Load<Sprite>((id + 1).ToString());
            self.nameText.text = Const.Names[id];
            self.clickAction = onClickItem;
            self.cardTipText.text = Const.Tips[id];
            self.cardTip.SetActive(false);
            self.selectObj.SetActive(false);
        }

        public static void OnClick(this CardItem self)
        {
            // bool isFull = self.GetParent<UISelectCardComponent>().IsFull();
            // if (isFull && !self.isSelect)
            // {
            //     return;
            // }

            self.isSelect = !self.isSelect;
        }

        public static void UpdateText(this CardItem self, string str)
        {
            bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(str);
            self.selectObj.SetActive(!isNullOrWhiteSpace);
            self.selectText.text = str;
        }
    }
}