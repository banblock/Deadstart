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

        // Escape Ű�� ������ ���� �����ִ� â�� �ݽ��ϴ�.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            CloseCurrentUI();
        }
    }

    private void OpenUI(ToggleableUI ui)
    {
        // �ٸ� â�� ���� �ִ��� Ȯ���ϰ� �ݽ��ϴ�.
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
