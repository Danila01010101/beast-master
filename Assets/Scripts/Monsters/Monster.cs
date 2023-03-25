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
        [SerializeField] private bool _needHealthBar = false;
        [SerializeField] private Vector3 _healthBarOffset;

        [SerializeField] protected float _playerFollowRadius;

        private MonsterAudioPlayer _audioPlayer;
        private Damager _damager;
        private CapsuleCollider2D _capsuleCollider2D;
        private const string _friendlyMonsterLayerName = "FriendlyMonster";
        private const string _enemyMonsterLayerName = "EnemyMonster";

        protected bool _isFriendlyToPlayer = false;
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
            _audioPlayer = GetComponent<MonsterAudioPlayer>();
            _health = new Health(_data.StartHealth);
            _movement.Initialize(_data);
            _damager.Initialize((int)_data.Damage, _capsuleCollider2D.size, _capsuleCollider2D.direction);
            _audioPlayer.Initialize(_data.DeathSound, _data.HitSound);
            _targetDetector.SetTargetLayer(_playerLayerMask, transform, _enemyMonsterLayerName);
            _damager.SetDamageLayer(_playerLayerMask);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        public void SetPlayerFriendly(Transform player)
        {
            _targetDetector.SetTargetLayer(_enemyLayerMask, player, _friendlyMonsterLayerName);
            _damager.SetDamageLayer(_enemyLayerMask);
            _health.AddHealthBar(transform, _healthBarOffset);
            _isFriendlyToPlayer = true;
        }

        private void PlayDeathSound()
        {
            _audioPlayer.PlaySound(MonsterAudioPlayer.Sound.Death);
        }

        private void PlayHitSound()
        {
            _audioPlayer.PlaySound(MonsterAudioPlayer.Sound.Hit);
        }

        private void OnEnable()
        {
            _health.Death += Die;
            _health.Death += PlayDeathSound;
            _health.HealthChanged += PlayHitSound;
        }

        private void OnDisable()
        {
            _health.Death -= Die;
            _health.Death -= PlayDeathSound;
            _health.HealthChanged -= PlayHitSound;
        }
    }
}