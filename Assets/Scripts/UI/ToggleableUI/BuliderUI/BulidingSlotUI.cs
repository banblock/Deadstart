using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.ObjectChangeEventStream;

/// <summary>
/// �ǹ� UI ����
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
    /// �ǹ� ���� UI ������ ����
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
    /// ���� �ǹ� ������ �����մϴ�
    /// </summary>
    public void SelectBuilding()
    {
        BuilderUI.ChangeBuildMode();
    }
}
