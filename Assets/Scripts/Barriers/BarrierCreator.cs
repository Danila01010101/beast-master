using UnityEngine;

namespace BeastMaster
{
    public class BarrierCreator : MonoBehaviour
    {
        [SerializeField] private BarriersData _barriers;

        public enum BarrierType { Defend }

        public static BarrierCreator Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public Barrier AddBarrier(BarrierType type, Transform parent, float lifeTime)
        {
            switch (type)
            {
                case BarrierType.Defend:
                    Barrier barrier = Instantiate(_barriers.ProtectBarrier);
                    barrier.Initialize(parent, lifeTime);
                    return barrier;
                default: 
                    throw new System.NotImplementedException();
            }
        }
    }
}
