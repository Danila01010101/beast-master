using UnityEngine;

namespace BeastMaster
{
    public abstract class ShopItem : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public int Cost;

        protected abstract void Buy();

        public void TryBuy()
        {
            if (Wallet.Instance.TryBuy(Cost))
            {
                Buy();
            }
        }
    }
}
