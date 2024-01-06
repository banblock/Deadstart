using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    public string resourceName;
    public int startingAmount;
    [HideInInspector] public int currentAmount;

    // 자원 초기화
    public void Initialize()
    {
        currentAmount = startingAmount;
    }
}

