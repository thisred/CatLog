using TMPro;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIBattleComponent : Entity, IAwake, IUpdate
    {
        public BattlePanel BattlePanel;
        public TextMeshProUGUI Score;
        public TextMeshProUGUI Player1;
        public TextMeshProUGUI Player2;
    }
}