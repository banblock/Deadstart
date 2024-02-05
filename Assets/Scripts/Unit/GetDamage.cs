// GetDamage.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public float damageAmount = 20f; // 필요에 따라 데미지 양을 조절

/// <summary>
/// 충돌시 데미지를 주는 작업
/// </summary>
/// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 적에게 데미지를 입히기
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }

            // 데미지를 입힌 오브젝트 파괴
            Destroy(gameObject);
        }
    }
}
