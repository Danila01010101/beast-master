using UnityEngine;

namespace BeastMaster
{
    public class UIOpener : MonoBehaviour
    {
        private void ShowEndScreen()
        {
            UIWindowManager.Show<EndGameScreen>(false);
        }

        private void ShowWinScreen()
        {
            UIWindowManager.Show<WinGameScreen>(false);
        }

        private void HideOnStart()
        {
            UIWindowManager.Show<GameUI>(false);
        }

        private void OpenUpgradeWindow()
        {
            UIWindowManager.Show<ShopWindow>(false);
            UIWindowManager.Show<CharacterUpgradeWindow>(false);
        }

        private void OnEnable()
        {
            Player.GameOver += ShowEndScreen;
            LevelStarter.LevelStarted += HideOnStart;
            LevelStarter.LevelEnded += OpenUpgradeWindow;
            LevelStarter.GameFinished += ShowWinScreen;
        }

        private void OnDisable()
        {
            Player.GameOver -= ShowEndScreen;
            LevelStarter.LevelStarted -= HideOnStart;
            LevelStarter.LevelEnded -= OpenUpgradeWindow;
            LevelStarter.GameFinished -= ShowWinScreen;
        }
    }
}