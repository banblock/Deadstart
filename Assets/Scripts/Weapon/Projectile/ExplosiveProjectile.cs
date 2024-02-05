using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [SerializeField]
    GameObject explosionPrefab;

    /// <summary>
    /// ����ü ���� : pool ��ȯ
    /// </summary>
    protected override void DestroyBullet()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        projectilePoolManager.ReturnProjectileToPool(gameObject);
    }

}
