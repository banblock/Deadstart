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
    /// 무기 변경
    /// </summary>
    /// <param name="upgradeName"> 무기 이름 </param>
    public void ChangeWeapon(string upgradeName)
    {
        WeaponUpgradeData upgradeInfo = GetWeaponData(upgradeName);

        if (upgradeInfo != null) {
            EquipWeapon(upgradeInfo.weaponPrefab);
        }
    }

    /// <summary>
    /// 무기 업그레이드 리스트에서 해당하는 번호의 무기 업그레이드 정보를 가져옵니다.
    /// </summary>
    /// <param name="upgradeName"> 무기 이름 </param>
    /// <returns> 무기 정보 </returns>
    public WeaponUpgradeData GetWeaponData(string upgradeName)
    {
        WeaponUpgradeData upgradeData = upgradeOptions.upgradeDatas.Find(info => info.upgradeName == upgradeName);

        if (upgradeData!= null) {
            return upgradeData;
        }
        else {
            Debug.LogError("해당 업그레이드 정보를 찾을 수 없습니다.");
            return null;
        }
    }

    /// <summary>
    /// 무기 장착
    /// </summary>
    /// <param name="weaponPrefab"> 장착할 무기 </param>
    private void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null) {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate(weaponPrefab, weaponPosition.position, weaponPosition.rotation, weaponPosition);
    }

    /// <summary>
    /// 무기 리스트를 가져옵니다.
    /// </summary>
    /// <returns> 무기 리스트 </returns>
    public List<WeaponUpgradeData> GetWeaponDataList()
    {
        return upgradeOptions.upgradeDatas;
    }

}