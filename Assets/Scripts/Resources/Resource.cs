using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Organic,
    Inorganic,
    Energy
}


[System.Serializable]
public class Resource
{
    public ResourceType resource;
    public int startingAmount;
    [HideInInspector] public int currentAmount;

    // �ڿ� �ʱ�ȭ
    public void Initialize()
    {
        currentAmount = startingAmount;
    }
}

