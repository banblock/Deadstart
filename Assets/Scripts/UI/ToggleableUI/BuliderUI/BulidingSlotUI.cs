using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.ObjectChangeEventStream;

/// <summary>
/// 건물 UI 슬롯
/// </summary>
public class BuildingSlotUI : MonoBehaviour
{
    [SerializeField]
    Image bulidingImage;
    [SerializeField]
    TMP_Text bulidingNameText;
    [SerializeField]
    TMP_Text bulidingCommentText;
    [SerializeField]
    ResourceInfoUIContainer ResourceInfoUIContainer;

    BuilderUI BuilderUI;
    BuildingData buliding;

    public void Start()
    {
        BuilderUI = BuilderUI.Instace;
    }

    /// <summary>
    /// 건물 슬롯 UI 정보를 갱신
    /// </summary>
    /// <param name="bulidingData"></param>
    public void InitSlot(BuildingData bulidingData)
    {
        buliding = bulidingData;
        bulidingImage.sprite = bulidingData.sprite;
        bulidingNameText.text = bulidingData.name;
        bulidingCommentText.text = bulidingData.comment;
        ResourceInfoUIContainer.SetInitUI(bulidingData.requiredResources);
    }

    /// <summary>
    /// 현재 건물 슬롯은 선택합니다
    /// </summary>
    public void SelectBuilding()
    {
        BuilderUI.ChangeBuildMode();
    }
}

