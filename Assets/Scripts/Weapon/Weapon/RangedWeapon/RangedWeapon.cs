using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField]
    protected SpriteRenderer spriteRenderer;

    [SerializeField]
    protected GameObject bulletPrefab;  // �Ѿ� ������

    [SerializeField]
    protected Transform ShootStartPoint;

    protected ProjectilePoolManager projectilePoolManager;

    void Update()
    {
        base.Attack();
        RotateWeaponTowardsTarget();
    }

    protected override void PerformAttack()
    {
        if (Input.GetMouseButton(0)) {
            projectilePoolManager.GetProjectileFromPool(bulletPrefab, ShootStartPoint.position, transform.rotation);
        }
    }

    protected override void InitSetting()
    {
        base.InitSetting();
        projectilePoolManager = ProjectilePoolManager.Instance;
    }

    
    void RotateWeaponTowardsTarget()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 weaponPosition = transform.position;
        weaponPosition.z = 0f;

        Vector3 direction = mousePosition - weaponPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (direction.x < 0f) {
            spriteRenderer.flipY = true;
        }
        else {
            spriteRenderer.flipY = false;
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
