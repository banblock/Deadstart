using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected ProjectilePoolManager projectilePoolManager;

    [SerializeField]
    protected float projectileSpeed = 10f;  // 총알 이동 속도
    [SerializeField]
    protected float projectileDamage = 1f;

    void Start()
    {
        projectilePoolManager = ProjectilePoolManager.Instance;
    }

    void FixedUpdate()
    {
        MoveBullet();
        DestroyBullet();
    }

    protected virtual void MoveBullet()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    protected virtual void DestroyBullet()
    {
        if (!IsInScreen()) {
            projectilePoolManager.ReturnProjectileToPool(this.gameObject);
        }
    }

    protected bool IsInScreen()
    {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1);
    }

}
