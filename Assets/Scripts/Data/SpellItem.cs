using System;
using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "Spell Item", menuName = "ScriptableObjects/New Item/Spell Item")]
    public class SpellItem : ShopItem
    {
        public SkillCaster.SpellType SkillType;
        public int Value;
        public int Cooldown;

        public static Action<SkillCaster.SpellType, int, int, Sprite> SpellBought;

        public override void Buy()
        {
            SpellBought?.Invoke(SkillType, Value, Cooldown, Icon);
        }
    }
}
