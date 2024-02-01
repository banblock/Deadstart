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

    WeaponUpgradeData weaponUpgradeData;

    public void SetInitUI(WeaponUpgradeData weaponData)
    {
        weaponUpgradeData = weaponData;
        nameText.text = weaponData.name;
        image.sprite = weaponData.sprite;
        resourceContainer.SetInitUI(weaponData.requiredUpgrades);
    }

    public void OnUpgradeButtonClick()
    {
        WeaponManager.Instance.ChangeWeapon(weaponUpgradeData.name);
    }

}

