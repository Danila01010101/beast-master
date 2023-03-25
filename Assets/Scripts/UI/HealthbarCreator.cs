using System.Collections.Generic;
using UnityEngine;

namespace BeastMaster
{
	public class HealthbarCreator : MonoBehaviour
	{
        [SerializeField] private Canvas _canvas;
		[SerializeField] private HealthBar _healthBarPrefab;

		private Dictionary<Health, HealthBar> _healthBars = new Dictionary<Health, HealthBar>();

        private void OnEnable()
        {
            Health.OnHealthAdded += AddHealthBar;
            Health.OnHealthRemoved += RemoveHealthBar;
        }

        private void OnDisable()
        {
            Health.OnHealthAdded -= AddHealthBar;
            Health.OnHealthRemoved -= RemoveHealthBar;
        }

        private void AddHealthBar(Health health, Transform followTransform, Vector3 offset)
        {
            var healthBar = Instantiate(_healthBarPrefab, _canvas.transform);
            healthBar.Initialize(health, followTransform, offset);
            _healthBars.Add(health, healthBar);
        }

        private void RemoveHealthBar(Health health)
        {
            Destroy(_healthBars[health].gameObject);
            _healthBars.Remove(health);
        }
    }
}