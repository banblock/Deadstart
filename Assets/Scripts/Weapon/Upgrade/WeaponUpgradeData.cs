using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 무기 업그레이드 정보
/// </summary>
[System.Serializable]
public class WeaponUpgradeData 
{
    public string name;
    public GameObject weaponPrefab;
    public Sprite sprite;
    public List<Item> requiredUpgrades;
    public List<string> nextUpgrade;
    public List<string> previousUpgrade;
}
