using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponUpgradeData 
{
    public string upgradeName;
    public GameObject weaponPrefab;
    public List<Resource> requiredUpgrades;
    public List<string> nextUpgrade;
}
