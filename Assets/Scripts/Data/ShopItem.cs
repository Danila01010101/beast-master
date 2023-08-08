using System;
using UnityEngine;

namespace BeastMaster
{
    public abstract class ShopItem : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public int Cost;

        public static Func<bool> CheckCanBuy;

        protected abstract void Buy();

        protected virtual bool CanBuy()
        {
            if (CheckCanBuy != null)
            {
                return CheckCanBuy();
            }
            return true;
        }

        public void TryBuy()
        {
            if (CanBuy() && Wallet.Instance.TryBuy(Cost))
            {
                Buy();
            }
        }
    }
}
