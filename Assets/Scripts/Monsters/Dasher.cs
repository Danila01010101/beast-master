using System.Collections;
using UnityEngine;

namespace BeastMaster
{
    public class Dasher : Monster
    {
        [SerializeField] private float _dashRange = 3.5f;
        [SerializeField] private float _dashReload = 1f;
        [SerializeField] private float _dashChargeTime = 0.3f;
        [SerializeField] private float _dashDuration = 0.3f;
        [SerializeField] private Animator _animator;

        private string _dashAnimationName = "Dash";
        private float _lastTimeDashed = 0f;
        private bool _isDashing = false;

        public void FixedUpdate()
        {
            if (_targetDetector.Target != null && !_isDashing)
            {
                Vector2 direction = _targetDetector.Target.transform.position - transform.position;
                _movement.Move(direction);
                if (_lastTimeDashed + _dashReload < Time.time && Vector2.Distance(_targetDetector.Target.position, transform.position) < _dashRange)
                {
                    _movement.Stop();
                    StartCoroutine(StartDashing());
                }
            }
        }

        private IEnumerator StartDashing()
        {
            _animator.SetTrigger(_dashAnimationName);
            yield return _dashChargeTime;
            Vector2 direction = _targetDetector.Target.transform.position - transform.position;
            var endDashTime = Time.time + _dashDuration;
            while (endDashTime > Time.time)
            {
                _movement.Move(direction, 2.5f);
                yield return new WaitForFixedUpdate();
            }
            _isDashing = false;
            _lastTimeDashed = Time.time;
        }
    }
}