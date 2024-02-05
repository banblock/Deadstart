using System;
using System.Collections;
using UnityEngine;

public class Enemy : Unit
{
    public float speed; //이동속도
    public float detectionRange; //플레이어를 발견하는 범위
    public float chasingRange; // 수정: 쫓아가는 범위
    public float attackRange; // 공격 사거리
    public float attackCooldown = 2f; //공격 쿨다운
    public float attackDamage = 10f;  //데미지
    public Rigidbody2D target; // 에네미의 공격대상
    
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    bool isCooldown = false;
    bool isChasing = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= chasingRange) //  쫓아가는 범위 내에 있을 때만 추적
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChaseTarget();
            if (CanAttack())
            {
                AttackTarget();
            }
        }
        else
        {
            StopMoving();
        }
    }

/// <summary>
/// target을 따라가는 메소드
/// </summary>
    void ChaseTarget()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

/// <summary>
/// 대상을 공격가능한지 확인하는 메소드
/// </summary>
/// <returns> boolean </returns>
    bool CanAttack()
    {
        if (isCooldown)
        {
            return false;
        }

        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        return distanceToTarget <= attackRange;
    }

/// <summary>
/// 대상을 공격, 미완성
/// </summary>
    void AttackTarget()
    {
        // 대상에게 데미지를 입히기
        /*Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(attackDamage);
        }*/

        // 공격 후 쿨다운 시작
        StartCoroutine(AttackCooldownCoroutine());
    }

/// <summary>
/// 공격 쿨다운을 잰다 attacktarget에 사용
/// </summary>
/// <returns>IEnumerator</returns>
    IEnumerator AttackCooldownCoroutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        isCooldown = false;
    }

/// <summary>
/// target이 chaserange밖으로 이동했을경우 멈추기 위한 메소드
/// </summary>
    void StopMoving()
    {
        rigid.velocity = Vector2.zero;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

/// <summary>
/// collider가 부딪히면 수행
/// </summary>
/// <param name="other"></param>
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            // "Projectile" 태그를 가진 오브젝트에 대해서만 처리
            TakeDamage(other.GetComponent<Bullet>().damage);
            Destroy(other.gameObject); // 총알 제거
        }
    }

/// <summary>
/// 적 사망 시 처리할 내용을 여기에 추가
/// </summary>
     protected virtual void Die()
    {
        
        Destroy(gameObject);
    }
}