using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInfoUIContainer : MonoBehaviour
{
    [SerializeField]
    GameObject resourceInfoUIComponentPrefab;

    HorizontalLayoutGroup horizontalLayoutGroup;

    void Start()
    {
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    public void SetInitUI(List<Item> items) {
        Instantiate(resourceInfoUIComponentPrefab);

        foreach (Item item in items)
        {
            ResourceInfoUIComponent resourceInfoUIComponent = resourceInfoUIComponentPrefab.GetComponent<ResourceInfoUIComponent>();
            resourceInfoUIComponent.SetInitUI(item);
        }
    }
}
