using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 건물중 small 타입의 건물.
/// </summary>
[Serializable]
public class SmallBuilding : Building
{
    /// <summary>
    /// 소형 건물을 타일멥에 그림.
    /// </summary>
    /// <param name="tilemap"></param>
    /// <param name="tilepos"></param>
    public override void DrawBuilding(Tilemap tilemap, Vector3Int tilepos)
    {
        buildingTilePos = tilepos;
        SetTrigger(tilemap);
        for (int i = 0; i < Tiles.Count; i++, SetTilePos(i))
        {
            tileMapTool.DrawTilemap(tilemap, Tiles[i], buildingTilePos);
        }
    }

    /// <summary>
    /// 트리거를 건물 가운데 배치.
    /// </summary>
    /// <param name="tilemap"></param>
    protected override void SetTrigger(Tilemap tilemap)
    {
        triggerPos = tilemap.CellToWorld(buildingTilePos);
        triggerPos.y = triggerPos.y + (float)0.25;
    }

    /// <summary>
    /// 건물 타일의 위치를 소형 건물에 맞춰 조정.
    /// </summary>
    /// <param name="count"></param>
    protected override void SetTilePos(int count)
    {
        switch (count)
        {
            case 0:
                break;

        }
    }
}
