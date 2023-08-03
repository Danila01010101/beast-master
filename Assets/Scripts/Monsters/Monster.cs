using System;
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

        public bool IsPlayerFriendly => _isFriendlyToPlayer;
        public bool IsProtected { get; set; }
        public Health Health { get { return _health; } }
        public Damager Damager { get { return _damager; } }
        public TargetDetector TargetDetector { get { return _targetDetector; } }

        public static Action<int> AddPoints;

        private void Awake()
        {
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
            _audioPlayer = GetComponent<MonsterAudioPlayer>();
            _targetDetector = GetComponent<TargetDetector>();
            _movement = GetComponent<Movement>();
            _damager = GetComponent<Damager>();
            _health = new Health(_data.StartHealth);
            _health.AddHealthBar(transform, _healthBarOffset);
            _movement.Initialize(_data);
            _damager.Initialize((int)_data.Damage, _capsuleCollider2D.size, _capsuleCollider2D.direction, _capsuleCollider2D.offset);
            _audioPlayer.Initialize(_data.DeathSound, _data.HitSound);
            _targetDetector.SetTargetLayer(_playerLayerMask, transform, _enemyMonsterLayerName);
            _damager.SetDamageLayer(_playerLayerMask);
        }

        public void TakeDamage(float damage)
        {
            if (IsProtected)
                damage /= 3;
            _health.TakeDamage(damage);
        }

        public void SetPlayerFriendly(Transform player)
        {
            _targetDetector.SetTargetLayer(_enemyLayerMask, player, _friendlyMonsterLayerName);
            _damager.SetDamageLayer(_enemyLayerMask);
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

        public void Remove()
        {
            _capsuleCollider2D.enabled = false;
            _targetDetector.enabled = false;
            _audioPlayer.enabled = false;
            _movement.enabled = false;
            _damager.enabled = false;
            _health.TakeMortalDamage();
            Destroy(gameObject);
        }

        public void AddRevard()
        {
            if (!_isFriendlyToPlayer)
            {
                AddPoints?.Invoke(_data.Revard);
            }
        }

        private void OnEnable()
        {
            _health.Death += Remove;
            _health.Death += AddRevard;
            _health.Death += PlayDeathSound;
            _health.HealthChanged += PlayHitSound;
        }

        private void OnDisable()
        {
            _health.Death -= Remove;
            _health.Death -= AddRevard;
            _health.Death -= PlayDeathSound;
            _health.HealthChanged -= PlayHitSound;
        }
    }
}