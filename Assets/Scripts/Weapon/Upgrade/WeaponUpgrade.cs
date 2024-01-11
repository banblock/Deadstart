using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeOption
{
    public string upgradeName;
    public GameObject upgradePrefab;
    public List<Resource> requiredUpgrades;
    public List<string> nextUpgrade;
}

public class WeaponUpgrade : MonoBehaviour
{
    [SerializeField]
    List<UpgradeOption> upgradeOptions;

    public UpgradeOption GetUpgradeOption(string upgradeName)
    {
        foreach (UpgradeOption option in upgradeOptions) {
            if (option.upgradeName == upgradeName) {
                return option;
            }
        }
        return null;
    }
}
