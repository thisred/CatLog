using TMPro;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIMatchSuccessComponent : Entity, IAwake
    {
        public TextMeshProUGUI Player1;
        public TextMeshProUGUI Player2;
    }
}