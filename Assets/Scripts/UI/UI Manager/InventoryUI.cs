using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : ToggleableUI
{
    public GameObject inventoryPanel;
    public Transform inventorySlotsParent;
    public GameObject inventorySlotPrefab;

    private string[] inventoryItems = { "Item1", "Item2", "Item3", "Item4" };
    private GameObject[] inventorySlots;


    private void Start()
    {
        
        inventoryPanel = this.gameObject;
        inventoryPanel.SetActive(false);
        InitializeInventory();
    }

    public override void ToggleUI()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    private void InitializeInventory()
    {
        inventorySlots = new GameObject[inventoryItems.Length];

    }

    
}

