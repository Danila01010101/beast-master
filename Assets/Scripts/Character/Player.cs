using System;
using UnityEngine;

namespace BeastMaster
{
    [RequireComponent(typeof(PlayerMonsters))]
    [RequireComponent(typeof(CharacterUpgrader))]
    public class Player : MonoBehaviour
    {
        private PlayerMonsters _monsters;
        private Animator _animator;

        public void Initialize(CharacterData data)
        {
            _animator = Instantiate(data.CharacterAnimator, transform);
            _monsters = GetComponent<PlayerMonsters>();
            _monsters.Initialize(data);
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