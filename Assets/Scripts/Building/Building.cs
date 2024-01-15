using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building
{
    public List<TileBase> Tiles;
    private Vector3Int buildingTilePos;
    private Vector3 triggerPos;
    private GameObject triggerPrefab;
    private string buildingType;
    protected TileMapTools tileMapTool;

    Building()
    {
        tileMapTool = new TileMapTools();
    }

    Building(string type)
    {
        tileMapTool = new TileMapTools();
        buildingType = type;
    }


    public virtual void DrawBuilding(Tilemap tilemap, Vector3Int tilepos)
    {
        buildingTilePos = tilepos;
        SetTrigger(tilemap);
        for (int i = 0; i < Tiles.Count; i++ , SetTilePos(i))
        {
            tileMapTool.DrawTilemap(tilemap, Tiles[i], tilepos);
        }
    }

    private void SetTilePos(int count)
    {
        switch(count){
            case 0:
                break;

        }
    }

    private void SetTrigger(Tilemap tilemap)
    {
        triggerPos = tilemap.CellToWorld(buildingTilePos);
        triggerPos.y = triggerPos.y + (float)0.25; 
    }

    public Vector3 GetTriggerPos()
    {
        return triggerPos;
    }

    public GameObject GetTriggerPrefab()
    {
        return triggerPrefab;
    }


}
