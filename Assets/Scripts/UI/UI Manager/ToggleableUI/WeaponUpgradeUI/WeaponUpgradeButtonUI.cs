using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeButtonUI : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    TMP_Text nameText;

    [SerializeField]
    ResourceInfoUIContainer resourceContainer;
    
    public void SetInitUI(WeaponUpgradeData weaponData)
    {
        image.sprite = weaponData.sprite;
        nameText.text = weaponData.name;
        resourceContainer.SetInitUI(weaponData.requiredUpgrades);
    }
}

