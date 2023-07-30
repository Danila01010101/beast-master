using UnityEngine;

namespace BeastMaster
{
    public abstract class Skill
	{
        protected PlayerMonsters _monsters;
        private SkillIndicator _skillIndicator;
        private float _lastTimeCasted = -Mathf.Infinity;

        public float Cooldown { get; protected set; }
        public float Value { get; protected set; }

        public void Initialize(PlayerMonsters monsters, int value, int cooldown, SkillIndicator indicator = null)
        {
            Value = value;
            Cooldown = cooldown;
            _monsters = monsters;
            _skillIndicator = indicator;
        }

        public bool TryCast()
        {
            if (_lastTimeCasted + Cooldown < Time.time)
            {
                _lastTimeCasted = Time.time;
                if (_skillIndicator != null)
                    _skillIndicator.ShowReload(Cooldown);
                Cast();
                return true;
            }
            return false;
        }

        protected abstract void Cast();

        protected virtual void Upgrade()
        {
            Value *= 1.2f;
            Cooldown /= 1.5f;
        }
	}
}