using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���� ���׷��̵� ��ư
/// </summary>
public class WeaponUpgradeButtonUI : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    TMP_Text nameText;

    [SerializeField]
    ResourceInfoUIContainer resourceContainer;

    WeaponUpgradeData weaponUpgradeData;

    /// <summary>
    /// ���� ���׷��̵� ��ư�� �����մϴ�
    /// </summary>
    /// <param name="weaponData">���� ���׷��̵� ����</param>
    public void SetInitUI(WeaponUpgradeData weaponData)
    {
        weaponUpgradeData = weaponData;
        nameText.text = weaponData.name;
        image.sprite = weaponData.sprite;
        resourceContainer.SetInitUI(weaponData.requiredUpgrades);
    }

    /// <summary>
    /// ���繫��� �����մϴ�
    /// </summary>
    public void OnUpgradeButtonClick()
    {
        WeaponManager.Instance.ChangeWeapon(weaponUpgradeData.name);
    }

}

