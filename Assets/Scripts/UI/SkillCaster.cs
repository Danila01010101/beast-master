using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeastMaster
{
    public class SkillCaster : MonoBehaviour
    {
        private PlayerMonsters _monsters;
        private SkillsPanel _skillsPanel;
        private List<Skill> _skills = new List<Skill>();

        public enum SpellType { Healing, SpeedIncreaser, DamageIncreaser, DefendBarrier, ElectricBarrier }

        public void Initialize(PlayerMonsters monsters, SkillsPanel panel) 
        {
            _monsters = monsters;
            _skillsPanel = panel;
        }

        public void AddSpell(SpellType type, int value, int cooldown, Sprite icon)
        {
            switch (type)
            {
                case SpellType.Healing:
                    var newSkill = new HealingSkill();
                    var newIndicator = _skillsPanel.GetIndicator();
                    newSkill.Initialize(_monsters, value, cooldown, newIndicator);
                    _skills.Add(newSkill);
                    break;
                case SpellType.SpeedIncreaser:
                    break;
                case SpellType.DamageIncreaser:
                    break;
                case SpellType.DefendBarrier:
                    var shieldBarrierSkill = new BarrierSkill();
                    shieldBarrierSkill.SetBarrierType(BarrierCreator.BarrierType.Defend);
                    var shieldBarrierIndicator = _skillsPanel.GetIndicator();
                    shieldBarrierIndicator.SetIcon(icon);
                    shieldBarrierSkill.Initialize(_monsters, value, cooldown, shieldBarrierIndicator);
                    _skills.Add(shieldBarrierSkill);
                    break;
                case SpellType.ElectricBarrier:
                    var electricityBarrierSkill = new BarrierSkill();
                    electricityBarrierSkill.SetBarrierType(BarrierCreator.BarrierType.Electricity);
                    var electricityBarrierIndicator = _skillsPanel.GetIndicator();
                    electricityBarrierIndicator.SetIcon(icon);
                    electricityBarrierSkill.Initialize(_monsters, value, cooldown, electricityBarrierIndicator);
                    _skills.Add(electricityBarrierSkill);
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private void StartCastingSpells()
        {
            if (_skills.Count == 0)
                return;
            foreach (var skill in _skills)
            {
                StartCoroutine(StartCastingSpell(skill));
            }
        }

        private void StopCastingSpells()
        {
            StopAllCoroutines();
        }

        private IEnumerator StartCastingSpell(Skill skill)
        {
            yield return new WaitForSeconds(0.1f);
            while (true)
            {
                while (!skill.TryCast())
                    yield return null;
                yield return skill.Cooldown;
            }
        }

        private void OnEnable()
        {
            SpellItem.SpellBought += AddSpell;
            LevelStarter.LevelStarted += StartCastingSpells;
            LevelStarter.LevelEnded += StopCastingSpells;
        }

        private void OnDisable()
        {
            SpellItem.SpellBought -= AddSpell;
            LevelStarter.LevelStarted -= StartCastingSpells;
            LevelStarter.LevelEnded -= StopCastingSpells;
        }
    }
}
