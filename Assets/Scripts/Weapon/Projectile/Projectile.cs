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
    [SerializeField]
    protected float projectileRange = 10f;  // 투사체의 최대 이동 거리

    [SerializeField]
    protected MovementType movementType = MovementType.Linear;

    private float initialDistance;      // 초기에서 현재 위치까지의 거리

    void Start()
    {
        projectilePoolManager = ProjectilePoolManager.Instance;
    }

    void OnEnable()
    {
        initialDistance = 0f;
    }

    void FixedUpdate()
    {
        MoveBullet();
    }

    protected virtual void MoveBullet()
    {
        switch (movementType) {
            case MovementType.Linear:
                LinearMove();
                break;
            case MovementType.EaseIn:
                EaseInMove();
                break;
            case MovementType.EaseOut:
                EaseOutMove();
                break;
        }
        initialDistance += projectileSpeed * Time.deltaTime;

        if (initialDistance >= projectileRange || !IsInScreen()) {
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌!");
        if(other.tag == "Enemy") {
            // 적과 충돌했을 때 수행할 동작을 작성
            //enemy.TakeDamage(projectileDamage);

            // 투사체 제거
            DestroyBullet();
        }
    }


    protected virtual void LinearMove()
    {
        transform.Translate(projectileSpeed * Time.deltaTime * Vector2.right);
    }

    protected virtual void EaseInMove()
    {
        float moveEaseSpeed = projectileSpeed * Mathf.SmoothStep(0f, 1f, Mathf.PingPong(initialDistance / projectileRange, 1f));
        transform.Translate(moveEaseSpeed * Time.deltaTime * Vector2.right);
    }

    protected virtual void EaseOutMove()
    {
        float moveEaseSpeed = projectileSpeed * Mathf.SmoothStep(1f, 0f, Mathf.PingPong(initialDistance / projectileRange, 1f));
        transform.Translate(moveEaseSpeed * Time.deltaTime * Vector2.right);
    }

    protected virtual void DestroyBullet()
    {
        // 투사체가 파괴될때 호출
        projectilePoolManager.ReturnProjectileToPool(gameObject);
    }

    protected bool IsInScreen()
    {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        float margin = 0.1f;

        return (viewportPosition.x >= -margin && viewportPosition.x <= 1 + margin &&
                viewportPosition.y >= -margin && viewportPosition.y <= 1 + margin);
    }

    protected enum MovementType
    {
        Linear,
        EaseIn,
        EaseOut,
    }
}
