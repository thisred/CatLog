using TMPro;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIAnnouncementComponent : Entity, IAwake
    {
        public TextMeshProUGUI Text;
        public Button CloseBtn;
        public Button CloseBtn2;
    }
}