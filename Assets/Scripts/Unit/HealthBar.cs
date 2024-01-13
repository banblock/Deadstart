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
    }

    void Update()
    {
        // 유닛의 위치를 따라다니도록 HP 바를 이동
        if (unitTransform != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(unitTransform.position);
            healthSlider.transform.position = new Vector3(screenPos.x, screenPos.y + 50f, screenPos.z);
        }
    }

    public void UpdateHealth(float healthPercentage)
    {
        // HP 업데이트 함수
        healthSlider.value = healthPercentage;
    }
}
