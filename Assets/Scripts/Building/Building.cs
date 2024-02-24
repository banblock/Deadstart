using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// �ǹ� ������Ʈ ��ɸ���.
/// </summary>
[Serializable]
public class Building
{
    [SerializeField]
    //�ǹ� ��ü
    protected GameObject BuildingPrefab;
    //�ǹ��� �ش��ϴ� Ÿ�ϵ�.
    public List<TileBase> Tiles;

    //�ǹ��� ��ǥ
    protected Vector3Int buildingTilePos;
    //��ü�� ��ǥ(����� ����)
    protected Vector3 triggerPos;


    //Ÿ�� �׸���� Ÿ�ϸ���
    protected TileMapTools tileMapTool;

    //���� id
    public int buildingId;

    
    public Building()
    {
        tileMapTool = new TileMapTools();
    }

    /// <summary>
    /// Ÿ���� �԰ݿ� �°� �׸�.
    /// </summary>
    /// <param name="tilemap"></param>
    /// <param name="tilepos"></param>
    public virtual void DrawBuilding(Tilemap tilemap, Vector3Int tilepos)
    {
        buildingTilePos = tilepos;
        SetTrigger(tilemap);
        for (int i = 0; i < Tiles.Count; i++, SetTilePos(i))
        {
            tileMapTool.DrawTilemap(tilemap, Tiles[i], buildingTilePos);
        }
    }

    /// <summary>
    /// Ÿ�� ��ġ�� ������ ������ ���� ������
    /// </summary>
    /// <param name="count"></param>
    protected virtual void SetTilePos(int count)
    {
        switch (count)
        {
            case 0:
                break;

        }
    }

    public void SetID(int id)
    {
        buildingId = id;
    }

    protected virtual void SetTrigger(Tilemap tilemap)
    {
        triggerPos = tilemap.CellToWorld(buildingTilePos);
        triggerPos.y = triggerPos.y + (float)0.25;
    }

    /// <summary>
    /// Ʈ���� ��ġ�� ��ȯ
    /// </summary>
    /// <returns></returns>
    public Vector3 GetTriggerPos()
    {
        return triggerPos;
    }

    /// <summary>
    /// Ʈ���� �������� ��ȯ
    /// </summary>
    /// <returns></returns>
    public GameObject GetBuildingPrefab()
    {
        return BuildingPrefab;
    }

    public void RemoveBuildingTiles(Tilemap tilemap, Vector3Int tilepos)
    {
        buildingTilePos = tilepos;
        for (int i = 0; i < Tiles.Count; i++, SetTilePos(i))
        {
            tileMapTool.RemoveTilemap(tilemap, buildingTilePos);
        }
    } 
}
