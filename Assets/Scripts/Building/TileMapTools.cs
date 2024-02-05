using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// ������Ʈ�� Ÿ�ϸ㿡 �׸��� ����.
/// </summary>
public class TileMapTools
{
    /// <summary>
    /// �Է¹��� Ÿ���� �Է¹��� Ÿ�ϸ��� �Է¹��� Ÿ�ϸ���ǥ�� �׸�.
    /// </summary>
    /// <param name="tilemap"></param>
    /// <param name="tile"></param>
    /// <param name="tilemapPos"></param>
    public void DrawTilemap(Tilemap tilemap, TileBase tile, Vector3Int tilemapPos)
    {            
        tilemap.SetTile(tilemapPos, tile);
    }

}
