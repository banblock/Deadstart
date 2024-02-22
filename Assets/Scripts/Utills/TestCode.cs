using InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    [SerializeField]
    AddItem item;

    [SerializeField]
    AddItem item2;

    [SerializeField]
    AddItem item3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("테스트");
            item.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Debug.Log("테스트");
            item2.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Debug.Log("테스트");
            item3.gameObject.SetActive(true);
        }

    }
}
