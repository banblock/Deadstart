using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoAttackWeapon : Weapon
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject bulletPrefab;  // ÃÑ¾Ë ÇÁ¸®ÆÕ

    [SerializeField]
    private Transform ShootStartPoint;

    [SerializeField]
    private EnemyScanner enemyScanner;

    private ProjectilePoolManager projectilePoolManager;

    void Start()
    {
        //enemyScanner = enemyScanner.GetComponent<EnemyScanner>();
        projectilePoolManager = ProjectilePoolManager.Instance;
    }

    void Update()
    {
        RotateWeaponTowardsTarget();
    }

    protected override void PerformAttack()
    {
        projectilePoolManager.GetProjectileFromPool(bulletPrefab, ShootStartPoint.position, transform.rotation);
    }

    void RotateWeaponTowardsTarget()
    {
        
        Vector3 targetPosision = enemyScanner.GetNearestTarget().position;
        targetPosision.z = 0f;

        Vector3 weaponPosition = transform.position;
        weaponPosition.z = 0f;

        Vector3 direction = targetPosision - weaponPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
