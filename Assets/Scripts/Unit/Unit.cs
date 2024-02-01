using UnityEngine;
public class Unit : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public HealthBar healthBar; // HealthBar 스크립트 연결

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealth(currentHealth / maxHealth);
    }
}
