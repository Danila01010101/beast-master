using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _healthPoints = 10;

    private Animator _animator;

    public Health Health { get; private set; }

    public void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
    }

    public void Initialize(CharacterData data)
    {
        Health = new Health(data.StartHealth);
        _animator = Instantiate(data.CharacterAnimator, transform);
    }
}