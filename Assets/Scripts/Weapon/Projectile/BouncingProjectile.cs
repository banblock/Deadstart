using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 반사 가능한 투사체
/// </summary>
public class BouncingProjectile : Projectile
{

    [SerializeField]
    private float bounceSpread = 80f; // 반사 확산 정도
    private Collider2D collidedEnemies;
    [SerializeField]
    private int maxBounceCount = 3; // 최대 튕기는 정도
    private int currentBounceCount;

    protected override void SetInit()
    {
        base.SetInit();
        collidedEnemies = null;
        currentBounceCount = maxBounceCount;
    }

    

    protected override void HitEnemy(Collider2D enemyCollider)
    {
        //enemy.TakeDamage(projectileDamage);
        if (collidedEnemies != enemyCollider) {
            collidedEnemies = enemyCollider;
            if(currentBounceCount > 0) {
                Bounce();
            }
            DestroyBullet();
        }
    }

    protected override void HitBuilding(Collider2D buildingCollider)
    {
        if (currentBounceCount > 0) {
            Bounce(180f);
        }
        DestroyBullet();
    }

    private void Bounce(float addAngle = 0)
    {
        float angle = Random.Range(-bounceSpread, bounceSpread) + addAngle;
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + angle);
        GameObject newProjectile = projectilePoolManager.GetProjectileFromPool(gameObject, transform.position, bulletRotation);
        BouncingProjectile newSplitProjectile = newProjectile.GetComponent<BouncingProjectile>();
        newSplitProjectile.collidedEnemies = collidedEnemies;
        newSplitProjectile.currentBounceCount = currentBounceCount - 1;
    }
}
