using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponUpgradeData 
{
    public string upgradeName;
    public GameObject weaponPrefab;
    public List<Item> requiredUpgrades;
    public List<string> nextUpgrade;
}
