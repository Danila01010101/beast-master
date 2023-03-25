using UnityEditor;
using UnityEngine;

namespace BeastMaster
{
    public class Damager : MonoBehaviour
	{
        private LayerMask _damageLayer;
        private Vector2 _size;
        private Vector3 _offset;
        private CapsuleDirection2D _direction;
        private int _damage;
        private float _lastTimeDamaged;
        private bool _canDamage => _lastTimeDamaged + _damageInterval < Time.time;

        private const float _damageInterval = 0.2f;

        public void Initialize(int damage, Vector2 size, CapsuleDirection2D capsuleDirection, Vector3 offset)
        {
            _damage = damage;
            _size = size;
            _offset = offset;
            _direction = capsuleDirection;
        }

        public void SetDamageLayer(LayerMask damageLayer)
        {
            _damageLayer = damageLayer;
        }

        private void FixedUpdate()
        {
            if (_canDamage)
            {
                var detectedObjects = Physics2D.OverlapCapsuleAll(_offset + transform.position, _size, _direction, 0, _damageLayer);
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