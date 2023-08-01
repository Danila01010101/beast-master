using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "Active Item", menuName = "ScriptableObjects/New Item/New Passive Item")]
    public class PassiveItem : ShopItem
    {
        protected override void Buy()
        {
            throw new System.NotImplementedException();
        }
    }
}
