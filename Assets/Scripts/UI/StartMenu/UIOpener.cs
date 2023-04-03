using UnityEngine;

namespace BeastMaster
{
    public class UIOpener : MonoBehaviour
    {
        private void HideOnStart(LevelData levelData)
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
            LevelStarter.LevelStarted += HideOnStart;
            LevelStarter.LevelEnded += OpenUpgradeWindow;
        }

        private void OnDisable()
        {
            LevelStarter.LevelStarted -= HideOnStart;
            LevelStarter.LevelEnded -= OpenUpgradeWindow;
        }
    }
}