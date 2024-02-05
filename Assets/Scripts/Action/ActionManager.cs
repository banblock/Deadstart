using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ൿ ���
/// </summary>
public enum ActionMode
{
    AttackMode,
    BuildMode,
    NoAction
}

/// <summary>
/// �ൿ ������
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
    /// ���� �ൿ ��带 �����մϴ�.
    /// </summary>
    /// <param name="newMode"> ������ �ൿ ��� </param>
    public void ChangeActionMode(ActionMode newMode)
    {
        if (newMode != ActionMode) {
            ActionMode = newMode;
            OnActionModeChanged?.Invoke(ActionMode); // �ൿ ��� ���濡 ��ϵ� �̺�Ʈ�� ȣ��
        }
    }
}
