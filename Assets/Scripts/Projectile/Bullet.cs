using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;  // 총알 이동 속도

    private ProjectilePoolManager projectilePoolManager;

    void Start()
    {
        projectilePoolManager = ProjectilePoolManager.Instance;
    }


    void FixedUpdate()
    {
        MoveBullet();
        DestroyBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        if (!IsInScreen()) {
            projectilePoolManager.ReturnProjectileToPool(this.gameObject);
        }
    }

    private bool IsInScreen()
    {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1);
    }

    public void RotateBulletTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 bulletPosition = transform.position;
        bulletPosition.z = 0f;

        Vector3 direction = mousePosition - bulletPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    
}
