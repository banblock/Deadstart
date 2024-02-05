using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 무기 업그레이드 버튼
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
    /// 무기 업그레이드 버튼을 갱신합니다
    /// </summary>
    /// <param name="weaponData">무기 업그레이드 정보</param>
    public void SetInitUI(WeaponUpgradeData weaponData)
    {
        weaponUpgradeData = weaponData;
        nameText.text = weaponData.name;
        image.sprite = weaponData.sprite;
        resourceContainer.SetInitUI(weaponData.requiredUpgrades);
    }

    /// <summary>
    /// 현재무기로 변경합니다
    /// </summary>
    public void OnUpgradeButtonClick()
    {
        WeaponManager.Instance.ChangeWeapon(weaponUpgradeData.name);
    }

}

