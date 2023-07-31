using UnityEngine;

namespace BeastMaster
{
    [CreateAssetMenu(fileName = "DefaultBarrier", menuName = "ScriptableObjects/New Barrier")]
    public class BarriersData : ScriptableObject
    {
        public ProtectBarrier ProtectBarrier;
        public ElectricityBarrier ElectricityBarrier;
    }
}
