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

    // ���⸦ ����Ͽ� ������ �� ȣ��Ǵ� �޼���
    public void Attack()
    {
        if (Time.time >= nextTimeToFire) {
            PerformAttack();
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    // ���� ������ ó���ϴ� ���� �޼���
    protected virtual void PerformAttack()
    {
        Debug.Log("Performing generic attack");
    }
}
