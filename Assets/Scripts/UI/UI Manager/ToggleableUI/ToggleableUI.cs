using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public abstract class ToggleableUI : MonoBehaviour
{
    public abstract void OpenUI();
    public abstract void CloseUI();
}