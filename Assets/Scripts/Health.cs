public class Health
{
    public bool IsAlive => Value > 0;
    public float Value { get; private set; }

    public Health(float healthPoint)
    {
        Value = healthPoint;
    }

    public void TakeDamage(float damage)
    {
        if (IsAlive)
        {
            Value -= damage;
        }
    }
}