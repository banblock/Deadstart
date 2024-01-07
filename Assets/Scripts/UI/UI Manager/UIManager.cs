using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public ToggleableUI[] ToggleableUI;

    // 현재 열려있는 UI 창을 추적하는 변수
    private ToggleableUI currentOpenUI;

    private void Update()
    {
        // I키를 누르면 인벤토리 창을 엽니다.
        if (Input.GetKeyDown(KeyCode.I)) {
            OpenUI(ToggleableUI[0]);
        }

        // C키를 누르면 캐릭터 정보 창을 엽니다.
        if (Input.GetKeyDown(KeyCode.C)) {
            OpenUI(ToggleableUI[1]);
        }

        // Escape 키를 누르면 현재 열려있는 창을 닫습니다.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            CloseCurrentUI();
        }
    }

    private void OpenUI(ToggleableUI ui)
    {
        // 현재 열려있는 창이 있다면 닫습니다.
        if(currentOpenUI != ui) {
            CloseCurrentUI();
        }
        

        // 새로운 창을 엽니다.
        if (ui != null) {
            ui.ToggleUI();
            currentOpenUI = ui;
        }
    }

    private void CloseCurrentUI()
    {
        // 현재 열려있는 창이 있다면 닫습니다.
        if (currentOpenUI != null) {
            currentOpenUI.ToggleUI();
            currentOpenUI = null;
        }
    }
}
