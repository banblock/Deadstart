using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 건설 UI
/// </summary>
public class BuilderUI : ToggleableUI
{
    public static BuilderUI Instace { private set; get; }

    [SerializeField]
    HorizontalOrVerticalLayoutGroup BuliderUIContainer;
    [SerializeField]
    GameObject bulidingUIButtonPrefab;
    [SerializeField]
    BuildingList buildingList;

    private void Awake()
    {
        if (Instace == null) {
            Instace = this;
        }
        else {
            Destroy(this);
        }
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public override void OpenUI()
    {
        gameObject.SetActive(true);
        UpdateUI();
    }

    public override void CloseUI()
    {

        gameObject.SetActive(false);
    }

    /// <summary>
    /// 건설 목록을 업데이트 합니다.
    /// </summary>
    public void UpdateUI()
    {
        ClearUIContainer();

        foreach (BuildingData building in buildingList.buildings) {
            if (building != null) {
                GameObject newButton = Instantiate(bulidingUIButtonPrefab, BuliderUIContainer.transform);
                BuildingSlotUI buildingSlot = newButton.GetComponent<BuildingSlotUI>();

                if (buildingSlot != null) {
                    buildingSlot.InitSlot(building);
                }
                else {
                    Debug.LogError("BuildingSlotUI script not found on the instantiated button.");
                }
            }
        }
    }

    /// <summary>
    /// 행동 모드를 변경합니다.
    /// </summary>
    public void ChangeBuildMode()
    {
        ActionManager.Instance.ChangeActionMode(ActionMode.BuildMode);
        gameObject.SetActive(false);
    }

    private void ClearUIContainer()
    {
        foreach (Transform child in BuliderUIContainer.transform) {
            Destroy(child.gameObject);
        }
    }

}
