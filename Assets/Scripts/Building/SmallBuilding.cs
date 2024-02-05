using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// �ǹ��� small Ÿ���� �ǹ�.
/// </summary>
[Serializable]
public class SmallBuilding : Building
{
    /// <summary>
    /// ���� �ǹ��� Ÿ�ϸ㿡 �׸�.
    /// </summary>
    /// <param name="tilemap"></param>
    /// <param name="tilepos"></param>
    public override void DrawBuilding(Tilemap tilemap, Vector3Int tilepos)
    {
        buildingTilePos = tilepos;
        SetTrigger(tilemap);
        for (int i = 0; i < Tiles.Count; i++, SetTilePos(i))
        {
            tileMapTool.DrawTilemap(tilemap, Tiles[i], buildingTilePos);
        }
    }

    /// <summary>
    /// Ʈ���Ÿ� �ǹ� ��� ��ġ.
    /// </summary>
    /// <param name="tilemap"></param>
    protected override void SetTrigger(Tilemap tilemap)
    {
        triggerPos = tilemap.CellToWorld(buildingTilePos);
        triggerPos.y = triggerPos.y + (float)0.25;
    }

    /// <summary>
    /// �ǹ� Ÿ���� ��ġ�� ���� �ǹ��� ���� ����.
    /// </summary>
    /// <param name="count"></param>
    protected override void SetTilePos(int count)
    {
        switch (count)
        {
            case 0:
                break;

        }
    }
}
