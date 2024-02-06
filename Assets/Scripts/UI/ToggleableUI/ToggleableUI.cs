using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

/// <summary>
/// 열고 닫기가 가능한 UI
/// </summary>
public abstract class ToggleableUI : MonoBehaviour
{
    /// <summary>
    /// UI를 엽니다
    /// </summary>
    public abstract void OpenUI();

    /// <summary>
    /// UI를 닫습니다
    /// </summary>
    public abstract void CloseUI();
}