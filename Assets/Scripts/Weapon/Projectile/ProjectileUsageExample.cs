using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUsageExample : MonoBehaviour
{
    public ProjectilePoolManager projectilePool;

    void Start()
    {
        projectilePool = GetComponent<ProjectilePoolManager>();
    }

    void Update()
    {
        // ����ü ���� �� ��� ����
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Ǯ���� ����ü �����ͼ� Ȱ��ȭ
            GameObject newProjectile = projectilePool.GetProjectileFromPool(transform.position, transform.rotation);
            // ����ü ��� �� ���� ����
        }
    }
}
