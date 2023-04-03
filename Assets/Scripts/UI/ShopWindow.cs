using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class ShopWindow : UIWindow
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _backButton;

        public override void Initialize()
        {
            _startButton.onClick.AddListener(delegate { UIWindowManager.Show<GameUI>(); });
            _backButton.onClick.AddListener(delegate { UIWindowManager.ShowLast(); });
        }
    }
}