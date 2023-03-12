using UnityEngine;

namespace BeastMaster
{
    public class TargetDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private LayerMask _enemyLayerMask;
        [SerializeField] private float _detectRadius;

        private LayerMask _targetLayerMask;
        private Transform _transform;
        private Transform _target;
        private bool _isLookingForTarget = true;
        private const string _friendlyMonsterLayerName = "FriendlyMonster";

        public Transform Target => _target;

        private void Awake()
        {
            _transform = transform;
            _targetLayerMask = _playerLayerMask;
        }

        private void FixedUpdate()
        {
            if (_isLookingForTarget)
            {
                CheckTarget();
            }
        }

        private void CheckTarget()
        {
            var detectedObject = Physics2D.OverlapCircle(_transform.position, _detectRadius, _targetLayerMask);
            if (detectedObject != null)
            {
                _target = detectedObject.transform;
                _isLookingForTarget = false;
            }
        }

        private void ResetTarget()
        {
            _target = null;
            _isLookingForTarget = true;
        }

        public void SetPlayerFriendly()
        {
            _targetLayerMask = _enemyLayerMask;
            gameObject.layer = LayerMask.NameToLayer(_friendlyMonsterLayerName);
            ResetTarget();
        }
    }
}