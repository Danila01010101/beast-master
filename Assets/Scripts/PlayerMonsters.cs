using UnityEngine;

namespace BeastMaster
{
    public class PlayerMonsters : MonoBehaviour
    {
        private MonsterData[] _monsters;
        private int _currentMonstersAmount = 0;
        private int _maxMonstersAmount;

        public void Initialize(CharacterData data)
        {
            _monsters = new MonsterData[data.MaxMonstersAmount];
            _maxMonstersAmount = data.MaxMonstersAmount;
            AddMonster(data.StartMonster);
            SpawnMonsters();
        }

        private void SpawnMonsters()
        {
            foreach (MonsterData data in _monsters)
            {
                if (data != null)
                {
                    var spawnedMonster = Instantiate(data.Prefab);
                    spawnedMonster.SetPlayerFriendly(transform);
                    spawnedMonster.gameObject.name = "Friendly" + spawnedMonster.gameObject.name;
                }
            }
        }

        public void AddMonster(MonsterData data)
        {
            if (_currentMonstersAmount < _maxMonstersAmount)
            {
                _monsters[_currentMonstersAmount++] = data;
            }
        }
    }
}