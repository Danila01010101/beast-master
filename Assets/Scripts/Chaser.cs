using UnityEngine;

namespace BeastMaster
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Chaser : Monster
    {
        [SerializeField] private float _damage;

        private float _lastHitOnCollisionTime;
        private bool _canDamageOnCollision => Time.time > _lastHitOnCollisionTime + _collisionDamageCooldown;

        private const float _collisionDamageCooldown = 0.02f;

        public void FixedUpdate()
        {
            if (_targetDetector.Target != null)
            {
                Vector2 direction = _targetDetector.Target.transform.position - transform.position;
                _movement.Move(direction);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            IDamagable target;

            if (collision.TryGetComponent(out target) && _canDamageOnCollision)
            {
                target.TakeDamage((int)_damage);
            }
        }
    }
}