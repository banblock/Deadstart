using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.VersionControl.Asset;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class BuildManager : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    private TileMapTools buildTilemapTools;
    private Vector3Int tilemapPos = Vector3Int.zero;
    public GameObject buildingGuid;
    Vector2 pos;
    [SerializeField]
    public List<Building> buildings;
    public enum BuildingType {small, middel, big};
    public BuildingType buildingState;

    bool doBuild = false;
    

    private void Start()
    {  
        buildTilemapTools = new TileMapTools();
        buildingGuid = GameObject.Find("Guid");
        buildingGuid.SetActive(false);
        ActionManager.instance.OnActionModeChanged += ToggleBuildMode;
    }

    // Update is called once per frame
    void Update()
    {
        if (doBuild && Input.GetMouseButtonDown(0))
        {
            if (!CheckHit())
            {
                Building building;
                switch (buildingState)
                {
                    case BuildingType.small:
                        building = buildings[0];
                        building.DrawBuilding(tilemap, tilemapPos);
                        SetBuildingTrigger(building);
                        ActionManager.instance.ChangeActionMode(ActionMode.AttackMode);
                        buildingGuid.SetActive(false);
                        break;
                }


                /*Debug.Log("Draw");
                buildTilemapTools.DrawTilemap(tilemap, tile, tilemapPos);*/
            }
        }



    }

    bool CheckHit()
    {
        SetTilePos();
        TileBase tileBase = tilemap.GetTile(tilemapPos);
        if (tileBase != null)
        {
            Debug.Log("hit");
            return true;
        }
        else
        {
            /*RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.zero, 0f);
            if(hit.collider != null)
            {
                return true;
            }
            else{*/
            SpriteRenderer sr = buildingGuid.GetComponent<SpriteRenderer>();
            if(sr.color != Color.green)
            {
                return true;
            }
            else
            {
                return false;
            }
            //}
        }
    }

    public void SetTilePos()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos3 = new Vector3(pos.x, pos.y, 0);
        Vector3 tilePos3 = tilemap.WorldToCell(pos3);
        tilemapPos = new Vector3Int((int)tilePos3.x, (int)tilePos3.y, 0);
        Debug.Log(tilePos3.x);
        Debug.Log(tilePos3.y);
    } 

    public void SetBuildingTrigger(Building building)
    {
        GameObject trigger = Instantiate(building.GetTriggerPrefab(), building.GetTriggerPos(), Quaternion.identity);
    }

    public void ToggleBuildMode(ActionMode action)
    {
        doBuild = (action == ActionMode.BuildMode);
        if(doBuild) {
            buildingGuid.SetActive(true);
        }
    }

    
    void OnDestroy()
    {
        ActionManager.instance.OnActionModeChanged -= ToggleBuildMode;
    }
}







