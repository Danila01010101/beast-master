using UnityEngine;

namespace BeastMaster
{
	[RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(TargetDetector))]
    public class Monster : MonoBehaviour, IDamagable
	{
		[SerializeField] private MonsterData _data;

        protected Health _health;
		protected Movement _movement;
        protected TargetDetector _targetDetector;

        public TargetDetector TargetDetector { get { return _targetDetector; } }

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _targetDetector = GetComponent<TargetDetector>();
            _health = new Health(_data.StartHealth);
            _movement.Initialize(_data);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            _health.Death += Die;
        }

        private void OnDisable()
        {
            _health.Death -= Die;
        }
    }
}