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
        
        // ���� ����� ��Ʈ �ڽ� On

        // �����ϴ� �ִϸ��̼� ���


    }

    /// <summary>
    /// ��Ʈ�ڽ� Ȱ��ȭ
    /// </summary>
    private void ActiveHitBox()
    {
        if (hitBox != null) {
            
        }
    }


    /// <summary>
    /// ��Ʈ�ڽ� ���� - �ӽ�
    /// </summary>
    /// <param name="size">ũ��</param>
    private void SetHitBoxSize(float size)
    {
        float colliderSize = size * 2f + 1f;
       
        CapsuleCollider2D capsuleCollider2D = hitBox.GetComponent<CapsuleCollider2D>();
        capsuleCollider2D.size = new Vector2(colliderSize, 0);
        hitBox.offset = new Vector2(size, 0);
    }
}
