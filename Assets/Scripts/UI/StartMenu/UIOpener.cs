using UnityEngine;

namespace BeastMaster
{
    public class UIOpener : MonoBehaviour
    {
        private void ShowEndScreen()
        {
            UIWindowManager.Show<EndGameScreen>();
        }

        private void HideOnStart()
        {
            UIWindowManager.Show<GameUI>();
        }

        private void OpenUpgradeWindow()
        {
            UIWindowManager.Show<ShopWindow>(true);
            UIWindowManager.Show<CharacterUpgradeWindow>(false);
        }

        private void OnEnable()
        {
            Player.GameOver += ShowEndScreen;
            LevelStarter.LevelStarted += HideOnStart;
            LevelStarter.LevelEnded += OpenUpgradeWindow;
        }

        private void OnDisable()
        {
            Player.GameOver -= ShowEndScreen;
            LevelStarter.LevelStarted -= HideOnStart;
            LevelStarter.LevelEnded -= OpenUpgradeWindow;
        }
    }
}