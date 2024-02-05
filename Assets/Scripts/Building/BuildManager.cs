using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.VersionControl.Asset;
using static UnityEngine.RuleTile.TilingRuleOutput;


/// <summary>
/// Build�� Ÿ�ϸ㿡�� �Ͼ�� ��ȣ�ۿ��� ó��.
/// </summary>
public class BuildManager : MonoBehaviour
{
    // ���� Ÿ�ϸ�.
    public Tilemap tilemap;
    // Ÿ�ϸ㿡 �׸� Ÿ��.
    public TileBase tile;
    private TileMapTools buildTilemapTools;
    private Vector3Int tilemapPos = Vector3Int.zero;

    //���� ���̵� ������Ʈ.
    public GameObject buildingGuid;
    private Vector2 pos;
    
    [SerializeField]
    //�׷��� ���� ������ ����Ʈ 
    public List<Building> buildings;
    
    //���� ����
    public enum BuildingType {small, middel, big};
    public BuildingType buildingState;

    private void Start()
    {  
        buildTilemapTools = new TileMapTools();
        buildingGuid = GameObject.Find("Guid");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                        break;

                }


                /*Debug.Log("Draw");
                buildTilemapTools.DrawTilemap(tilemap, tile, tilemapPos);*/
            }
        }



    }

    /// <summary>
    /// ��� �ٸ� ���๰�� �ֳ� �Ǻ�.
    /// </summary>
    /// <returns>�Ǻ�����.</returns>
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
            Debug.Log("null");
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

    /// <summary>
    /// �׷��� Ÿ���� ��ġ�� ����.
    /// </summary>
    public void SetTilePos()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos3 = new Vector3(pos.x, pos.y, 0);
        Vector3 tilePos3 = tilemap.WorldToCell(pos3);
        tilemapPos = new Vector3Int((int)tilePos3.x, (int)tilePos3.y, 0);
        Debug.Log(tilePos3.x);
        Debug.Log(tilePos3.y);
    } 

    /// <summary>
    /// ������ ������ Ʈ���Ÿ� ����
    /// </summary>
    /// <param name="building"></param>
    public void SetBuildingTrigger(Building building)
    {
        GameObject trigger = Instantiate(building.GetTriggerPrefab(), building.GetTriggerPos(), Quaternion.identity);
    }
}







