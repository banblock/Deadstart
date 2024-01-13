using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { private set; get; }

    [System.Serializable]
    public class ToggleableUIContainer
    {
        public ToggleableUI ToggleableUI;
        public KeyCode keyCode;
    }
    public ToggleableUIContainer[] ToggleableUIs;
    private ToggleableUI currentOpenUI;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            return;
        }
        else {
            Destroy(gameObject);
        }
    }

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

    public void CloseCurrentUI()
    {
        if (currentOpenUI != null) {
            CloseUI(currentOpenUI);
            currentOpenUI = null;
        }
    }


}
