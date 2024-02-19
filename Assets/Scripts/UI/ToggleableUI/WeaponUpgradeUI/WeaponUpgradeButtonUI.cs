using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UpgradeStatus
{
    NotAvailable, // 업그레이드 불가
    Available,    // 업그레이드 가능
    Completed     // 업그레이드 완료
}


/// <summary>
/// 무기 업그레이드 버튼
/// </summary>
public class WeaponUpgradeButtonUI : MonoBehaviour
{
    [SerializeField, HideInInspector]
    Image image;

    [SerializeField, HideInInspector]
    TMP_Text nameText;

    [SerializeField, HideInInspector]
    ResourceInfoUIContainer resourceContainer;

    [SerializeField, HideInInspector]
    GameObject disabledUpgradeUI;
    
    UpgradeStatus upgradeStatus = UpgradeStatus.NotAvailable;

    WeaponUpgradeData weaponUpgradeData;

    [SerializeField]
    public string WeaponId;

    void Start()
    {
        
    }


    /// <summary>
    /// 현재 무기 업그레이드 상태를 지정합니다.
    /// </summary>
    /// <param name="upgradeStatus"> 업그레이드 상태 </param>
    public void SetUpgradeStatus(UpgradeStatus upgradeStatus)
    {
        this.upgradeStatus = upgradeStatus;
        // todo : 엑티브 상태를 결정합니다.
        switch (upgradeStatus) {
            case UpgradeStatus.NotAvailable:
                disabledUpgradeUI.SetActive(true);
                break;
            case UpgradeStatus.Available:
                disabledUpgradeUI.SetActive(false);
                break;
            case UpgradeStatus.Completed:
                disabledUpgradeUI.SetActive(false);
                break;
            default: break;
        }
    }


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

