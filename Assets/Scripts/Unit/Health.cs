// Health.cs

using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    protected float currentHealth;

    public HealthBar healthBar; // HealthBar 스크립트 연결

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealth(currentHealth / maxHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        float healthPercentage = currentHealth / maxHealth;
        healthBar.UpdateHealth(healthPercentage);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // 죽었을 때 처리할 내용을 여기에 추가
        Destroy(gameObject);
    }
}
