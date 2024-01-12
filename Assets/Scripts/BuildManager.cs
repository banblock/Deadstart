using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class BuildManager : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    private TileMapTools buildTilemapTools;
    private Vector3Int tilemapPos = Vector3Int.zero;

    private void Start()
    {  
        buildTilemapTools = new TileMapTools();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!CheckHit())
            {
                Debug.Log("Draw");
                buildTilemapTools.DrawTilemap(tilemap, tile, tilemapPos);
            }
        }



    }

    bool CheckHit(){
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos3Int = new Vector3(pos.x, pos.y, 0);
        Vector3 tilePos3 = tilemap.WorldToCell(pos3Int);
        tilemapPos = new Vector3Int((int)tilePos3.x, (int)tilePos3.y, 0);
        Debug.Log(tilePos3.x);
        Debug.Log(tilePos3.y);
        TileBase tileBase = tilemap.GetTile(tilemapPos);
        if (tileBase != null)
        {
           
            Debug.Log("hit");
            return true;
           
        }
        else
        { 
            Debug.Log("null");
            
            return false;
        }
    }
}







