using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
            for (int i = 0; i < _spawnedMonsters.Count; i++)
            {
                if (!_spawnedMonsters[i].Health.IsAlive)
                {
                    _spawnedMonsters.Remove(_spawnedMonsters[i]);
                    return;
                }
            }
        }

        private bool CanAddMonster() => _currentMonstersAmount < _maxMonstersAmount;

        public void RespawnMonsters() => StartCoroutine(MonstersRespawning());

        private IEnumerator MonstersRespawning()
        {
            yield return null;
            var monstersToDelete = new List<Monster>();
            for (int i = 0; i < _spawnedMonsters.Count; i++)
            {
                monstersToDelete.Add(_spawnedMonsters[i]);
            }
            foreach (var monster in monstersToDelete)
            {
                monster.Remove();
            }
            foreach (Monster monster in _spawnedMonsters)
            {
                if (monster.Health.IsAlive)
                    monster.Remove();
            }
            yield return null;
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