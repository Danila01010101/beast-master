using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/NewCharacterData")]
    public class CharacterData : ScriptableObject
    {
        public Animator CharacterAnimator;
        public int StartHealth = 100;
        public int StartDamagePercentBonus = 0;
        public int StartArmor = 0;
        public int MaxMonstersAmount = 4;
        public MonsterData StartMonster;
    }
}