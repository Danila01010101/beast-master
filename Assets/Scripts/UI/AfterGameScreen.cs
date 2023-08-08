using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BeastMaster
{
    public class AfterGameScreen : UIWindow
    {
        [SerializeField] private Button _restartButton;

        public override void Initialize()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveAllListeners();
        }
    }
}
