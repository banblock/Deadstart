using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

/// <summary>
/// ���� �ݱⰡ ������ UI
/// </summary>
public abstract class ToggleableUI : MonoBehaviour
{
    /// <summary>
    /// UI�� ���ϴ�
    /// </summary>
    public abstract void OpenUI();

    /// <summary>
    /// UI�� �ݽ��ϴ�
    /// </summary>
    public abstract void CloseUI();
}