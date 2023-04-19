using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/New Skill")]
    public class SkillData : ScriptableObject
	{
		public int Cooldown;
		public int StartValue;
	}
}