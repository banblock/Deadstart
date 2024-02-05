using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    Collider2D hitBox;

    float attackRange = 1.0f;


    protected override void PerformAttack()
    {
        
        // 공격 시행시 히트 박스 On

        // 공격하는 애니메이션 출력


    }

    /// <summary>
    /// 히트박스 활성화
    /// </summary>
    private void ActiveHitBox()
    {
        if (hitBox != null) {
            
        }
    }


    /// <summary>
    /// 히트박스 설정 - 임시
    /// </summary>
    /// <param name="size">크기</param>
    private void SetHitBoxSize(float size)
    {
        float colliderSize = size * 2f + 1f;
       
        CapsuleCollider2D capsuleCollider2D = hitBox.GetComponent<CapsuleCollider2D>();
        capsuleCollider2D.size = new Vector2(colliderSize, 0);
        hitBox.offset = new Vector2(size, 0);
    }
}
