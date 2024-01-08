using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public abstract class ToggleableUI : MonoBehaviour
{
    private bool isOpen = false;
    public abstract void OpenUI();
    public abstract void CloseUI();
    public bool IsOpen()
    {
        return isOpen;
    }
}