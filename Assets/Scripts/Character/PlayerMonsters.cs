using System.Collections.Generic;
using UnityEngine;

namespace BeastMaster
{
    public class PlayerMonsters : MonoBehaviour
    {
        private MonsterData[] _monstersData;
        private List<Monster> _spawnedMonsters = new List<Monster>();
        private int _currentMonstersAmount = 0;
        private int _maxMonstersAmount;

        public IReadOnlyList<Monster> SpawnedMonsters => _spawnedMonsters;

        public void Initialize(CharacterData data)
        {
            MonsterItem.CheckCanBuy += CanAddMonster;
            _monstersData = new MonsterData[data.MaxMonstersAmount];
            _maxMonstersAmount = data.MaxMonstersAmount;
            AddMonster(data.StartMonster);
        }

        public void RespawnMonsters()
        {
            foreach (Monster monster in _spawnedMonsters)
            {
                monster.Remove();
            }
            _spawnedMonsters = new List<Monster>();
            foreach (MonsterData data in _monstersData)
            {
                if (data != null)
                {
                    var spawnedMonster = Instantiate(data.Prefab);
                    _spawnedMonsters.Add(spawnedMonster);
                    spawnedMonster.SetPlayerFriendly(transform);
                    spawnedMonster.gameObject.name = "Friendly" + spawnedMonster.gameObject.name;
                    spawnedMonster.Health.Death += DetectMonsterDeath;
                }
            }
            _currentMonstersAmount = _spawnedMonsters.Count;
        }

        public void AddMonster(MonsterData data)
        {
            if (_currentMonstersAmount < _maxMonstersAmount)
            {
                _monstersData[_currentMonstersAmount++] = data;
            }
        }

        public void DetectMonsterDeath()
        {
            if (--_currentMonstersAmount <= 0)
            {
                Player.GameOver?.Invoke();
            }
        }

        private bool CanAddMonster() => _currentMonstersAmount < _maxMonstersAmount;

        private void OnEnable()
        {
            MonsterItem.MonsterBought += AddMonster;
        }

        private void OnDisable()
        {
            MonsterItem.MonsterBought -= AddMonster;
        }

        private void OnDestroy()
        {
            MonsterItem.CheckCanBuy -= CanAddMonster;
        }
    }
}