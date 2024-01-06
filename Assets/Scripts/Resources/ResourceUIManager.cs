using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    public ResourceUI resourceUIPrefab;  // ResourceUI 프리팹
    public RectTransform uiContainer;     // UI를 담을 컨테이너

    public ResourceManager resourceManager;  // 자원을 관리하는 ResourceManager 스크립트

    // 초기화
    private void Start()
    {
        CreateResourceUIs();
    }

    // 모든 자원 UI 생성
    private void CreateResourceUIs()
    {
        foreach (Resource resource in resourceManager.resources) {
            ResourceUI newResourceUI = Instantiate(resourceUIPrefab, uiContainer);
            newResourceUI.resourceManager = resourceManager;
            newResourceUI.resourceName = resource.resourceName;
        }
    }
}
