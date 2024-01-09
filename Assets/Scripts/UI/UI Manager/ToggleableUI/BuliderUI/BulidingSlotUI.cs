using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulidingSlotUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text bulidingNameText;


    public class BulidingData
    {
        public string name;

        public int Inorganic;
        public int Organic;
        public int Energy;
    }

    void initSlot(BulidingData bulidingData)
    {
        bulidingNameText.text = bulidingData.name;




    }
}
