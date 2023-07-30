using static BeastMaster.BarrierCreator;

namespace BeastMaster
{
    public class BarrierSkill : Skill
    {
        private float CooldownLifetime = 0.25f;

        private BarrierType _type;

        public void SetBarrierType(BarrierType type) => _type = type;

        protected override void Cast()
        {
            foreach (Monster monster in _monsters.SpawnedMonsters)
            {
                BarrierCreator.Instance.AddBarrier(_type, monster.transform, Cooldown * CooldownLifetime);
            }
        }

        protected override void Upgrade()
        {
            base.Upgrade();
            CooldownLifetime += 0.25f;
        }
    }
}