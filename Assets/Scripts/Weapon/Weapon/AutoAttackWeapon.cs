using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoAttackWeapon : Weapon
{

    private void Update()
    {

    }

    // ���� ������ ó���ϴ� ���� �޼��带 �������̵�
    protected override void PerformAttack()
    {
        // �ڵ� ���� ������ Ưȭ ���� �߰�
        Debug.Log("Performing auto attack");
    }
}
