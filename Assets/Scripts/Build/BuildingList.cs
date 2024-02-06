using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingList", menuName = "ScriptableObjects/BuildingList", order = 1)]
public class BuildingList : ScriptableObject
{
    public List<BuildingData> buildings;
}
