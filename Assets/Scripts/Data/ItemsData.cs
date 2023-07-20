using System.Collections.Generic;
using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "Shop Items", menuName = "ScriptableObjects/NewItemsList")]
    public partial class ItemsData : ScriptableObject
    {
        [SerializeField] private List<ShopItem> Items;

        public ShopItem GetRandomItem()
        {
            if (Items == null)
                throw new System.NullReferenceException();

            int randomItemindex = Random.Range(0, Items.Count);
            return Items[randomItemindex];
        }
    }
}