using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingData : MonoBehaviour
{
    //�ǹ�����
    public int buildingHealth;
    public int buildingLevel;
    public int buildingType;
    public int buildingId;
    public string name;
    public string comment;
    public int buildingNum;

    //�ǹ�����
    public GameObject buildingObj;
    public Sprite sprite;

    public List<Resource> requiredResources;

    private BuildManager buildManager;

    private Vector3 buildingPos;
    /// <summary>
    /// �ǹ� ���� �޼���
    /// </summary>
    public void DestroyBuilding()
    {
        buildManager.DestroyBuilding(this.buildingObj);
    }

    /// <summary>
    /// �ǹ� Ÿ�� �޼���
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
