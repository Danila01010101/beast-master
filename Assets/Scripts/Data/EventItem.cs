using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "Active Item", menuName = "ScriptableObjects/New Item/New Event Item")]
    public class EventItem : ShopItem
    {
        public override void Buy()
        {
            throw new System.NotImplementedException();
        }
    }
}
