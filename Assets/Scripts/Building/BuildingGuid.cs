using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingGuid : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemap;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos3 = new Vector3(pos.x, pos.y, 0);
        Vector3 tilePos3 = tilemap.WorldToCell(pos3);
        Vector3Int tilemapPos = new Vector3Int((int)tilePos3.x, (int)tilePos3.y, 0);
        Vector3 mousePos = tilemap.CellToWorld(tilemapPos);
        mousePos.y = mousePos.y + (float)0.25;

        transform.position = mousePos;
        if(Mathf.Abs(transform.localPosition.x) > 4f||Mathf.Abs(transform.localPosition.y) > 2f)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.green;
        }
    }
}
