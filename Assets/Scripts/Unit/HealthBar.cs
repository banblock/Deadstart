using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Unity UI Slider를 사용하여 HP를 표시
    public Transform unitTransform; // 유닛의 Transform을 저장

    void Start()
    {
    // 슬라이더 초기화
    healthSlider = Instantiate(healthSlider, transform);
    healthSlider.value = 1f; // 초기 HP를 1로 설정

    // unitTransform 초기화
    GameObject unitObject = GameObject.FindGameObjectWithTag("Player"); // "Player" 태그에 대한 유닛을 찾아옴
    if (unitObject != null)
    {
        unitTransform = unitObject.transform;
    }
    else
    {
        Debug.LogError("Player not found! Make sure your player object has the 'Player' tag.");
    }
    }

    void Update()
    {
    // 유닛의 위치를 따라다니도록 HP 바를 이동
    if (unitTransform != null)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(unitTransform.position);
        healthSlider.transform.position = new Vector3(screenPos.x, screenPos.y + 50f, screenPos.z);
    }
    else
    {
        Debug.LogWarning("Unit transform is null. Make sure it is assigned.");
    }
    }

/// <summary>
/// 체력을 최신으로 유지
/// </summary>
/// <param name="healthPercentage"></param>
    public void UpdateHealth(float healthPercentage)
    {
        // HP 업데이트 함수
        healthSlider.value = healthPercentage;
    }
}
