using UnityEngine;
using UnityEngine.UI;

namespace ET.Client.Card
{
    public class BattleCardBase : MonoBehaviour
    {
        public Image icon;

        public ParticleSystem flyPs;
        public ParticleSystem drownPs;

        public int CardId;

        public void Init(int cardId)
        {
            CardId = cardId;
            this.icon.sprite = Resources.Load<Sprite>($"{cardId}");
        }

        public void PlayFlyPs()
        {
            flyPs.Play();
        }

        public void PlayDrownPs()
        {
            drownPs.Play();
        }
    }
}