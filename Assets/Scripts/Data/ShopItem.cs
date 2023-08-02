using UnityEngine;

namespace BeastMaster
{
    public abstract class ShopItem : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public int Cost;

        protected abstract void Buy();

        public bool TryBuy()
        {
            if (Wallet.Instance.TryBuy(Cost))
            {
                Buy();
                return true;
            }
            return false;
        }
    }
}
