using System;
using UnityEngine;

namespace BeastMaster
{
    public class CharacterUpgrader : MonoBehaviour
    {
        private PlayerMonsters _playerMonsters;

        public static Action<CharacterUpgrader> CharacterUpgraderInitialized;

        public void Initialize(PlayerMonsters playerMonsters)
        {
            _playerMonsters = playerMonsters;
            CharacterUpgraderInitialized?.Invoke(this);
        }

        public void Updrade(UpgradesData.UpgradeType type, int value)
        {
            Action<Monster, int> upgradeAction;

            switch (type)
            {
                case (UpgradesData.UpgradeType.Health):
                    upgradeAction = UpgradeMonsterHealth;
                    break;
                case (UpgradesData.UpgradeType.DamageMultiplier):
                    upgradeAction = UpgradeMonsterDamage;
                    break;
                case (UpgradesData.UpgradeType.AttackSpeed):
                    upgradeAction = UpgradeMonsterAttackSpeed;
                    break;
                default:
                    throw new NotImplementedException();
            }

            foreach (Monster monster in _playerMonsters.SpawnedMonsters)
            {
                if (monster != null)
                {
                    var upgradeValue = value;
                    upgradeAction(monster, upgradeValue);
                }
            }
        }

        #region Upgrade functions

        private void UpgradeMonsterHealth(Monster monster, int upradeValue)
        {
            monster.Health.UpgradeHealth(upradeValue);
        }

        private void UpgradeMonsterDamage(Monster monster, int upradeValue)
        {
            monster.Damager.UpgradeDamage(upradeValue);
        }

        private void UpgradeMonsterAttackSpeed(Monster monster, int upradeValue)
        {
            monster.Damager.UpgradeAttackSpeed(upradeValue);
        }
        #endregion
    }
}