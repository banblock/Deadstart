using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������
/// </summary>
public class WeaponData 
{
    public string upgradeName;
    public GameObject weaponPrefab;
    public List<Item> requiredUpgrades;
    public List<string> nextUpgrade;
}
