using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무기 장착 및 업그레이드 관리
/// </summary>
public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { private set; get; }

    public GameObject initialWeaponPrefab; //기본무기
    private GameObject currentWeapon; //현재무기

    [SerializeField]
    Transform weaponPosition; //무기 장착 위치

    [SerializeField]
    WeaponUpgradeList upgradeOptions; //업그레이드 가능 옵션

    //현제 업그레이드된 무기 정보 저장
    List<string> weaponUpgrade = new List<string>();

    WeaponUpgrageManager WeaponUpgrageManager;

    Dictionary<string, WeaponData> weaponUpgradeStatus = new Dictionary<string, WeaponData>();


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
            //무기 장착 위치를 플레이어로 설정
            weaponPosition = PlayerController.Instance.transform;
        }
        //기본무기 장착
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

    public void UpgradeWeapon()
    {
        
    }


    /// <summary>
    /// 무기 변경를 변경합니다
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
    /// 무기 업그레이드 리스트에서 해당하는 번호의 무기 업그레이드 정보를 가져옵니다
    /// </summary>
    /// <param name="upgradeName"> 무기 이름 </param>
    /// <returns> 무기 정보 </returns>
    public WeaponUpgradeData GetWeaponData(string upgradeName)
    {
        WeaponUpgradeData upgradeData = upgradeOptions.upgradeDatas.Find(info => info.name == upgradeName);

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
        Weapon weaponComponent = currentWeapon.GetComponent<Weapon>();
        ActionMode actionMode = ActionManager.Instance.ActionMode;
        weaponComponent.SetAttackEnabled(actionMode);
    }

    /// <summary>
    /// 무기 리스트를 가져옵니다
    /// </summary>
    /// <returns> 무기 리스트 </returns>
    public List<WeaponUpgradeData> GetWeaponDataList()
    {
        return upgradeOptions.upgradeDatas;
    }

}

public class WeaponUpgrageManager
{
    // 이미 업그레이드 된 정보들...
    WeaponUpgradeList upgradeOptions;
    // 전체 업그레이드 정보
    Dictionary<string, WeaponUpgradeData> upgradeDictionary;

    public WeaponUpgradeData GetUpgradeData(string id)
    {
        return upgradeDictionary[id];
    }



}