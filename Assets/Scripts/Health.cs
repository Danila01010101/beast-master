
using System;
using UnityEngine;

namespace BeastMaster
{
    public class Health
    {
        private float _maxHealth;
        private bool _needHealthBar;
        private bool _hasHealthBar = false;

        public bool IsAlive => Value > 0;

        public float MaxHealth => _maxHealth;
        public float Value 
        {
            get
            {
                return Value;
            }
            private set
            {
                float newHealthAmount = Value + value;
                if (newHealthAmount > _maxHealth)
                {
                    Value = _maxHealth;
                }
                else
                {
                    Value = newHealthAmount;
                }
            }
        }

        public static Action<Health, Transform, Vector3> OnHealthAdded;
        public static Action<Health> OnHealthRemoved;
        public Action HealthChanged;
        public Action Death;

        public Health(float maxHealth)
        {
            _maxHealth = maxHealth;
            Value = _maxHealth;
        }

        public Health(float maxHealth, Transform healthBarPosition, Vector3 healthBarOffset = new Vector3()) : this(maxHealth)
        {
            AddHealthBar(healthBarPosition, healthBarOffset);
        }

        public void AddHealthBar(Transform healthBarPosition, Vector3 healthBarOffset = new Vector3())
        {
            if (!_hasHealthBar)
            {
                _needHealthBar = true;
                OnHealthAdded?.Invoke(this, healthBarPosition, healthBarOffset);
                _hasHealthBar = true;
            }
        }

        public void TakeDamage(float damage)
        {
            if (IsAlive)
            {
                Value -= damage;
                HealthChanged?.Invoke();
                if (Value <= 0)
                {
                    Value = 0;
                    if (_needHealthBar)
                    {
                        OnHealthRemoved?.Invoke(this);
                    }
                    Death?.Invoke();
                }
            }
        }

        public void UpgradeHealth(int healthAmount)
        {
            _maxHealth += healthAmount;
        }

        public void Heal(float healAmount)
        {
            Value += healAmount;
        }
    }
}