using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeUI : ToggleableUI
{
    public static WeaponUpgradeUI Instance { get; private set; }

    [SerializeField]
    private GameObject SelectedWeaponUI; // 무기 종류 UI
    [SerializeField]
    WeaponUpgradeListUI[] weaponUpgradeListUI; // 업그리에드 리스트
    int weaponUpgradeIndex;
    bool weaponSelected = false;

    // 밑에는 다 버려

    /*
    [SerializeField]
    private GameObject weaponUpgradeButtonPrefab;
    private List<GameObject> weaponUpgradeButtonList = new List<GameObject>();

    [SerializeField]
    private Transform weaponUpgradeButtonPos;
    */

    private WeaponManager weaponManager;
    private List<WeaponUpgradeData> weaponUpgradeDatas; //무기 업그레이드 정보를 가져옴

    private List<string> upgradeWeapons; // 업그레이드가 완료된 정보
                                         //매번 업그레이드 정보를 갱신하기 보다는 갱신하고 최소환으로 갱신하는 것이 베스트

    

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
        weaponUpgradeDatas = weaponManager.GetWeaponDataList();
    }

    public override void OpenUI()
    {
        gameObject.SetActive(true);
        //DisplayWeaponUpgradeList();
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
        weaponUpgradeListUI[type].gameObject.SetActive(true);
        weaponUpgradeIndex = type;
        SelectedWeaponUI.SetActive(false);
    }

    void UpdateUpgradeButton()
    {
        // 일단 시작 부분부터 활성화
        // 다음 업그레이드 탐색
        // 
        // 다음 업그레이드로 이동
        // 

    }

    /// <summary>
    /// 무기 업그래이드 정보를 출력합니다
    /// </summary>
    void DisplayWeaponUpgradeList()
    {
        if(weaponUpgradeDatas == null) {
            Debug.LogError("무기 리스트가 없습니다.");
            return;
        }
        /*
        foreach (WeaponUpgradeData upgradeData in weaponUpgradeDatas)
        {
            GameObject buttonUI = Instantiate(weaponUpgradeButtonPrefab, weaponUpgradeButtonPos);
            WeaponUpgradeButtonUI upgradeButtonUI = buttonUI.GetComponent<WeaponUpgradeButtonUI>();
            upgradeButtonUI.SetInitUI(upgradeData);
            weaponUpgradeButtonList.Add(buttonUI);
        }
        */
    }

}
