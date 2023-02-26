using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _healthPoints = 10;

    public Health Health { get; private set; }

    private void Awake()
    {
        Health = new Health(_healthPoints);
    }

    public void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
    }
}
