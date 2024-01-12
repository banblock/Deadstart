using UnityEngine;
using UnityEngine.UI;
using System;

public class ResourceUI : MonoBehaviour
{
    public Image resourceImage;
    public Text resourceText;
    public ResourceManager resourceManager;
    public ResourceType resourceName;

    private void Start()
    {
        resourceManager.OnResourceChanged += HandleResourceChanged;
    }

    private void OnEnable()
    {
        UpdateResourceUI();
    }

    private void HandleResourceChanged(ResourceType changedResourceName, int newAmount)
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

            //자원 이미지 출력
        }
    }

    private void OnDestroy()
    {
        resourceManager.OnResourceChanged -= HandleResourceChanged;
    }
}
