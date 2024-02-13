using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���� ���׷��̵� ����
/// </summary>
[System.Serializable]
public class WeaponUpgradeData 
{
    public string name;
    public GameObject weaponPrefab;
    public Sprite sprite;
    public List<Item> requiredUpgrades;
    public UpgradeStpeData nextUpgrade;
    public UpgradeStpeData previousUpgrade;

}

[System.Serializable]
public class UpgradeStpeData
{
    public enum SelectType
    {
        OR,
        AND
    }
    public List<string> upgradeId;
    public SelectType selectType;
}

