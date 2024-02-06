using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectSet : MonoBehaviour
{
    public Tilemap tilemap;
    private Vector3 objectCellPos;
    public GameObject objectPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!CheckHit())
            {
                GameObject newObject = Instantiate(objectPrefab, objectCellPos, Quaternion.identity);
            }
        }
    }

    bool CheckHit()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos3 = new Vector3(pos.x, pos.y, 0);
        Vector3 tilePos3 = tilemap.WorldToCell(pos3);
        Vector3Int tileCell = new Vector3Int((int)tilePos3.x, (int)tilePos3.y, 0);
        objectCellPos = tilemap.CellToWorld (tileCell);
        objectCellPos.y = objectCellPos.y + (float)0.25;
        TileBase tileBase = tilemap.GetTile(tileCell);
        if(tileBase != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
