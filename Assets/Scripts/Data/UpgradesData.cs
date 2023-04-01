using System;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "UpgradesData", menuName = "ScriptableObjects/Upgrades")]
    public class UpgradesData : ScriptableObject
	{
        [SerializeField] private Upgrade HealthUpgrades;
        [SerializeField] private Upgrade DamageMultiplierUpgrades;
        [SerializeField] private Upgrade AttackSpeedUpgrades;

        public enum UpgradeType { Health = 0, DamageMultiplier = 1, AttackSpeed = 2 }
        public enum UpgradeRarity { Common, Rare, VeryRare, Epic, Legendary }

        public Data GetUpgrade(UpgradeType type, UpgradeRarity rarity)
        {
            switch (type)
            {
                case UpgradeType.Health:
                    return HealthUpgrades.GetUpgrade(rarity);
                case UpgradeType.DamageMultiplier:
                    return DamageMultiplierUpgrades.GetUpgrade(rarity);
                case UpgradeType.AttackSpeed:
                    return AttackSpeedUpgrades.GetUpgrade(rarity);
                default:
                    throw new ArgumentException();
            }
        }

        [Serializable]
        public class Upgrade
        {
            private UpgradeType _upgradeType;

            [SerializeField] private Data Common;
            [SerializeField] private Data Rare;
			[SerializeField] private Data VeryRare;
            [SerializeField] private Data Epic;
			[SerializeField] private Data Legendary;
            
            public  UpgradeType UpgradeType => _upgradeType;

            public Data GetUpgrade(UpgradeRarity rarity)
            {
                switch (rarity)
                {
                    case UpgradeRarity.Common:
                        return Common;
                    case UpgradeRarity.Rare:
                        return Rare;
                    case UpgradeRarity.VeryRare:
                        return VeryRare;
                    case UpgradeRarity.Epic:
                        return Epic;
                    case UpgradeRarity.Legendary:
                        return Legendary;
                    default:
                        throw new ArgumentException();
                }
            }

            public Upgrade(UpgradeType type)
            {
                _upgradeType = type;
            }
		}

        [Serializable]
		public struct Data
		{
			public Sprite Sprite;
			public int Value;
		}

        private void OnEnable()
        {
            if (HealthUpgrades == null) HealthUpgrades = new Upgrade(UpgradeType.Health);
            if (HealthUpgrades == null) DamageMultiplierUpgrades = new Upgrade(UpgradeType.DamageMultiplier);
            if (HealthUpgrades == null) AttackSpeedUpgrades = new Upgrade(UpgradeType.AttackSpeed);
        }
    }
}