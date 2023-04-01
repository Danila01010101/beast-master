using UnityEngine;

namespace BeastMaster
{
    public class UI : MonoBehaviour
    {
        [Header("Windows")]
        [SerializeField] private CharacterSelectionWindow _selectionWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private GameObject _startScreen;
        [SerializeField] private GameObject _menuWindow;
        [SerializeField] private CharacterUpgradeWindow _upgradeWindow;

        private GameObject _opennedWindow;

        private void Start()
        {
            _opennedWindow = _startScreen;
        }

        public void OpenWindow(GameObject window)
        {
            _opennedWindow.SetActive(false);
            window.SetActive(true);
            _opennedWindow = window;
        }

        public void CloseMenu()
        {
            _opennedWindow.SetActive(false);
            OpenWindow(_startScreen);
            _menuWindow.SetActive(false);
        }

        private void CloseMenuOnGameStart(LevelData data)
        {
            CloseMenu();
        }

        private void OpenUpgradeWindow()
        {
            _upgradeWindow.Show();
        }

        private void OnEnable()
        {
            LevelStarter.LevelStarted += CloseMenuOnGameStart;
            LevelStarter.LevelEnded += OpenUpgradeWindow;
        }

        private void OnDisable()
        {
            LevelStarter.LevelStarted -= CloseMenuOnGameStart;
            LevelStarter.LevelEnded -= OpenUpgradeWindow;
        }
    }
}