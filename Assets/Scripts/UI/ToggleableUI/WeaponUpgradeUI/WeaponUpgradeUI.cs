using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponUpgradeUI : ToggleableUI
{
    public static WeaponUpgradeUI Instance { get; private set; }

    [SerializeField]
    private GameObject SelectedWeaponUI; // 무기 종류 UI
    [SerializeField]
    WeaponUpgradeListUI[] weaponUpgradeListUI; // 업그레이드 리스트 UI 
    int weaponUpgradeIndex; // 선택된 무기 종류
    bool weaponSelected = false; 

    private WeaponManager weaponManager;

    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }

    void Start()
    {
        gameObject.SetActive(false);
        weaponManager = WeaponManager.Instance;
    }

    public override void OpenUI()
    {
        gameObject.SetActive(true);
        if (weaponSelected) {
            SelectWeaponType(weaponUpgradeIndex);
        }
    }

    public override void CloseUI()
    {
        gameObject.SetActive(false);
    }

    public void SelectWeaponType(int type)
    {
        weaponUpgradeIndex = type;
        weaponUpgradeListUI[weaponUpgradeIndex].gameObject.SetActive(true);
        SelectedWeaponUI.SetActive(false);
        UpdateUpgradeButton();
    }

    public void UpdateUpgradeButton()
    {
        weaponUpgradeListUI[weaponUpgradeIndex].UpdateWeaponUpgradeButton();
    }

    /// <summary>
    /// 무기 업그레이드 Callback 메서드
    /// </summary>
    /// <param name="id">업그레이드 된 무기 id</param>
    public void UpgradeWeapon(string id)
    {
        weaponManager.UpgradeWeapon(id);
        UpdateUpgradeButton();
    }

}
