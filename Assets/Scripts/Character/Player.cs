using System;
using UnityEngine;

namespace BeastMaster
{
    [RequireComponent(typeof(PlayerMonsters))]
    [RequireComponent(typeof(CharacterUpgrader))]
    [RequireComponent(typeof(SkillCaster))]
    public class Player : MonoBehaviour
    {
        private PlayerMonsters _monsters;
        private SkillCaster _skillCaster;
        private Animator _animator;

        public static Action GameOver;

        public void Initialize(CharacterData data, SkillsPanel skillsPanel)
        {
            _animator = Instantiate(data.CharacterAnimator, transform);
            _monsters = GetComponent<PlayerMonsters>();
            _monsters.Initialize(data);
            _skillCaster = GetComponent<SkillCaster>();
            _skillCaster.Initialize(_monsters, skillsPanel);
            GetComponent<CharacterUpgrader>().Initialize(_monsters);
            TrySpawnMonsters();
        }

        public void TrySpawnMonsters()
        {
            if (_monsters != null)
            {
                _monsters.RespawnMonsters();
            }
        }

        private void OnEnable()
        {
            LevelStarter.LevelStarted += TrySpawnMonsters;
        }

        private void OnDisable()
        {
            LevelStarter.LevelStarted -= TrySpawnMonsters;
        }
    }
}