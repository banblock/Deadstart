using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    public float detectionRadius = 10f; // 감지 범위 반지름
    public LayerMask enemyLayer; // 적 레이어
    RaycastHit2D[] targets;


    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, detectionRadius, Vector2.zero, 0f, enemyLayer);
    }

    public Transform GetNearestTarget()
    {
        if (targets == null || targets.Length == 0) {
            return null; // 검출된 적이 없으면 null 반환
        }

        Transform nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (RaycastHit2D targetHit in targets) {
            Transform targetTransform = targetHit.collider.transform;
            float distance = Vector3.Distance(transform.position, targetTransform.position);

            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestTarget = targetTransform;
            }
        }

        return nearestTarget;
    }

    void OnDrawGizmosSelected()
    {
        // 에디터 상에서 감지 범위를 원으로 시각적으로 표시
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
