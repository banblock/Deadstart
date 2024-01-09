using Unity.VisualScripting;
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

    private ToggleableUI currentOpenUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            CloseCurrentUI();
        }

        foreach (ToggleableUIContainer uiContainer in ToggleableUIs) {
            if (Input.GetKeyDown(uiContainer.keyCode)) {
                OpenUI(uiContainer.ToggleableUI);
            }
        }
    }

    private void OpenUI(ToggleableUI uiToOpen)
    {
        if (currentOpenUI != uiToOpen) {
            CloseCurrentUI();
            uiToOpen.OpenUI();
            currentOpenUI = uiToOpen;
        }
        else {
            CloseCurrentUI();
        }
    }

    private void CloseUI(ToggleableUI uiToClose)
    {
        uiToClose.CloseUI();
    }

    private void CloseCurrentUI()
    {
        if (currentOpenUI != null) {
            CloseUI(currentOpenUI);
            currentOpenUI = null;
        }
    }
}
