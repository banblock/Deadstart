using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeUI : ToggleableUI
{
    public static WeaponUpgradeUI Instance { get; private set; }

    [SerializeField]
    private GameObject weaponUpgradeButtonPrefab;
    private List<GameObject> weaponUpgradeButtonList = new List<GameObject>();

    [SerializeField]
    private Transform weaponUpgradeButtonPos;

    private WeaponManager weaponManager;
    
    private List<WeaponUpgradeData> weaponUpgradeDatas;

    private void Awake()
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
        weaponUpgradeDatas = weaponManager.GetWeaponDataList();
    }

    public override void OpenUI()
    {
        gameObject.SetActive(true);
        DisplayWeaponUpgradeList();
    }

    public override void CloseUI()
    {
        gameObject.SetActive(false);
    }

    void DisplayWeaponUpgradeList()
    {
        if(weaponUpgradeDatas == null) {
            Debug.LogError("무기 리스트가 없습니다.");
            return;
        }
        Debug.Log(weaponUpgradeDatas + "/" + weaponUpgradeDatas.Count);
        foreach (WeaponUpgradeData upgradeData in weaponUpgradeDatas)
        {
            GameObject buttonUI = Instantiate(weaponUpgradeButtonPrefab, weaponUpgradeButtonPos);
            WeaponUpgradeButtonUI upgradeButtonUI = buttonUI.GetComponent<WeaponUpgradeButtonUI>();
            upgradeButtonUI.SetInitUI(upgradeData);
            weaponUpgradeButtonList.Add(buttonUI);
            
        }
    }

}
