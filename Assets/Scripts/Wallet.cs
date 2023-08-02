using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace BeastMaster
{
    public class Wallet : MonoBehaviour
    {
        public int MoneyAmount { get; private set; }

        public static Wallet Instance { get; private set; }

        private void AddMoney(int value) => MoneyAmount += value;

        private void Awake()
        {
            Instance = this;
        }

        public bool TryBuy(int cost)
        {
            if (MoneyAmount >= cost)
            {
                MoneyAmount -= cost;
                return true;
            }
            return false;
        }

        private void OnEnable()
        {
            Monster.AddPoints += AddMoney;
        }

        private void OnDisable()
        {
            Monster.AddPoints -= AddMoney;
        }

        [Button("AddMoney")]
        private void MoneyButton()
        {
            AddMoney(10000);
        }
    }
}
