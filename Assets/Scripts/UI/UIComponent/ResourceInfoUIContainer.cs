using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 필요 자원양을 출력하는 UI 컨테이너
/// </summary>
public class ResourceInfoUIContainer : MonoBehaviour
{
    [SerializeField]
    GameObject resourceInfoUIComponentPrefab;

    HorizontalLayoutGroup horizontalLayoutGroup;

    void Start()
    {
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    /// <summary>
    /// 아이템 리스트를 설정하면 디스플레이 합니다
    /// </summary>
    /// <param name="items"> 필요 아이템 리스트 </param>
    public void SetInitUI(List<Item> items) {

        foreach (Item item in items)
        {
            GameObject resourceInfoUIComponentObject = Instantiate(resourceInfoUIComponentPrefab, transform);
            ResourceInfoUIComponent resourceInfoUIComponent = resourceInfoUIComponentObject.GetComponent<ResourceInfoUIComponent>();
            resourceInfoUIComponent.SetInitUI(item);
        }
    }
}
