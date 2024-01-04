using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject bulletPrefab;  // 총알 프리팹
    
    [SerializeField]
    private Transform ShootStartPoint;

    public float fireRate = 0.1f;     // 총 발사 간격
    private bool isShooting = false;

    private ProjectilePoolManager projectilePoolManager;

    void Start()
    {
        projectilePoolManager = ProjectilePoolManager.Instance;
    }


    void Update()
    {
        RotateWeaponTowardsMouse();

        // 마우스를 누르고 있으면서 총알 발사
        if (Input.GetMouseButtonDown(0)) {
            isShooting = true;
            StartCoroutine(ShootBulletCoroutine());
        }
        else if (Input.GetMouseButtonUp(0)) {
            isShooting = false;
        }
    }

    IEnumerator ShootBulletCoroutine()
    {
        while (isShooting) {
            ShootBullet();

            // 간격마다 대기
            float elapsed = 0f;
            while (elapsed < fireRate) {
                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }

    void RotateWeaponTowardsMouse()
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


    void ShootBullet()
    {
        projectilePoolManager.GetProjectileFromPool(bulletPrefab, ShootStartPoint.position, transform.rotation);
    }
}
