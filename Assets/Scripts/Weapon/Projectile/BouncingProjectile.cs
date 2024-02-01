using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingProjectile : Projectile
{

    [SerializeField]
    private float bounceSpread = 80f; // 반사 확산 정도
    private Collider2D collidedEnemies;
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

    private void Bounce()
    {
        float angle = Random.Range(-bounceSpread, bounceSpread);
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + 180 + angle);
        GameObject newProjectile = projectilePoolManager.GetProjectileFromPool(gameObject, transform.position, bulletRotation);
        BouncingProjectile newSplitProjectile = newProjectile.GetComponent<BouncingProjectile>();
        newSplitProjectile.collidedEnemies = collidedEnemies;
        newSplitProjectile.currentBounceCount = currentBounceCount - 1;
    }
}
