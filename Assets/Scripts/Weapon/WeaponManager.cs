using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject initialWeaponPrefab;
    private GameObject currentWeapon;

    public WeaponUpgradeList upgradeOptions; 

    void Start()
    {
        SpawnWeapon(initialWeaponPrefab);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            UpgradeWeapon("01-01");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            UpgradeWeapon("01-02");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            UpgradeWeapon("01-03-1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            UpgradeWeapon("01-03-2");
        }
    }

    void SpawnWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null) {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate(weaponPrefab, transform.position, transform.rotation, transform);
    }

    void UpgradeWeapon(string upgradeName)
    {
        WeaponUpgradeData upgradeInfo = upgradeOptions.upgradeDatas.Find(info => info.upgradeName == upgradeName);

        if (upgradeInfo != null) {
            SpawnWeapon(upgradeInfo.weaponPrefab);
        }
        else {
            Debug.LogError("해당 업그레이드 정보를 찾을 수 없습니다.");
        }
    }
}