using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceManager : MonoBehaviour
{
    // 여러 자원을 담는 리스트
    public List<Resource> resources = new List<Resource>();

    // 이벤트 정의
    public event Action<ResourceType, int> OnResourceChanged;

    // 초기화
    private void Start()
    {
        InitializeResources();
    }

    private void Update()
    {
        // Test Code
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            IncreaseResource(ResourceType.Organic, 10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            IncreaseResource(ResourceType.Inorganic, 10);
        }

    }

    // 모든 자원 초기화
    private void InitializeResources()
    {
        foreach (Resource resource in resources) {
            resource.Initialize();
        }
    }

    // 특정 자원 양 증가
    public void IncreaseResource(ResourceType resourceName, int amount)
    {
        Resource resource = GetResource(resourceName);
        if (resource != null) {
            resource.currentAmount += amount;
            Debug.Log(resourceName + " increased by " + amount + ". Current amount: " + resource.currentAmount);
        }
        OnResourceChanged?.Invoke(resourceName, resource.currentAmount);
    }

    // 특정 자원 양 감소
    public void DecreaseResource(ResourceType resourceName, int amount)
    {
        Resource resource = GetResource(resourceName);
        if (resource != null && resource.currentAmount >= amount) {
            resource.currentAmount -= amount;
            Debug.Log(resourceName + " decreased by " + amount + ". Current amount: " + resource.currentAmount);
        }
        else {
            Debug.LogWarning("Not enough " + resourceName + " to decrease by " + amount + ".");
        }
        OnResourceChanged?.Invoke(resourceName, resource.currentAmount);
    }

    // 특정 자원의 현재 양 반환
    public int GetCurrentAmount(ResourceType resourceName)
    {
        Resource resource = GetResource(resourceName);
        return (resource != null) ? resource.currentAmount : 0;
    }

    // 자원 이름에 해당하는 Resource 객체 반환
    private Resource GetResource(ResourceType resource)
    {
        return resources.Find(r => r.resource == resource);
    }
}

