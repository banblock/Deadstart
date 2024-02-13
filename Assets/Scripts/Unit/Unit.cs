using UnityEngine;
public class Unit : MonoBehaviour
{
    public float maxHealth = 100f;
    protected float currentHealth;

    [SerializeField]
    HpBarComponent healthBar; // HealthBar 스크립트 연결

    void Start()
    {
        SetInit();
    }

    protected virtual void SetInit()
    {
        currentHealth = maxHealth;
        healthBar.UpdateStatus(maxHealth, currentHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateStatus(maxHealth, currentHealth);

        Debug.Log(currentHealth);
        if (currentHealth <= 0f) {
            Die();
        }
    }

    protected virtual void Die()
    {
        // 죽었을 때 처리할 내용을 여기에 추가
        Destroy(gameObject);
    }
}
