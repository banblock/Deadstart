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
/// Build용 타일멥에서 일어나는 상호작용을 처리.
/// </summary>
public class BuildManager : MonoBehaviour
{
    //HitCheck
        // 빌드 타일멥.
    public Tilemap tilemap;
    private Vector3Int tilemapPos = Vector3Int.zero;
        //빌딩 가이드 오브젝트.
    public GameObject buildingGuid;
    private Vector2 pos;

    //프리펩 생성과 데이터 관리를 담당하는 객체
    public BuildingList buildingDataList;
    
    //building
    [SerializeField]
        //그려질 빌딩 데이터 리스트 
    public List<Building> buildings;
        //빌딩 타입
    public enum BuildingType { small, middel, big };
    public BuildingType buildingState;
    public GameObject selectedBuilding;

    //모드
    public bool isBuild;
    public bool isDestroye;
//-------------------------------------------------------------------------------------------- 메인
    private void Start()
    {
        buildingGuid = GameObject.Find("Guid");
        isDestroye = false;
        isBuild = true;
        buildingDataList = new BuildingList();
        ActionManager.instance.OnActionModeChanged += SetBuildModeEnable;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!isDestroye)
                {
                    BuildBuilding();
                }
                else
                {
                    if (CheckBuilding())
                    {
                        DestroyBuilding(selectedBuilding);
                        selectedBuilding = null;
                    }

                }
            }else if(Input.GetKeyDown(KeyCode.B))
            {
                isDestroye = !isDestroye;
            }

        }
    }
//------------------------------------------------------------------------------------------------- 빌드 프레임
    private void BuildBuilding()
    {
        if (!CheckHit())
        {
            switch (buildingState)
            {
                case BuildingType.small:
                    buildings[0].DrawBuilding(tilemap, tilemapPos);
                    AddBuildingTrigger(buildings[0]);
                    break;

            }
        }
    }

    public void DestroyBuilding(GameObject prefab)
    {
        SetTilePos();
        buildings[0].RemoveBuildingTiles(tilemap, tilemapPos);
        buildingDataList.DestroyBuilding(prefab);
        Destroy(prefab);
    }

//----------------------------------------------------------------------------------------- 툴

    /// <summary>
    /// 멥상에 다른 건축물이 있나 판별.
    /// </summary>
    /// <returns>판별여부.</returns>
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
            if (sr.color != Color.green)
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
    /// 마우스의 타일의 위치를 탐색.
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
    /// 생성한 빌딩의 트리거를 셋팅
    /// </summary>
    /// <param name="building"></param>
    public void AddBuildingTrigger(Building building)
    {   
        GameObject trigger = Instantiate(building.GetBuildingPrefab(), building.GetTriggerPos(), Quaternion.identity);
        BuildingData data = trigger.GetComponent<BuildingData>();
        data.SetBuildingPos(building.GetTriggerPos());
        data.SetPrefab(trigger);
        Debug.Log("building id" + building.buildingId);
        data.buildingId = building.buildingId;
        Debug.Log("data id" + data.buildingId);
        buildingDataList.AddBuild(trigger);
    }

    public bool CheckBuilding()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if(hit.collider != null)
        {
            selectedBuilding = hit.collider.gameObject;
            return true;
        }
        else
        {
            return false;
        }

    }

    private void SetBuildModeEnable(ActionMode action)
    {
        isBuild = (action == ActionMode.BuildMode);
    }
}







