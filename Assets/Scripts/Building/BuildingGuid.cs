using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class BuildingGuid : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemap;
    private SpriteRenderer spriteRenderer;
    public bool hit;
    void Start()
    {
        hit = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos3 = new Vector3(pos.x, pos.y, 0);
        Vector3 tilePos3 = tilemap.WorldToCell(pos3);
        Vector3Int tilemapPos = new Vector3Int((int)tilePos3.x, (int)tilePos3.y, 0);
        Vector3 mousePos = tilemap.CellToLocal(tilemapPos);
        mousePos.y = mousePos.y + (float)0.25;

        transform.position = mousePos;
        if(Mathf.Abs(transform.localPosition.x) > 4f|| Mathf.Abs(transform.localPosition.x) < 1f)
        {
            if(Mathf.Abs(transform.localPosition.y) > 2f || Mathf.Abs(transform.localPosition.y) < 1f)
            {
                spriteRenderer.color = Color.red;
            }
        }
        else if(!hit)
        {
            spriteRenderer.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hit = false;
    }
}
