using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingData
{
    public GameObject buildingPrefab;
    public Sprite sprite;
    public string name;
    public string comment;

    public List<Resource> requiredResources;
}
