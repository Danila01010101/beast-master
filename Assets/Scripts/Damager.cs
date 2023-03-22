using UnityEngine;

namespace BeastMaster
{
    public class Damager : MonoBehaviour
	{
        private LayerMask _damageLayer;
        private Vector2 _size;
        private CapsuleDirection2D _direction;
        private int _damage;
        private float _lastTimeDamaged;
        private bool _danDamage => _lastTimeDamaged + _damageInterval < Time.time;

        private const float _damageInterval = 0.02f;

        public void Initialize(int damage, Vector2 size, CapsuleDirection2D capsuleDirection)
        {
            _damage = damage;
            _size = size;
            _direction = capsuleDirection;
        }

        public void SetDamageLayer(LayerMask damageLayer)
        {
            _damageLayer = damageLayer;
        }

        private void FixedUpdate()
        {
            if (_danDamage)
            {
                var detectedObjects = Physics2D.OverlapCapsuleAll(transform.position, _size, _direction, 0, _damageLayer);
                foreach (var detectedObject in detectedObjects)
                {
                    IDamagable damagable;
                    if (detectedObject.TryGetComponent(out damagable))
                    {
                        damagable.TakeDamage(_damage);
                        _lastTimeDamaged = Time.time;
                    }
                }
            }
        }
    }
}