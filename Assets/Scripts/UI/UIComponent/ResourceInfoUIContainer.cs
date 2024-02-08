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

        foreach (Item item in items)
        {
            GameObject resourceInfoUIComponentObject = Instantiate(resourceInfoUIComponentPrefab, transform);
            ResourceInfoUIComponent resourceInfoUIComponent = resourceInfoUIComponentObject.GetComponent<ResourceInfoUIComponent>();
            resourceInfoUIComponent.SetInitUI(item);
        }
    }
}
