using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 투사체 오브젝트
/// </summary>
public class Projectile : MonoBehaviour
{
    protected ProjectilePoolManager projectilePoolManager;

    [SerializeField]
    protected float projectileSpeed = 10f;  // 투사체 속도
    [SerializeField]
    protected float projectileDamage = 1f;  // 투사체 데미지
    [SerializeField]
    protected float projectileRange = 10f;  // 투사체 범위
    private float initialDistance;      // 투사체 발사된 거리
    [SerializeField]
    protected int projectilePenetration = 0; //투사체 관통력
    private int currentProjectilePenetration;
    [SerializeField]
    protected MovementType movementType = MovementType.Linear; // 발체체 이동 형태

    void Start()
    {
        projectilePoolManager = ProjectilePoolManager.Instance;
    }

    void OnEnable()
    {
        SetInit();
    }

    void FixedUpdate()
    {
        MoveBullet();
    }


    /// <summary>
    /// 초기 세팅
    /// </summary>
    protected virtual void SetInit()
    {
        initialDistance = 0f;
        currentProjectilePenetration = projectilePenetration;
    }

    /// <summary>
    /// 투사체 이동
    /// </summary>
    protected virtual void MoveBullet()
    {
        //투사체 이동 타입 결정
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

    /// <summary>
    /// 투사체 충돌
    /// </summary>
    /// <param name="other">충돌한 오브젝트</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag) {
            case "Enemy":
                HitEnemy(other);
                break;
            case "Building":
                HitBuilding(other);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 적과 충돌했을 때 동작
    /// </summary>
    /// <param name="enemy"> 충돌한 적 </param>
    protected virtual void HitEnemy(Collider2D enemy)
    {
        //enemy.TakeDamage(projectileDamage);
        currentProjectilePenetration--;
        if (currentProjectilePenetration < 0) {
            DestroyBullet();
        }
    }

    /// <summary>
    /// 건물과 충돌
    /// </summary>
    /// <param name="enemy"> 충돌한 건물 </param>
    protected virtual void HitBuilding(Collider2D enemy)
    {
        DestroyBullet();
    }

    /// <summary>
    /// 투사체 삭제 : pool 반환
    /// </summary>
    protected virtual void DestroyBullet()
    {
        projectilePoolManager.ReturnProjectileToPool(gameObject);
    }
    

    /// <summary>
    /// 투사체 선형이동
    /// </summary>
    private void LinearMove()
    {
        transform.Translate(projectileSpeed * Time.deltaTime * Vector2.right);
    }

    /// <summary>
    /// 투사체 EaseIn이동
    /// </summary>
    private void EaseInMove()
    {
        float moveEaseSpeed = projectileSpeed * Mathf.SmoothStep(0f, 1f, Mathf.PingPong(initialDistance / projectileRange, 1f));
        transform.Translate(moveEaseSpeed * Time.deltaTime * Vector2.right);
    }

    /// <summary>
    /// 투사체 EaseOut이동
    /// </summary>
    private void EaseOutMove()
    {
        float moveEaseSpeed = projectileSpeed * Mathf.SmoothStep(1f, 0f, Mathf.PingPong(initialDistance / projectileRange, 1f));
        transform.Translate(moveEaseSpeed * Time.deltaTime * Vector2.right);
    }

    /// <summary>
    /// 투사체가 스크린 밖으로 나갔는지 판별합니다
    /// </summary>
    /// <returns> true = 스크린 밖으로 나감 </returns>
    private bool IsInScreen()
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
