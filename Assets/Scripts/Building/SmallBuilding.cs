using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class SmallBuilding : Building
{

    public override void DrawBuilding(Tilemap tilemap, Vector3Int tilepos)
    {
        buildingTilePos = tilepos;
        SetTrigger(tilemap);
        for (int i = 0; i < Tiles.Count; i++, SetTilePos(i))
        {
            tileMapTool.DrawTilemap(tilemap, Tiles[i], buildingTilePos);
        }
    }
    protected override void SetTrigger(Tilemap tilemap)
    {
        triggerPos = tilemap.CellToWorld(buildingTilePos);
        triggerPos.y = triggerPos.y + (float)0.25;
    }

    protected override void SetTilePos(int count)
    {
        switch (count)
        {
            case 0:
                break;

        }
    }
}
