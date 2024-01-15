using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuilderUI : ToggleableUI
{
    public static BuilderUI Instace { private set; get; }

    [SerializeField]
    VerticalLayoutGroup BuliderUIContainer;
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

    private void ClearUIContainer()
    {
        foreach (Transform child in BuliderUIContainer.transform) {
            Destroy(child.gameObject);
        }
    }


    public void ChangeBuildMode()
    {
        ActionManager.instance.ChangeActionMode(ActionMode.BuildMode);
        gameObject.SetActive(false);
    }
}
