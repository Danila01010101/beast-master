
using System;

namespace BeastMaster
{
    public class Health
    {
        private float _maxhealth;

        public bool IsAlive => Value > 0;

        public float Value { get; private set; }

        public Action Death;

        public Health(float maxHealth)
        {
            _maxhealth = maxHealth;
            Value = _maxhealth;
        }

        public void TakeDamage(float damage)
        {
            if (IsAlive)
            {
                Value -= damage;
                if (Value <= 0)
                {
                    Value = 0;
                    Death?.Invoke();
                }
            }
        }
    }
}