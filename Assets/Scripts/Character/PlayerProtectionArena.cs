using UnityEngine;

namespace BeastMaster
{
    public class PlayerProtectionArena : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _area;
        [SerializeField] private float _startRadius = 2f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Monster monster;
            if (collision.TryGetComponent(out monster) && monster.IsPlayerFriendly)
            {
                monster.IsProtected = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Monster monster;
            if (collision.TryGetComponent(out monster) && monster.IsPlayerFriendly)
            {
                monster.IsProtected = false;
            }
        }

        private void EnableArea() => _area.enabled = true;

        private void DisableArea() => _area.enabled = false;

        private void Start()
        {
            _area.radius = _startRadius;
        }

        private void OnEnable()
        {
            _area.enabled = true;
            LevelStarter.LevelStarted += EnableArea;
            LevelStarter.LevelEnded += DisableArea;
        }

        private void OnDisable()
        {
            _area.enabled = false;
            LevelStarter.LevelStarted -= EnableArea;
            LevelStarter.LevelEnded -= DisableArea;
        }
    }
}
