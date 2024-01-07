using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public ToggleableUI[] ToggleableUI;

    // ���� �����ִ� UI â�� �����ϴ� ����
    private ToggleableUI currentOpenUI;

    private void Update()
    {
        // IŰ�� ������ �κ��丮 â�� ���ϴ�.
        if (Input.GetKeyDown(KeyCode.I)) {
            OpenUI(ToggleableUI[0]);
        }

        // CŰ�� ������ ĳ���� ���� â�� ���ϴ�.
        if (Input.GetKeyDown(KeyCode.C)) {
            OpenUI(ToggleableUI[1]);
        }

        // Escape Ű�� ������ ���� �����ִ� â�� �ݽ��ϴ�.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            CloseCurrentUI();
        }
    }

    private void OpenUI(ToggleableUI ui)
    {
        // ���� �����ִ� â�� �ִٸ� �ݽ��ϴ�.
        if(currentOpenUI != ui) {
            CloseCurrentUI();
        }
        

        // ���ο� â�� ���ϴ�.
        if (ui != null) {
            ui.ToggleUI();
            currentOpenUI = ui;
        }
    }

    private void CloseCurrentUI()
    {
        // ���� �����ִ� â�� �ִٸ� �ݽ��ϴ�.
        if (currentOpenUI != null) {
            currentOpenUI.ToggleUI();
            currentOpenUI = null;
        }
    }
}
