using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;

    private float nextTimeToFire = 0f;

    // 무기를 사용하여 공격할 때 호출되는 메서드
    public void Attack()
    {
        if (Time.time >= nextTimeToFire) {
            PerformAttack();
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    // 공격 동작을 처리하는 가상 메서드
    protected virtual void PerformAttack()
    {
        Debug.Log("Performing generic attack");
    }
}
