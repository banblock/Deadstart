using System.Collections;
using UnityEngine;

public class Enemy : Unit
{
    public float speed;
    public float detectionRange;
    public float chasingRange; // 수정: 쫓아가는 범위
    public float attackRange;
    public float attackCooldown = 2f;
    public float attackDamage = 10f; 
    public Rigidbody2D target;
    
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

        if (distanceToTarget <= chasingRange) // 수정: 쫓아가는 범위 내에 있을 때만 추적
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

    void ChaseTarget()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    bool CanAttack()
    {
        if (isCooldown)
        {
            return false;
        }

        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        return distanceToTarget <= attackRange;
    }

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

    IEnumerator AttackCooldownCoroutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        isCooldown = false;
    }

    void StopMoving()
    {
        rigid.velocity = Vector2.zero;
    }
}
