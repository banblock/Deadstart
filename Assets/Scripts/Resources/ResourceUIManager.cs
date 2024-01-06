using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    public ResourceUI resourceUIPrefab;  // ResourceUI ������
    public RectTransform uiContainer;     // UI�� ���� �����̳�

    public ResourceManager resourceManager;  // �ڿ��� �����ϴ� ResourceManager ��ũ��Ʈ

    // �ʱ�ȭ
    private void Start()
    {
        CreateResourceUIs();
    }

    // ��� �ڿ� UI ����
    private void CreateResourceUIs()
    {
        foreach (Resource resource in resourceManager.resources) {
            ResourceUI newResourceUI = Instantiate(resourceUIPrefab, uiContainer);
            newResourceUI.resourceManager = resourceManager;
            newResourceUI.resourceName = resource.resourceName;
        }
    }
}
