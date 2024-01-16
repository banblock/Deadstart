using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;

    private float nextTimeToFire = 0f;
    private bool isAttack = true;

    void Start()
    {
        InitSetting();
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (isAttack && Time.time >= nextTimeToFire) {
            PerformAttack();
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    protected virtual void InitSetting()
    {
        ActionManager.instance.OnActionModeChanged += SetAttackEnabled;
    }

    protected virtual void PerformAttack()
    {
        Debug.Log("Performing generic attack");
    }

    public void SetAttackEnabled(ActionMode action)
    {
        isAttack = (action == ActionMode.AttackMode);
    }

    void OnDestroy()
    {
        ActionManager.instance.OnActionModeChanged -= SetAttackEnabled;
    }
}
