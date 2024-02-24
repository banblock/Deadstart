using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingData : MonoBehaviour
{
    //건물정보
    public int buildingHealth;
    public int buildingLevel;
    public int buildingType;
    public int buildingId;
    public string name;
    public string comment;
    public int buildingNum;

    //건물구성
    public GameObject buildingObj;
    public Sprite sprite;

    public List<Resource> requiredResources;

    private BuildManager buildManager;

    private Vector3 buildingPos;
    /// <summary>
    /// 건물 삭제 메서드
    /// </summary>
    public void DestroyBuilding()
    {
        buildManager.DestroyBuilding(this.buildingObj);
    }

    /// <summary>
    /// 건물 타격 메서드
    /// </summary>
    /// <param name="damageAmount"></param>
    public void TakeDamage(int damageAmount)
    {
        buildingHealth -= damageAmount;
        if (buildingHealth <= 0)
        {
            DestroyBuilding();
        }
    }

    public void SetManager(BuildManager manager)
    {
         this.buildManager = manager;
    }

    public void SetBuildingPos(Vector3 pos)
    {
        buildingPos = pos;
    } 

    public void SetPrefab(GameObject prefab)
    {
        buildingObj = prefab;
    }
}
