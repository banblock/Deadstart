using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject bulletPrefab;  // �Ѿ� ������
    
    [SerializeField]
    private Transform ShootStartPoint;

    public float fireRate = 0.1f;     // �� �߻� ����
    private bool isShooting = false;

    private ProjectilePoolManager projectilePoolManager;

    void Start()
    {
        projectilePoolManager = ProjectilePoolManager.Instance;
    }


    void Update()
    {
        RotateWeaponTowardsMouse();

        // ���콺�� ������ �����鼭 �Ѿ� �߻�
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

            // ���ݸ��� ���
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
