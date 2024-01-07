using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoAttackWeapon : Weapon
{

    private void Update()
    {

    }

    // 공격 동작을 처리하는 가상 메서드를 오버라이드
    protected override void PerformAttack()
    {
        // 자동 공격 무기의 특화 동작 추가
        Debug.Log("Performing auto attack");
    }
}
