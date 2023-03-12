using UnityEngine;

namespace BeastMaster
{
    [RequireComponent(typeof(PlayerMonsters))]
    public class Player : MonoBehaviour
    {
        private PlayerMonsters _monsters;
        private Animator _animator;

        public Health Health { get; private set; }

        public void TakeDamage(float damage)
        {
            Health.TakeDamage(damage);
        }

        public void Initialize(CharacterData data)
        {
            Health = new Health(data.StartHealth);
            _animator = Instantiate(data.CharacterAnimator, transform);
            _monsters = GetComponent<PlayerMonsters>();
            _monsters.Initialize(data);
        }
    }
}