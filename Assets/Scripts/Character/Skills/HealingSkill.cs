namespace BeastMaster
{
    public class HealingSkill : Skill
    {
        protected override void Cast()
        {
            foreach (Monster monster in _monsters.SpawnedMonsters)
            {
                monster.Health.Heal(_value);
            }
        }
    }
}