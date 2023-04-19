using UnityEngine;

namespace BeastMaster
{
    public abstract class Skill : MonoBehaviour
	{
        protected PlayerMonsters _monsters;
        protected static float _value;

        private float _lastTimeCasted = -Mathf.Infinity;
        private SkillData _skillData;

        public void Initialize(PlayerMonsters monsters, SkillData data)
        {
            _skillData = data;
            _monsters = monsters;
            _value = data.StartValue;
        }

        public void TryCast()
        {
            if (_lastTimeCasted + _skillData.Cooldown < Time.time)
            {
                _lastTimeCasted = Time.time;
                Cast();
            }
        }

        protected abstract void Cast();

        private void Upgrade()
        {
            throw new System.NotImplementedException();
        }
	}
}