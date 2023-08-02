using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace BeastMaster
{
    public class Wallet : MonoBehaviour
    {
        private int _moneyAmount;

        public int MoneyAmount 
        {
            get
            {
                return _moneyAmount;
            }
            private set 
            {
                _moneyAmount = value;
                MoneyAmountChanged?.Invoke(); 
            } 
        }

        public static Wallet Instance { get; private set; }

        public Action MoneyAmountChanged;

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
