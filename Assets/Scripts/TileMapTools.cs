using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTools
{

    public void DrawTilemap(Tilemap tilemap, TileBase tile, Vector3Int tilemapPos)
    {            
        tilemap.SetTile(tilemapPos, tile);
    }

}
