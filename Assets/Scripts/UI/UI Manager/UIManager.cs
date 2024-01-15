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
    private ActionManager actionManager;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            return;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        actionManager = ActionManager.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            CloseCurrentUI();
        }

        foreach (ToggleableUIContainer uiContainer in ToggleableUIs) {
            if (Input.GetKeyDown(uiContainer.keyCode)) {
                if (uiContainer.ToggleableUI != currentOpenUI) {
                    CloseCurrentUI();
                    OpenUI(uiContainer.ToggleableUI);
                }
                else {
                    CloseCurrentUI();
                }
            }
        }
    }

    private void OpenUI(ToggleableUI uiToOpen)
    {
        uiToOpen.OpenUI();
        currentOpenUI = uiToOpen;
        actionManager.ChangeActionMode(ActionMode.NoAction);
    }

    private void CloseUI(ToggleableUI uiToClose)
    {
        uiToClose.CloseUI();
    }

    public void CloseCurrentUI()
    {
        actionManager.ChangeActionMode(ActionMode.AttackMode);
        if (currentOpenUI != null) {
            CloseUI(currentOpenUI);
            currentOpenUI = null;
        }
    }
}
