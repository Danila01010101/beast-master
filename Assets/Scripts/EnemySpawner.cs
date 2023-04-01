using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeastMaster
{
    public class EnemySpawner : MonoBehaviour
	{
        private List<Monster> _spawnedMonsters = new List<Monster>();

		private void StartSpawningEnemies(LevelData levelData)
        {
            foreach (MonsterSpawnParameters parameters in levelData.Parameters)
            {
                this.Invoke(() => StartCoroutine(SpawnEnemies(parameters.Monster.Prefab, parameters.SpawnInterval, levelData.MapSize)), parameters.StartDelay);
            }
        }

        private IEnumerator SpawnEnemies(Monster enemyPrefab, float interval, float mapSize)
        {
            while (true)
            {
                float xPosition = Random.Range(-mapSize, mapSize);
                float yPosition = Random.Range(-mapSize, mapSize);
                Vector2 spawnPosition = new Vector2(xPosition, yPosition);
                _spawnedMonsters.Add(Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation));
                yield return new WaitForSeconds(interval);
            }
        }

        private void RemoveEnemies()
        {
            StopAllCoroutines();
            foreach (Monster monster in _spawnedMonsters)
            {
                if (monster != null)
                {
                    monster.Remove();
                }
            }
            _spawnedMonsters = new List<Monster>();
        }

        private void OnEnable()
        {
            LevelStarter.LevelStarted += StartSpawningEnemies;
            LevelStarter.LevelEnded += RemoveEnemies;
        }

        private void OnDisable()
        {
            LevelStarter.LevelStarted -= StartSpawningEnemies;
            LevelStarter.LevelEnded -= RemoveEnemies;
        }
    }
}