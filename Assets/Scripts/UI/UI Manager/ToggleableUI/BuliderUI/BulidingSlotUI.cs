using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BulidingSlotUI : MonoBehaviour
{
    [SerializeField]
    Image bulidingImage;
    [SerializeField]
    TMP_Text bulidingNameText;
    [SerializeField]
    TMP_Text bulidingCommentText;

    BulidingData buliding;

    public class BulidingData
    {
        public Sprite sprite;
        public string name;
        public string comment;

        public int Inorganic;
        public int Organic;
        public int Energy;
    }

    void initSlot(BulidingData bulidingData)
    {
        bulidingImage.sprite = bulidingData.sprite;
        bulidingNameText.text = bulidingData.name;
        bulidingCommentText.text = bulidingData.comment;
    }

    public void SelectBuilding()
    {
        Debug.Log("현제 빌딩을 건설합니다.");
    }
}
