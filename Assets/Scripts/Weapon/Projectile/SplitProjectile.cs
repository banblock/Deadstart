using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SplitProjectile : Projectile
{
    [SerializeField]
    private int splitCount = 10;  // 분열 개수
    private float splitSpread = 80f; // 분열 확산 정도

    private Collider2D collidedEnemies;
  
    protected override void SetInit()
    {
        base.SetInit();
        collidedEnemies = null;
    }

    protected override void HitEnemy(Collider2D enemyCollider)
    {
        //enemy.TakeDamage(projectileDamage);
        if (collidedEnemies != enemyCollider) {
            collidedEnemies = enemyCollider;
            Split();
            DestroyBullet();
        }
    }

    private void Split()
    {
        for (int i = 0; i < splitCount; i++) {

            float angle = Random.Range(-splitSpread, splitSpread);
            Quaternion bulletRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + angle);

            GameObject newProjectile = projectilePoolManager.GetProjectileFromPool(gameObject, transform.position, bulletRotation);

            SplitProjectile newSplitProjectile = newProjectile.GetComponent<SplitProjectile>();
            newSplitProjectile.collidedEnemies = collidedEnemies;
        }
    }

}
