using UnityEngine;


namespace BeastMaster
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "ScriptableObjects/NewMonsterData")]
    public class MonsterData : ScriptableObject
    {
        public Monster Prefab;
        public int StartHealth;
        public float Speed;
        public float Damage;
        public int Revard;
        [Header("Audio")]
        public AudioClip DeathSound;
        public AudioClip HitSound;
    }
}