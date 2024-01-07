using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    public float detectionRadius = 10f; // ���� ���� ������
    public LayerMask enemyLayer; // �� ���̾�
    RaycastHit2D[] targets;


    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, detectionRadius, Vector2.zero, 0f, enemyLayer);
    }

    public Transform GetNearestTarget()
    {
        if (targets == null || targets.Length == 0) {
            return null; // ����� ���� ������ null ��ȯ
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
        // ������ �󿡼� ���� ������ ������ �ð������� ǥ��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
