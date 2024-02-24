using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventorySystem
{
    //Author: Jaxon Schauer
    /// <summary>
    /// Represents the initial configuration for an inventory.
    /// This class defines various properties such as dimensions, behavior, and interactive elements for an inventory system.
    /// </summary>
    [System.Serializable]
    public class InventoryInitializer
    {
        [Header("========[ 기본 인벤토리 정보 ]========")]

        [Tooltip("인벤토리에 대한 설명적인 이름 또는 식별자.")]
        [SerializeField]
        private string inventoryName;

        [Tooltip("인벤토리 레이아웃의 행 수.")]
        [SerializeField]
        private int rows;

        [Tooltip("인벤토리 레이아웃의 열 수.")]
        [SerializeField]
        private int cols;

        [SerializeField, HideInInspector]
        private bool initialized = false;
        public string GetInventoryName()
        {
            return inventoryName;
        }
        public int GetRows()
        {
            return rows;
        }
        public int GetCols()
        {
            return cols;
        }
        public void SetRows(int rows)
        {
            this.rows = rows;
        }
        public void SetCols(int cols)
        {
            this.cols = cols;
        }
        public void SetInventoryName(string inventoryName)
        {
            this.inventoryName = inventoryName;
        }
        public bool GetInitialized()
        {
            return initialized;
        }
        public void SetInitialized(bool initialized)
        {
            this.initialized = initialized;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (inventoryName?.GetHashCode() ?? 0);
                hash = hash * 23 + rows.GetHashCode();
                hash = hash * 23 + cols.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return obj is InventoryInitializer initializer &&
                   inventoryName == initializer.inventoryName &&
                   rows == initializer.rows &&
                   cols == initializer.cols;
        }
        public void Copy(InventoryInitializer initilizer)
        {
            inventoryName = initilizer.inventoryName;
            rows = initilizer.rows;
            cols = initilizer.cols;
        }
    }
}

