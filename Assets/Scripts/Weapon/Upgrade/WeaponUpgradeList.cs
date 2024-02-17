using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponUpgradeList", menuName = "ScriptableObjects/WeaponUpgradeList", order = 1)]
public class WeaponUpgradeList : ScriptableObject
{
    public List<WeaponUpgradeData> upgradeDatas;
    
}

