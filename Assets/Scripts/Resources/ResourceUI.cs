using UnityEngine;
using UnityEngine.UI;
using System;

public class ResourceUI : MonoBehaviour
{
    public Image resourceImage;
    public Text resourceText;
    public ResourceManager resourceManager;
    public string resourceName;

    private void Start()
    {
        resourceManager.OnResourceChanged += HandleResourceChanged;
    }

    private void OnEnable()
    {
        UpdateResourceUI();
    }

    private void HandleResourceChanged(string changedResourceName, int newAmount)
    {
        if (changedResourceName == resourceName) {
            UpdateResourceUI();
        }
    }

    private void UpdateResourceUI()
    {
        if (resourceManager != null && resourceText != null && resourceImage != null) {
            int currentAmount = resourceManager.GetCurrentAmount(resourceName);
            resourceText.text = currentAmount.ToString();

            if (resourceName == "Wood") {
                Sprite woodSprite = Resources.Load<Sprite>("WoodImage");
                resourceImage.sprite = woodSprite;
            }
        }
    }

    private void OnDestroy()
    {
        resourceManager.OnResourceChanged -= HandleResourceChanged;
    }
}
