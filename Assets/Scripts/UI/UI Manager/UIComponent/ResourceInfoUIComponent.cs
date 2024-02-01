using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInfoUIComponent : MonoBehaviour
{
    [SerializeField]
    Image resourceImage;
    [SerializeField]
    TMP_Text resourceAmountText;

    public void SetInitUI(Item item)
    {
        resourceImage.sprite = item.Sprite;
        resourceAmountText.text = item.amount.ToString();
    }
}
