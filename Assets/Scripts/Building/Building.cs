using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 건물 오브젝트 기능모음.
/// </summary>
[Serializable]
public class Building
{
    //건물에 해당하는 타일들.
    public List<TileBase> Tiles;
    //건물의 좌표
    protected Vector3Int buildingTilePos;
    //트리거의 좌표(상대적 고정)
    protected Vector3 triggerPos;
    [SerializeField]
    //트리거 프리펩
    protected GameObject triggerPrefab;
    //건물 타입이름
    protected string buildingType;
    //타일 그리기용 타일멥툴
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

    /// <summary>
    /// 타일을 규격에 맞게 그림.
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
    /// 타일 위치를 빌딩의 구조에 따라 조정함
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

    /// <summary>
    /// 트리거 위치를 건물 중앙으로 설정
    /// </summary>
    /// <param name="tilemap"></param>
    protected virtual void SetTrigger(Tilemap tilemap)
    {
        triggerPos = tilemap.CellToWorld(buildingTilePos);
        triggerPos.y = triggerPos.y + (float)0.25;
    }

    /// <summary>
    /// 트리거 위치를 반환
    /// </summary>
    /// <returns></returns>
    public Vector3 GetTriggerPos()
    {
        return triggerPos;
    }

    /// <summary>
    /// 트리거 프리펩을 반환
    /// </summary>
    /// <returns></returns>
    public GameObject GetTriggerPrefab()
    {
        return triggerPrefab;
    }


}
