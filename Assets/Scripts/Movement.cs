using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    protected const float _moveLimiter = 0.7f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
    }

    public void Move(Vector2 moveDirection)
    {
        if (moveDirection.x != 0 && moveDirection.y != 0)
        {
            moveDirection *= _moveLimiter;
        }

        _rigidbody.velocity = moveDirection.normalized * _speed * Time.fixedDeltaTime;
    }

    public void Push(Vector2 force)
    {
        _rigidbody.AddForce(force, ForceMode2D.Impulse);
    }
}
