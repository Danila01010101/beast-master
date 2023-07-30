namespace BeastMaster
{
    public class HealingSkill : Skill
    {
        protected override void Cast()
        {
            foreach (Monster monster in _monsters.SpawnedMonsters)
            {
                if (monster != null && monster.Health.IsAlive)
                    monster.Health.Heal(Value);
            }
        }

        protected override void Upgrade()
        {
            Value *= 1.2f;
            Cooldown /= 1.5f;
        }
    }
}