using UnityEngine;

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public class ToggleableUIContainer
    {
        public ToggleableUI ToggleableUI;
        public KeyCode keyCode;
    }

    public ToggleableUIContainer[] ToggleableUIs;

    private void Update()
    {
        foreach (ToggleableUIContainer toggleableUI in ToggleableUIs) {
            if (Input.GetKeyDown(toggleableUI.keyCode)) {
                if (toggleableUI.ToggleableUI.IsOpen()) {
                    CloseUI(toggleableUI.ToggleableUI);
                }
                else {
                    OpenUI(toggleableUI.ToggleableUI);
                }
            }
        }

        // Escape 키를 누르면 현재 열려있는 창을 닫습니다.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            CloseCurrentUI();
        }
    }

    private void OpenUI(ToggleableUI ui)
    {
        // 다른 창이 열려 있는지 확인하고 닫습니다.
        foreach (ToggleableUIContainer toggleableUI in ToggleableUIs) {
            if (toggleableUI.ToggleableUI.IsOpen() && toggleableUI.ToggleableUI != ui) {
                CloseUI(toggleableUI.ToggleableUI);
            }
        }

        if (ui != null) {
            ui.ToggleUI();
        }
    }

    private void CloseUI(ToggleableUI ui)
    {
        if (ui != null) {
            ui.ToggleUI();
        }
    }

    private void CloseCurrentUI()
    {
        foreach (ToggleableUIContainer toggleableUI in ToggleableUIs) {
            if (toggleableUI.ToggleableUI.IsOpen()) {
                CloseUI(toggleableUI.ToggleableUI);
                return;
            }
        }
    }
}
