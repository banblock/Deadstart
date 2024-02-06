using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 오브젝트를 타일멥에 그리는 도구.
/// </summary>
public class TileMapTools
{
    /// <summary>
    /// 입력받은 타일을 입력받은 타일멥의 입력받은 타일멥좌표에 그림.
    /// </summary>
    /// <param name="tilemap"></param>
    /// <param name="tile"></param>
    /// <param name="tilemapPos"></param>
    public void DrawTilemap(Tilemap tilemap, TileBase tile, Vector3Int tilemapPos)
    {            
        tilemap.SetTile(tilemapPos, tile);
    }

}
