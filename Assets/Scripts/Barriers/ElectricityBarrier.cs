using UnityEngine;

namespace BeastMaster
{
    public class ElectricityBarrier : Barrier
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isActivated && collision.gameObject.layer != gameObject.layer)
            {
                Monster monster;
                if (collision.TryGetComponent(out monster))
                {
                    monster.TakeDamage(_damage);
                }
            }
        }
    }
}
