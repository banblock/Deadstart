using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ü ������Ʈ
/// </summary>
public class Projectile : MonoBehaviour
{
    protected ProjectilePoolManager projectilePoolManager;

    [SerializeField]
    protected float projectileSpeed = 10f;  // ����ü �ӵ�
    [SerializeField]
    protected float projectileDamage = 1f;  // ����ü ������
    [SerializeField]
    protected float projectileRange = 10f;  // ����ü ����
    private float initialDistance;      // ����ü �߻�� �Ÿ�
    [SerializeField]
    protected int projectilePenetration = 0; //����ü �����
    private int currentProjectilePenetration;
    [SerializeField]
    protected MovementType movementType = MovementType.Linear; // ��üü �̵� ����

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
    /// �ʱ� ����
    /// </summary>
    protected virtual void SetInit()
    {
        initialDistance = 0f;
        currentProjectilePenetration = projectilePenetration;
    }

    /// <summary>
    /// ����ü �̵�
    /// </summary>
    protected virtual void MoveBullet()
    {
        //����ü �̵� Ÿ�� ����
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
    /// ����ü �浹
    /// </summary>
    /// <param name="other">�浹�� ������Ʈ</param>
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
    /// ���� �浹���� �� ����
    /// </summary>
    /// <param name="enemy"> �浹�� �� </param>
    protected virtual void HitEnemy(Collider2D enemy)
    {
        //enemy.TakeDamage(projectileDamage);
        currentProjectilePenetration--;
        if (currentProjectilePenetration < 0) {
            DestroyBullet();
        }
    }

    /// <summary>
    /// �ǹ��� �浹
    /// </summary>
    /// <param name="enemy"> �浹�� �ǹ� </param>
    protected virtual void HitBuilding(Collider2D enemy)
    {
        DestroyBullet();
    }

    /// <summary>
    /// ����ü ���� : pool ��ȯ
    /// </summary>
    protected virtual void DestroyBullet()
    {
        projectilePoolManager.ReturnProjectileToPool(gameObject);
    }
    

    /// <summary>
    /// ����ü �����̵�
    /// </summary>
    private void LinearMove()
    {
        transform.Translate(projectileSpeed * Time.deltaTime * Vector2.right);
    }

    /// <summary>
    /// ����ü EaseIn�̵�
    /// </summary>
    private void EaseInMove()
    {
        float moveEaseSpeed = projectileSpeed * Mathf.SmoothStep(0f, 1f, Mathf.PingPong(initialDistance / projectileRange, 1f));
        transform.Translate(moveEaseSpeed * Time.deltaTime * Vector2.right);
    }

    /// <summary>
    /// ����ü EaseOut�̵�
    /// </summary>
    private void EaseOutMove()
    {
        float moveEaseSpeed = projectileSpeed * Mathf.SmoothStep(1f, 0f, Mathf.PingPong(initialDistance / projectileRange, 1f));
        transform.Translate(moveEaseSpeed * Time.deltaTime * Vector2.right);
    }

    /// <summary>
    /// ����ü�� ��ũ�� ������ �������� �Ǻ��մϴ�
    /// </summary>
    /// <returns> true = ��ũ�� ������ ���� </returns>
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
