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

    //타일을 규격에 맞게 그림
    public virtual void DrawBuilding(Tilemap tilemap, Vector3Int tilepos)
    {
        buildingTilePos = tilepos;
        SetTrigger(tilemap);
        for (int i = 0; i < Tiles.Count; i++, SetTilePos(i))
        {
            tileMapTool.DrawTilemap(tilemap, Tiles[i], buildingTilePos);
        }
    }

    //타일 위치를 빌딩의 구조에 따라 조정함
    protected virtual void SetTilePos(int count)
    {
        switch (count)
        {
            case 0:
                break;

        }
    }

    //트리거 위치를 건물 중앙으로 설정
    protected virtual void SetTrigger(Tilemap tilemap)
    {
        triggerPos = tilemap.CellToWorld(buildingTilePos);
        triggerPos.y = triggerPos.y + (float)0.25;
    }

    //트리거 위치를 반환
    public Vector3 GetTriggerPos()
    {
        return triggerPos;
    }

    //트리거 프리펩을 반환
    public GameObject GetTriggerPrefab()
    {
        return triggerPrefab;
    }


}
