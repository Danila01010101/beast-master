using UnityEngine;

namespace BeastMaster
{
    [System.Serializable]
	public struct MonsterSpawnParameters
    {
        public float StartDelay;
        public float SpawnInterval;
        public MonsterData Monster;
    }
}