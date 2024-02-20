using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WeaponUpgradeListUI : MonoBehaviour
{
    private List<WeaponUpgradeButtonUI> weaponUpgradeObjects = new List<WeaponUpgradeButtonUI>();

    void Start()
    {
        CollectWeaponUpgradeObjects();
        UpdateWeaponUpgradeButton();
    }

    void CollectWeaponUpgradeObjects()
    {
        ScrollRect scrollRect = GetComponent<ScrollRect>();
        Transform targetObj = scrollRect.content.transform;

        // targetObj의 자식 오브젝트를 순회하며 WeaponUpgradeButtonUI 컴포넌트를 포함한 오브젝트를 찾음
        foreach (Transform child in targetObj) {
            if (child.TryGetComponent<WeaponUpgradeButtonUI>(out var weaponUpgradeButtonUI)) {
                weaponUpgradeObjects.Add(weaponUpgradeButtonUI);
            }
        }

        Debug.Log("Collected " + weaponUpgradeObjects.Count + " objects with WeaponUpgradeButtonUI script.");
    }

    public void UpdateWeaponUpgradeButton()
    {
        Dictionary<string, WeaponUpgradeData> weaponUpgradeList = WeaponManager.Instance.GetWeaponDatas(); // 무기 업그레이드 정보
        Dictionary<string, UpgradeStatus> weaponUpgradeStatus = WeaponManager.Instance.GetWeaponUpgradeStatus(); //무기 업그레이드 상태

        foreach (WeaponUpgradeButtonUI uiButton in weaponUpgradeObjects)
        {    
            string weaponId = uiButton.WeaponId;
            WeaponUpgradeData weaponUpgradeData = weaponUpgradeList[weaponId];
            UpgradeStatus upgradeStatus = weaponUpgradeStatus[weaponId];

            uiButton.SetInitUI(weaponUpgradeData);
            uiButton.SetUpgradeStatus(upgradeStatus);
        }
    }
}
