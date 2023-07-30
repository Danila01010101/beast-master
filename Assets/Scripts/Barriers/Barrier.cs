using System.Collections;
using UnityEngine;

namespace BeastMaster
{
    public abstract class Barrier : MonoBehaviour
    {
        [SerializeField] private Transform _rotator;
        [SerializeField] private float _barriersSpeed;
        [SerializeField] private Transform[] _barrierTransforms;
        [SerializeField] private ParticleSystem _destroyParticles;

        private float _speedMultiplier = 0.5f;

        public void Initialize(Transform parent, float lifeTime)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
            if (_destroyParticles != null)
                StartCoroutine(PlayDestroyParticles(lifeTime));
            Destroy(gameObject, lifeTime);
        }

        protected void Update()
        {
            _rotator.Rotate(Vector3.forward, _barriersSpeed * Time.deltaTime);
        }

        private IEnumerator PlayDestroyParticles(float time)
        {
            yield return new WaitForSeconds(time - 0.1f);
            foreach (Transform t in _barrierTransforms)
            {
                Instantiate(_destroyParticles, t.position, t.rotation);
            }
        }
    }
}
