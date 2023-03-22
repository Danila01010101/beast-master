using UnityEngine;

namespace BeastMaster
{
	[RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(TargetDetector))]
    [RequireComponent(typeof(Damager))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(MonsterAudioPlayer))]
    public class Monster : MonoBehaviour, IDamagable
	{
		[SerializeField] private MonsterData _data;
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private LayerMask _enemyLayerMask;

        private MonsterAudioPlayer _audioPlayer;
        private Damager _damager;
        private CapsuleCollider2D _capsuleCollider2D;
        private const string _friendlyMonsterLayerName = "FriendlyMonster";
        private const string _enemyMonsterLayerName = "EnemyMonster";

        protected Health _health;
		protected Movement _movement;
        protected TargetDetector _targetDetector;

        public TargetDetector TargetDetector { get { return _targetDetector; } }

        private void Awake()
        {
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
            _movement = GetComponent<Movement>();
            _targetDetector = GetComponent<TargetDetector>();
            _damager = GetComponent<Damager>();
            _health = new Health(_data.StartHealth);
            _movement.Initialize(_data);
            _damager.Initialize((int)_data.Damage, _capsuleCollider2D.size, _capsuleCollider2D.direction);
            _audioPlayer.Initialize(_data.DeathSound, _data.HitSound);
            SetPlayerFriendly(false);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        public void SetPlayerFriendly(bool isPlayerFriendly)
        {
            if (isPlayerFriendly)
            {
                _targetDetector.SetTargetLayer(_enemyLayerMask, _friendlyMonsterLayerName);
                _damager.SetDamageLayer(_enemyLayerMask);
            }
            else
            {
                _targetDetector.SetTargetLayer(_playerLayerMask, _enemyMonsterLayerName);
                _damager.SetDamageLayer(_playerLayerMask);
            }
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