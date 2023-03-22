using UnityEngine;

namespace BeastMaster
{
    public class TargetDetector : MonoBehaviour
    {
        [SerializeField] private float _detectRadius;

        private LayerMask _targetLayerMask;
        private Transform _transform;
        private Transform _target;
        private bool _isLookingForTarget = true;

        public Transform Target => _target;

        private void Awake()
        {
            _transform = transform;
        }

        public void SetTargetLayer(LayerMask targetLayerMask, string gameObjectLayerName = null)
        {
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
    }
}