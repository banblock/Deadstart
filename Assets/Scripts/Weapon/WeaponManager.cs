using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { private set; get; }

    public GameObject initialWeaponPrefab;
    private GameObject currentWeapon;

    [SerializeField]
    Transform weaponPosition;

    [SerializeField]
    WeaponUpgradeList upgradeOptions;

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
        if(weaponPosition == null ) {

            weaponPosition = PlayerController.Instance.transform;
        }

        EquipWeapon(initialWeaponPrefab);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ChangeWeapon("01-01");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            ChangeWeapon("01-02");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            ChangeWeapon("01-03-1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            ChangeWeapon("01-03-2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            ChangeWeapon("01-03-3");
        }
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    /// <param name="upgradeName"> ���� �̸� </param>
    public void ChangeWeapon(string upgradeName)
    {
        WeaponUpgradeData upgradeInfo = GetWeaponData(upgradeName);

        if (upgradeInfo != null) {
            EquipWeapon(upgradeInfo.weaponPrefab);
        }
    }

    /// <summary>
    /// ���� ���׷��̵� ����Ʈ���� �ش��ϴ� ��ȣ�� ���� ���׷��̵� ������ �����ɴϴ�.
    /// </summary>
    /// <param name="upgradeName"> ���� �̸� </param>
    /// <returns> ���� ���� </returns>
    public WeaponUpgradeData GetWeaponData(string upgradeName)
    {
        WeaponUpgradeData upgradeData = upgradeOptions.upgradeDatas.Find(info => info.upgradeName == upgradeName);

        if (upgradeData!= null) {
            return upgradeData;
        }
        else {
            Debug.LogError("�ش� ���׷��̵� ������ ã�� �� �����ϴ�.");
            return null;
        }
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    /// <param name="weaponPrefab"> ������ ���� </param>
    private void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null) {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate(weaponPrefab, weaponPosition.position, weaponPosition.rotation, weaponPosition);
    }

    /// <summary>
    /// ���� ����Ʈ�� �����ɴϴ�.
    /// </summary>
    /// <returns> ���� ����Ʈ </returns>
    public List<WeaponUpgradeData> GetWeaponDataList()
    {
        return upgradeOptions.upgradeDatas;
    }

}