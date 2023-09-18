using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class StartScreen : UIWindow
    {
        [SerializeField] private Button _chooseCharacterButton;
        [SerializeField] private Button _settingsButton;

        public override void Initialize()
        {
            _chooseCharacterButton.onClick.AddListener(delegate { UIWindowManager.Show<CharacterSelectionWindow>(true); });
            _settingsButton.onClick.AddListener(delegate { UIWindowManager.Show<SettingsWindow>(true); });
        }
    }
}