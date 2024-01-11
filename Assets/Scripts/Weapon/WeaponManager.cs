using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponUpgradeInfo
{
    public string upgradeName;
    public GameObject weaponPrefab; // ���׷��̵� �� ��ü�� ���� ������
    public List<Resource> requiredUpgrades;
    public List<string> nextUpgrade;
}

public class WeaponManager : MonoBehaviour
{
    public GameObject initialWeaponPrefab;
    private GameObject currentWeapon;

    public WeaponUpgradeInfo[] upgradeOptions; 

    void Start()
    {
        SpawnWeapon(initialWeaponPrefab);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            UpgradeWeapon("up01");
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
        WeaponUpgradeInfo upgradeInfo = System.Array.Find(upgradeOptions, info => info.upgradeName == upgradeName);

        if (upgradeInfo != null) {
            SpawnWeapon(upgradeInfo.weaponPrefab);
        }
        else {
            Debug.LogError("�ش� ���׷��̵� ������ ã�� �� �����ϴ�.");
        }
    }
}