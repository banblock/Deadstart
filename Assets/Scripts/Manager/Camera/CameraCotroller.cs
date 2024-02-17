using UnityEngine;

/// <summary>
/// 카메라 컨트롤러
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform target; // 플레이어의 Transform을 연결

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        offset.z = -10;
    }


    void LateUpdate()
    {
        if (target != null) {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }
}

