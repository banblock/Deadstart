using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [SerializeField]
    GameObject explosionPrefab;

    /// <summary>
    /// 투사체 삭제 : pool 반환
    /// </summary>
    protected override void DestroyBullet()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        projectilePoolManager.ReturnProjectileToPool(gameObject);
    }

}

