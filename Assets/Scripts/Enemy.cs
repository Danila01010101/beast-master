using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Movement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _detectRadius;
    [SerializeField] private float _damage;

    private Movement _movement;
    private Transform _transform;
    private float _lastHitOnCollisionTime;
    private bool _isLookingForTarget = true;
    private bool _canDamageOnCollision => Time.time > _lastHitOnCollisionTime + _collisionDamageCooldown;

    private const float _collisionDamageCooldown = 0.02f;

    private void Start()
    {
        _transform = transform;
        _movement = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        if (_isLookingForTarget)
        {
            CheckEnemy();
        }
    }

    private void CheckEnemy()
    {
        var detectedObjects = Physics2D.OverlapCircleAll(_transform.position, _detectRadius);

        foreach(Collider2D detectedObject in detectedObjects)
        {
            Player player;
            if (detectedObject.TryGetComponent(out player))
            {
                _isLookingForTarget = false;
                StartCoroutine(Chase(player));
            }
        }
    }

    private IEnumerator Chase(Player player)
    {
        while (!_isLookingForTarget)
        {
            yield return new WaitForFixedUpdate();
            Vector2 direction = player.transform.position - transform.position;
            _movement.Move(direction);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player;

        if (other.TryGetComponent(out player) && _canDamageOnCollision)
        {
            player.TakeDamage(_damage);
        }
    }
}