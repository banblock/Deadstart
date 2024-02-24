using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BuildingList", menuName = "ScriptableObjects/BuildingList", order = 1)]
public class BuildingList : ScriptableObject
{
    public List<GameObject> buildings;
    private int buildingCount;

    public BuildingList()
    {
        buildings = new List<GameObject>();
        buildingCount = 0;
    }
    public void DestroyBuilding(GameObject prefab)
    {
        buildings.Remove(prefab);
    }

    public void AddBuild(GameObject prefab)
    {
        BuildingData data = prefab.GetComponent<BuildingData>();
        data.buildingNum = buildingCount++;
        Debug.Log("data2 id" + data.buildingId);
        buildings.Add(prefab);
    }

}
