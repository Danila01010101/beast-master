using UnityEngine;

namespace BeastMaster
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Chaser : Monster
    {
        public void FixedUpdate()
        {
            if (_targetDetector.Target != null)
            {
                Vector2 direction = _targetDetector.Target.transform.position - transform.position;
                _movement.Move(direction);
            }
        }
    }
}