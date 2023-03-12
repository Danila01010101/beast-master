using UnityEngine;

namespace BeastMaster
{
    public class StartMenu : MonoBehaviour
    {
        [Header("Windows")]
        [SerializeField] private CharacterSelectionWindow _selectionWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private GameObject _startScreen;
        [SerializeField] private GameObject _menuWindow;

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
    }
}