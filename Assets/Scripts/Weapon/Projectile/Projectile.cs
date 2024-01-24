using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    protected ProjectilePoolManager projectilePoolManager;

    [SerializeField]
    protected float projectileSpeed = 10f;  // �Ѿ� �̵� �ӵ�
    [SerializeField]
    protected float projectileDamage = 1f;
    [SerializeField]
    protected float projectileRange = 10f;  // ����ü�� �ִ� �̵� �Ÿ�

    [SerializeField]
    protected MovementType movementType = MovementType.Linear;

    private float initialDistance;      // �ʱ⿡�� ���� ��ġ������ �Ÿ�

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
        Debug.Log("�浹!");
        if(other.tag == "Enemy") {
            // ���� �浹���� �� ������ ������ �ۼ�
            //enemy.TakeDamage(projectileDamage);

            // ����ü ����
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
        // ����ü�� �ı��ɶ� ȣ��
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
