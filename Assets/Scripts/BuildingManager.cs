using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject objectPrefab; // 배치할 오브젝트 프리팹
    public Vector2 gridSize = new Vector2(1f, 1f); // 그리드 크기

    private GameObject guideObject; // 가이드용 오브젝트

    void Update()
    {
        // 마우스 클릭 지점의 월드 좌표를 가져오기
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // 가이드용 오브젝트가 없으면 생성
        if (guideObject == null)
        {
            guideObject = Instantiate(objectPrefab, mousePos, Quaternion.identity);
            guideObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.5f); // 반투명하게 설정
        }

        // 그리드에 맞게 위치 조정
        Vector3 snappedPos = SnapToGrid(mousePos);

        // 가이드 오브젝트 위치 설정
        guideObject.transform.position = snappedPos;

        // 마우스 왼쪽 버튼이 클릭되었을 때 오브젝트 생성
        if (Input.GetMouseButtonDown(0))
        {
            // 오브젝트 생성 및 위치 설정
            GameObject placedObject = Instantiate(objectPrefab, snappedPos, Quaternion.identity);
            Destroy(guideObject); // 가이드 오브젝트 삭제
        }
    }

    Vector3 SnapToGrid(Vector3 position)
    {
        // 그리드 크기에 따라 위치 조정
        float snappedX = Mathf.Round(position.x / gridSize.x) * gridSize.x;
        float snappedY = Mathf.Round(position.y / gridSize.y) * gridSize.y;

        // 새로운 위치 반환
        return new Vector3(snappedX, snappedY, 0f);
    }
}
