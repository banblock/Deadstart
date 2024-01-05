using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool occupied;

    void Awake(){
        occupied = false;
    }

    // 건물이 지어질 때 호출되는 함수
    public void SetOccupied()
    {
        occupied = true;
    }

    // 건물이 제거될 때 호출되는 함수
    public void SetUnoccupied()
    {
        occupied = false;
    }
}
