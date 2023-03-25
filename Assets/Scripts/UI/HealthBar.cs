using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
	public class HealthBar : MonoBehaviour
	{
		[SerializeField] private Image _progressBar;

        private Health _health;
		private Transform _followTransform;
		private Vector3 _offset;

		public void Initialize(Health health, Transform followTransform, Vector3 offset)
		{
			_health = health;
			_followTransform = followTransform;
			_offset = offset;
            _health.HealthChanged += UpdateHealth;
		}

		private void UpdateHealth()
		{
			_progressBar.fillAmount = _health.Value / _health.MaxHealth;
		}

        private void LateUpdate()
        {
			if (_followTransform != null)
            {
                transform.position = Camera.main.WorldToScreenPoint(_followTransform.position + _offset);
            }
        }
    }
}