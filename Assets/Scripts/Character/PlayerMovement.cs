using UnityEngine;

namespace BeastMaster
{
    public class PlayerMovement : Movement
    {
        private Vector2 _moveDirection;
        private bool _canMove = false;

        private void EnableMovement() => _canMove = true;
        private void DisableMovement() => _canMove = false;

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

        private void OnEnable()
        {
            LevelStarter.LevelStarted += EnableMovement;
            LevelStarter.LevelEnded += DisableMovement;
        }

        private void OnDisable()
        {
            LevelStarter.LevelStarted -= EnableMovement;
            LevelStarter.LevelEnded -= DisableMovement;
        }
    }
}