using UnityEngine;

namespace BeastMaster
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Chaser : Monster
    {
        public void FixedUpdate()
        {
            if (_isFriendlyToPlayer && TargetDetector.Target == null)
            {
                if (Vector2.Distance(TargetDetector.ProtectTarget.position, transform.position) > _playerFollowRadius)
                {
                    _movement.Move(TargetDetector.ProtectTarget.position - transform.position);
                }
                else
                {
                    _movement.Stop();
                }
                return;
            }

            if (_targetDetector.Target != null)
            {
                Vector2 direction = _targetDetector.Target.transform.position - transform.position;
                _movement.Move(direction);
            }
        }
    }
}