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
        // 투사체 생성 및 사용 예시
        if (Input.GetKeyDown(KeyCode.Space)) {
            // 풀에서 투사체 가져와서 활성화
            GameObject newProjectile = projectilePool.GetProjectileFromPool(transform.position, transform.rotation);
            // 투사체 사용 후 로직 수행
        }
    }
}
