using System;
using UnityEngine;

namespace BeastMaster
{
    public class CharacterUpgradeWindow : UIWindow
	{
		[SerializeField] private UpgradesData _upgradesData;
		[SerializeField] private UpgradeButton _firstUpgradeCell;
		[SerializeField] private UpgradeButton _secondUpgradeCell;
		[SerializeField] private GameObject _shopWindow;

		private CharacterUpgrader _upgrader => CharacterUpgrader.Instance;
		private UpgradeButton[] _upgradeButtons;

        private void GenerateUpgradeCells()
		{
			_upgradeButtons = new UpgradeButton[2];

			_upgradeButtons[0] = _firstUpgradeCell;
			_upgradeButtons[1] = _secondUpgradeCell;

			foreach (UpgradeButton button in _upgradeButtons)
			{
				var upgradeType = ChooseUpgrade();
				var upgradeRarity = ChooseUpgradeRarity();
				var upgrade = _upgradesData.GetUpgrade(upgradeType, upgradeRarity);

                button.Initialize( 
					delegate 
					{ 
						_upgrader.Updrade(upgradeType, upgrade.Value);
						UIWindowManager.ShowLast();
                    }, 
					upgrade.Sprite);
			}
        }

		private UpgradesData.UpgradeType ChooseUpgrade()
		{
			int upgradesAmount = Enum.GetNames(typeof(UpgradesData.UpgradeType)).Length;
			return (UpgradesData.UpgradeType)UnityEngine.Random.Range(0, upgradesAmount);
		}

		private UpgradesData.UpgradeRarity ChooseUpgradeRarity()
        {
            int upgradesAmount = Enum.GetNames(typeof(UpgradesData.UpgradeRarity)).Length;
            return (UpgradesData.UpgradeRarity)UnityEngine.Random.Range(0, upgradesAmount);
        }

        public override void Show()
        {
            base.Show();
			GenerateUpgradeCells();
        }

        public override void Initialize() { }
    }
}