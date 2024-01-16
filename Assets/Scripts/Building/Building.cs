using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Building
{
    public List<TileBase> Tiles;
    protected Vector3Int buildingTilePos;
    protected Vector3 triggerPos;
    [SerializeField]
    protected GameObject triggerPrefab;
    protected string buildingType;
    protected TileMapTools tileMapTool;

    public Building()
    {
        tileMapTool = new TileMapTools();
    }

    public Building(string type)
    {
        tileMapTool = new TileMapTools();
        buildingType = type;
    }

    //Ÿ���� �԰ݿ� �°� �׸�
    public virtual void DrawBuilding(Tilemap tilemap, Vector3Int tilepos)
    {
        buildingTilePos = tilepos;
        SetTrigger(tilemap);
        for (int i = 0; i < Tiles.Count; i++, SetTilePos(i))
        {
            tileMapTool.DrawTilemap(tilemap, Tiles[i], buildingTilePos);
        }
    }

    //Ÿ�� ��ġ�� ������ ������ ���� ������
    protected virtual void SetTilePos(int count)
    {
        switch (count)
        {
            case 0:
                break;

        }
    }

    //Ʈ���� ��ġ�� �ǹ� �߾����� ����
    protected virtual void SetTrigger(Tilemap tilemap)
    {
        triggerPos = tilemap.CellToWorld(buildingTilePos);
        triggerPos.y = triggerPos.y + (float)0.25;
    }

    //Ʈ���� ��ġ�� ��ȯ
    public Vector3 GetTriggerPos()
    {
        return triggerPos;
    }

    //Ʈ���� �������� ��ȯ
    public GameObject GetTriggerPrefab()
    {
        return triggerPrefab;
    }


}
