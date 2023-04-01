using System.Collections.Generic;
using Unity.VisualScripting;
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
            _monstersData = new MonsterData[data.MaxMonstersAmount];
            _maxMonstersAmount = data.MaxMonstersAmount;
            AddMonster(data.StartMonster);
            SpawnMonsters();
        }

        private void SpawnMonsters()
        {
            foreach (MonsterData data in _monstersData)
            {
                if (data != null)
                {
                    var spawnedMonster = Instantiate(data.Prefab);
                    _spawnedMonsters.Add(spawnedMonster);
                    spawnedMonster.SetPlayerFriendly(transform);
                    spawnedMonster.gameObject.name = "Friendly" + spawnedMonster.gameObject.name;
                }
            }
        }

        public void AddMonster(MonsterData data)
        {
            if (_currentMonstersAmount < _maxMonstersAmount)
            {
                _monstersData[_currentMonstersAmount++] = data;
            }
        }
    }
}