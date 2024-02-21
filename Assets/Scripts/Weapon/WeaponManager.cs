using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 업그레이드 상태
/// </summary>
public enum UpgradeStatus
{
    NotAvailable, // 업그레이드 불가
    Available,    // 업그레이드 가능
    Completed     // 업그레이드 완료
}

/// <summary>
/// 무기 장착 및 업그레이드 관리
/// </summary>
public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { private set; get; }

    

    [HideInInspector]
    public GameObject initialWeaponPrefab; //기본무기

    [SerializeField, HideInInspector]
    private GameObject currentWeapon; //현재무기


    [SerializeField, HideInInspector]
    Transform weaponPosition; //무기 장착 위치

    [SerializeField]
    WeaponUpgradeList upgradeOptions; //업그레이드 옵션

    [SerializeField]
    string initialWeaponId;

    // 무기 업그레이드 정보
    Dictionary<string, WeaponUpgradeData> weaponUpgradeList = new Dictionary<string, WeaponUpgradeData>();
    
    //무기 업그레이드 상태
    Dictionary<string, UpgradeStatus> weaponUpgradeStatus = new Dictionary<string, UpgradeStatus>();

    private void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }
        initSetUpgradeStatus();
    }

    void Start()
    {
        if(weaponPosition == null ) {
            //무기 장착 위치를 플레이어로 설정
            weaponPosition = PlayerController.Instance.transform;
        }
        //기본무기 장착
        ChangeWeapon(initialWeaponId);
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
    /// 초기 업그레이드 정보를 설정합니다.
    /// </summary>
    void initSetUpgradeStatus()
    {
        foreach (var upgradeData in upgradeOptions.upgradeDatas) {
            weaponUpgradeList.Add(upgradeData.name, upgradeData);
            weaponUpgradeStatus.Add(upgradeData.name, UpgradeStatus.NotAvailable);
        }
        weaponUpgradeStatus[initialWeaponId] = UpgradeStatus.Available;
    }

    /// <summary>
    /// 무기 변경를 변경합니다
    /// </summary>
    /// <param name="upgradeId"> 무기 이름 </param>
    public void ChangeWeapon(string upgradeId)
    {
        WeaponUpgradeData upgradeInfo = GetWeaponData(upgradeId);

        if (upgradeInfo != null) {
            EquipWeapon(upgradeInfo.weaponPrefab);
        }
    }

    /// <summary>
    /// 무기를 업그레이드 합니다.
    /// </summary>
    /// <param name="upgradeId"></param>
    public void UpgradeWeapon(string upgradeId)
    {
        WeaponUpgradeData weaponUpgradeData = GetWeaponData(upgradeId);

        ChangeWeapon(upgradeId);
        //현재 무기에 업글 상태 반영
        SetWeaponUpgradeStatus(upgradeId, UpgradeStatus.Completed);

        // 다음 무기를 업글가능 상태로 전환
        foreach (string nextUpgradeId in weaponUpgradeData.nextUpgrade.upgradeId) {
            SetWeaponUpgradeStatus(nextUpgradeId, UpgradeStatus.Available);
        }
    }

    /// <summary>
    /// 무기 업그레이드 리스트에서 해당하는 번호의 무기 업그레이드 정보를 가져옵니다
    /// </summary>
    /// <param name="upgradeId"> 무기 이름 </param>
    /// <returns> 무기 정보 </returns>
    public WeaponUpgradeData GetWeaponData(string upgradeId)
    {
        WeaponUpgradeData upgradeData = weaponUpgradeList[upgradeId];

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
    void EquipWeapon(GameObject weaponPrefab)
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
    /// 무기 업그레이드 정보들을 가져옵니다.
    /// </summary>
    /// <returns> 무기 업그레이드 인덱스 </returns>
    public Dictionary<string, WeaponUpgradeData> GetWeaponDatas()
    {
        return weaponUpgradeList;
    }

    /// <summary>
    /// 현재 무기 업그레이드 상태를 가져옵니다.
    /// </summary>
    /// <returns> 현 무기 업그레이드 상태 </returns>
    public Dictionary<string, UpgradeStatus> GetWeaponUpgradeStatus()
    {
        return weaponUpgradeStatus;
    }

    /// <summary>
    /// 무기 업그레이드 정보를 갱신합니다.
    /// </summary>
    /// <param name="id"> 설정할 업그레이드 번호 </param>
    /// <param name="status"> 설정할 상태 </param>
    /// <returns></returns>
    public Dictionary<string, UpgradeStatus> SetWeaponUpgradeStatus(string id, UpgradeStatus status)
    {
        weaponUpgradeStatus[id] = status;
        return weaponUpgradeStatus;
    }

}
