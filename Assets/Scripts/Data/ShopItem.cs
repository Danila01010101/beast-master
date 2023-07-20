using UnityEngine;

namespace BeastMaster
{
    public abstract class ShopItem : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public int Cost;

        public abstract void Buy();
    }
}
