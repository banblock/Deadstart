using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    protected int bulletCount = 4;
    [SerializeField]
    protected float spread = 10f;


    protected override void PerformAttack()
    {
        if (Input.GetMouseButton(0)) {
            for (int i = 0; i < bulletCount; i++) {
                float angle = Mathf.Lerp(-spread, spread, (float)i / (bulletCount - 1));
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + angle);

                projectilePoolManager.GetProjectileFromPool(bulletPrefab, ShootStartPoint.position, bulletRotation);
            }
        }
    }

}
