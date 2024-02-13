using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public float speed;
    public float detectionRange;
    public float attackRange;
    public float attackCooldown = 2f;
    public float attackDamage = 10f; // 에너미의 공격력
    public Rigidbody2D target; // 공격 대상

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    bool isCooldown = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (target == null)
        {
            // 특정 대상이 설정되어 있지 않은 경우, 기본적으로 플레이어를 대상으로 설정
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (IsTargetInRange())
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

    bool IsTargetInRange()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        return distanceToTarget <= detectionRange;
    }

    void ChaseTarget()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void StopMoving()
    {
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

   
    public override void TakeDamage(float damage)
    {
        Debug.Log("데미지를 받았습니다! :" + damage);
        base.TakeDamage(damage);
        // todo: Enemy가 데미지를 받을떄 실행 로직
    }

    protected override void Die()
    {
        base.Die();
    }


}
