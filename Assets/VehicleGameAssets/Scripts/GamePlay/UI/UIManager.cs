using Alchemy.Inspector;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace VehicleGame.Gameplay.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] private PanelMathResult panelMathResult;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

            }
        }
        [Button]
        public void Win()
        {
            panelMathResult.Show(PanelMathResult.MatchResult.Win);
        }
        [Button]
        public void Lose()
        {
            panelMathResult.Show(PanelMathResult.MatchResult.Lose);

        }



    }
}
