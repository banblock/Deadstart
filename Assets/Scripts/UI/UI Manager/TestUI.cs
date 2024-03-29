using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;

public class TestUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textLog;


    private void Start()
    {
        ActionManager.Instance.OnActionModeChanged += SetLogText;
        ChangeText(ActionManager.Instance.ActionMode.ToString());
    }

    public void SetLogText(ActionMode action)
    {
        ChangeText(action.ToString());
    }

    public void ChangeText(string addText)
    {
        textLog.text = "This is TestCode:   " + addText;
    }



    private void OnDestroy()
    {
        ActionManager.Instance.OnActionModeChanged -= SetLogText;
    }
}
