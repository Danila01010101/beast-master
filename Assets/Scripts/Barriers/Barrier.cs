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
        protected bool _isActivated { get; private set; } = false;
        protected int _damage { get; private set; }
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetIgnoreLayer(string layer)
        {
            gameObject.layer = LayerMask.NameToLayer(layer); 
            foreach (Transform child in _barrierTransforms)
            {
                child.gameObject.layer = LayerMask.NameToLayer(layer);
            }
            _isActivated = true;
        }

        public void Initialize(Transform parent, float lifeTime, int damage)
        {
            _damage = damage;
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
