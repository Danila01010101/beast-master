using System.Collections;
using UnityEngine;

namespace BeastMaster
{
    public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private LevelData _levelData;

        private void StartSpawn()
        {
            foreach (MonsterSpawnParameters parameters in _levelData.Parameters)
            {
                this.Invoke(() => StartCoroutine(SpawnEnemies(parameters.Monster.Prefab.gameObject, parameters.SpawnInterval)), parameters.StartDelay);
            }
        }

        private IEnumerator SpawnEnemies(GameObject enemyPrefab, float interval)
        {
            while (true)
            {
                float xPosition = Random.Range(-_levelData.MapSize, _levelData.MapSize);
                float yPosition = Random.Range(-_levelData.MapSize, _levelData.MapSize);
                Vector2 spawnPosition = new Vector2(xPosition, yPosition);
                Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
                yield return new WaitForSeconds(interval);
            }
        }

        private void OnEnable()
        {
            Player.CharacterSpawned += StartSpawn;
        }

        private void OnDisable()
        {
            Player.CharacterSpawned -= StartSpawn;
        }
    }
}