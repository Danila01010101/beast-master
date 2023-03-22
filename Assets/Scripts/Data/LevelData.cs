using System.Collections.Generic;
using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/NewLevel")]
    public class LevelData : ScriptableObject
	{
        public float MapSize = 5;

        public List<MonsterSpawnParameters> Parameters;
	}
}