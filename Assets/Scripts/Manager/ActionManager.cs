using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 행동 모드
/// </summary>
public enum ActionMode
{
    AttackMode,
    BuildMode,
    NoAction
}

/// <summary>
/// 행동 관리자
/// </summary>
public class ActionManager : MonoBehaviour
{
    public static ActionManager Instance { private set; get; }

    public event Action<ActionMode> OnActionModeChanged;

    public ActionMode ActionMode { private set; get; }

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
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

    /// <summary>
    /// 현제 행동 모드를 변경합니다.
    /// </summary>
    /// <param name="newMode"> 변경할 행동 모드 </param>
    public void ChangeActionMode(ActionMode newMode)
    {
        if (newMode != ActionMode) {
            ActionMode = newMode;
            OnActionModeChanged?.Invoke(ActionMode); // 행동 모드 변경에 등록된 이벤트를 호출
        }
    }
}

