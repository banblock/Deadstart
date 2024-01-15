using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionMode
{
    AttackMode,
    BuildMode,
    NoAction
}

public class ActionManager : MonoBehaviour
{
    public static ActionManager instance { private set; get; }

    // 이벤트 정의
    public event Action<ActionMode> OnActionModeChanged;

    public ActionMode ActionMode { private set; get; }

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    void Start()
    {
        ActionMode = ActionMode.AttackMode;
    }

    private void Update()
    {
        if(ActionMode == ActionMode.BuildMode) {
            if(Input.GetKeyUp(KeyCode.Escape)) {
                ChangeActionMode(ActionMode.AttackMode);
            }
        }
    }

    public void ChangeActionMode(ActionMode newMode)
    {
        if (newMode != ActionMode) {
            ActionMode = newMode;
            OnActionModeChanged?.Invoke(ActionMode);
        }
    }
}
