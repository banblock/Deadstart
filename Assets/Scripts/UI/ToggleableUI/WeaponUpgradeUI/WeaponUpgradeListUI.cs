using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WeaponUpgradeListUI : MonoBehaviour
{
    private List<GameObject> weaponUpgradeObjects = new List<GameObject>();

    private WeaponManager weaponManager;
    private List<WeaponUpgradeData> weaponUpgradeDatas; //무기 업그레이드 정보를 가져옴

    void Start()
    {
        weaponManager = WeaponManager.Instance;
        weaponUpgradeDatas = weaponManager.GetWeaponDataList();
        CollectWeaponUpgradeObjects();
    }

    void CollectWeaponUpgradeObjects()
    {
        ScrollRect scrollRect = GetComponent<ScrollRect>();
        RectTransform content = scrollRect.content;
        Transform[] children = content.transform.GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children) {
            WeaponUpgradeButtonUI weaponUpgradeButton = child.GetComponent<WeaponUpgradeButtonUI>();
            if (weaponUpgradeButton != null) {
                WeaponUpgradeData foundUpgradeData = weaponUpgradeDatas.Find(data => data.name == weaponUpgradeButton.WeaponId);
                
                if(foundUpgradeData == null) continue;
                
                weaponUpgradeButton.SetInitUI(foundUpgradeData);
                weaponUpgradeObjects.Add(child.gameObject);
            }
        }

        Debug.Log("Collected " + weaponUpgradeObjects.Count + " objects with WeaponUpgradeButtonUI script.");
    }
}
