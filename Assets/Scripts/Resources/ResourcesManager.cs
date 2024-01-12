using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceManager : MonoBehaviour
{
    // ���� �ڿ��� ��� ����Ʈ
    public List<Resource> resources = new List<Resource>();

    // �̺�Ʈ ����
    public event Action<string, int> OnResourceChanged;

    // �ʱ�ȭ
    private void Start()
    {
        InitializeResources();
    }

    private void Update()
    {
        // Test Code
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            IncreaseResource("Steal", 10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            IncreaseResource("Energy", 10);
        }

    }

    // ��� �ڿ� �ʱ�ȭ
    private void InitializeResources()
    {
        foreach (Resource resource in resources) {
            resource.Initialize();
        }
    }

    // Ư�� �ڿ� �� ����
    public void IncreaseResource(string resourceName, int amount)
    {
        Resource resource = GetResource(resourceName);
        if (resource != null) {
            resource.currentAmount += amount;
            Debug.Log(resourceName + " increased by " + amount + ". Current amount: " + resource.currentAmount);
        }
        OnResourceChanged?.Invoke(resourceName, resource.currentAmount);
    }

    // Ư�� �ڿ� �� ����
    public void DecreaseResource(string resourceName, int amount)
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

    // Ư�� �ڿ��� ���� �� ��ȯ
    public int GetCurrentAmount(string resourceName)
    {
        Resource resource = GetResource(resourceName);
        return (resource != null) ? resource.currentAmount : 0;
    }

    // �ڿ� �̸��� �ش��ϴ� Resource ��ü ��ȯ
    private Resource GetResource(string resourceName)
    {
        return resources.Find(r => r.resourceName == resourceName);
    }
}

