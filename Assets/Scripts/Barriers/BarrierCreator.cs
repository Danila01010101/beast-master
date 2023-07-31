using UnityEngine;

namespace BeastMaster
{
    public class BarrierCreator : MonoBehaviour
    {
        [SerializeField] private BarriersData _barriers;
        [SerializeField] private string _friendlyLayerMask;
        [SerializeField] private string _enemiesLayerMask;

        public enum BarrierType { Defend, Electricity }

        public static BarrierCreator Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public Barrier AddBarrier(BarrierType type, Transform parent, float lifeTime, int damage, bool isFriendly = true)
        {
            switch (type)
            {
                case BarrierType.Defend:
                    Barrier protectBarrier = Instantiate(_barriers.ProtectBarrier);
                    protectBarrier.Initialize(parent, lifeTime, damage);
                    return protectBarrier;
                case BarrierType.Electricity:
                    ElectricityBarrier electricBarrier = Instantiate(_barriers.ElectricityBarrier);
                    electricBarrier.Initialize(parent, lifeTime, damage);
                    electricBarrier.SetIgnoreLayer(_friendlyLayerMask);
                    return electricBarrier;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
