using UnityEngine;

public class PlayerMovement : Movement
{
    private Vector2 _moveDirection;

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move(_moveDirection);
    }

    private void GetInput()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(xDirection, yDirection);
    }
}
