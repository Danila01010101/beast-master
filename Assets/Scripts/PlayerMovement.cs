using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _moveDirection;

    private const float _moveLimiter = 0.7f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void GetInput()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(xDirection, yDirection);
    }

    public void HandleMovement()
    {
        if (_moveDirection.x != 0 && _moveDirection.y != 0)
        {
            _moveDirection *= _moveLimiter;
        }

        _rigidbody.velocity = _moveDirection.normalized * _speed * Time.fixedDeltaTime;
    }
}
