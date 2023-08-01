using System;
using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "Active Item", menuName = "ScriptableObjects/New Item/New Active Item")]
    public class MonsterItem : ShopItem
    {
        public MonsterData MonsterData;

        public static Action<MonsterData> MonsterBought;

        protected override void Buy()
        {
            MonsterBought?.Invoke(MonsterData);
        }
    }
}
