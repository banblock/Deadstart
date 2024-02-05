// Health.cs

using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; //체력
    protected float currentHealth; //현재체력

    public HealthBar healthBar; // HealthBar 스크립트 연결

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealth(currentHealth / maxHealth);
    }

/// <summary>
/// 데미지를 받았을때 연산
/// </summary>
/// <param name="damage"></param>
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        float healthPercentage = currentHealth / maxHealth;
        healthBar.UpdateHealth(healthPercentage);
    }
}
