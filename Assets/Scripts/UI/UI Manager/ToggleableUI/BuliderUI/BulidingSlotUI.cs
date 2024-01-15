using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.ObjectChangeEventStream;

public class BuildingSlotUI : MonoBehaviour
{
    [SerializeField]
    Image bulidingImage;
    [SerializeField]
    TMP_Text bulidingNameText;
    [SerializeField]
    TMP_Text bulidingCommentText;
    [SerializeField]
    HorizontalLayoutGroup resourceUIContainers;

    BuilderUI BuilderUI;
    BuildingData buliding;

    public void Start()
    {
        BuilderUI = BuilderUI.Instace;
    }

    public void InitSlot(BuildingData bulidingData)
    {
        buliding = bulidingData;
        bulidingImage.sprite = bulidingData.sprite;
        bulidingNameText.text = bulidingData.name;
        bulidingCommentText.text = bulidingData.comment;
    }

    public void SelectBuilding()
    {
        BuilderUI.ChangeBuildMode();
    }
}
