using UnityEngine;

namespace BeastMaster
{
    public class TargetDetector : MonoBehaviour
    {
        [SerializeField] private float _detectRadius;

        private LayerMask _targetLayerMask;
        private Transform _protectTarget;
        private Transform _attackTarget;
        private bool _isLookingForTarget = true;

        public Transform Target => _attackTarget;
        public Transform ProtectTarget => _protectTarget;

        private void Awake()
        {
            _protectTarget = transform;
        }

        public void SetTargetLayer(LayerMask targetLayerMask, Transform targetToProtect, string gameObjectLayerName = null)
        {
            _protectTarget = targetToProtect;
            _targetLayerMask = targetLayerMask;
            if (gameObjectLayerName != null)
            {
                gameObject.layer = LayerMask.NameToLayer(gameObjectLayerName);
            }
            ResetTarget();
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
            var detectedObject = Physics2D.OverlapCircle(_protectTarget.position, _detectRadius, _targetLayerMask);
            if (detectedObject != null)
            {
                _attackTarget = detectedObject.transform;
                _isLookingForTarget = false;
            }
        }

        private void ResetTarget()
        {
            _attackTarget = null;
            _isLookingForTarget = true;
        }
    }
}