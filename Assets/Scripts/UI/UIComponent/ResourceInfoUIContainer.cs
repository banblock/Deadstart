using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

/// <summary>
/// 필요 자원양을 출력하는 UI 컨테이너
/// </summary>
public class ResourceInfoUIContainer : MonoBehaviour
{
    [SerializeField]
    GameObject resourceInfoUIComponentPrefab;

    List<ResourceInfoUIComponent> resourceList = new List<ResourceInfoUIComponent>();


    /// <summary>
    /// 아이템 리스트를 설정하면 디스플레이 합니다
    /// </summary>
    /// <param name="items"> 필요 아이템 리스트 </param>
    public void SetInitUI(List<Item> items)
    {
        // items의 List 크기에 맞춰 resourceInfoUIComponentPrefab을 생성합니다.
        // 만약 이미 있다면 정보만 수정합니다.
        int itemCount = items.Count;
        int existingResourceCount = resourceList.Count;

        // 필요한 아이템의 수와 현재 UI 컴포넌트의 수를 비교하여 필요한 수를 만들어냅니다.
        int requiredResourceCount = Mathf.Max(itemCount, existingResourceCount);

        for (int index = 0; index < requiredResourceCount; index++) {
            ResourceInfoUIComponent resourceInfoUIComponent;

            // 인덱스가 기존 리소스 리스트의 범위를 벗어나거나 해당 인덱스의 UI 컴포넌트가 null인 경우
            if (index >= existingResourceCount || resourceList[index] == null) {
                // 새로운 UI 컴포넌트를 생성하고 리스트에 추가합니다.
                
                GameObject obj = Instantiate(resourceInfoUIComponentPrefab, transform);
                resourceInfoUIComponent = obj.GetComponent<ResourceInfoUIComponent>();
                resourceList.Add(resourceInfoUIComponent);
            }
            else {
                // 기존의 UI 컴포넌트를 재사용합니다.
                resourceInfoUIComponent = resourceList[index];
            }

            // 아이템 리스트의 크기가 현재 인덱스를 초과하는 경우가 있을 수 있으므로 체크합니다.
            if (index < itemCount) {
                resourceInfoUIComponent.gameObject.SetActive(true); // UI를 활성화합니다.
                resourceInfoUIComponent.SetInitUI(items[index]);
            }
            else {
                resourceInfoUIComponent.gameObject.SetActive(false); // UI를 비활성화합니다.
            }
        }
    }

}
