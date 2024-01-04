using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolManager : MonoBehaviour
{
    public static ProjectilePoolManager Instance { get; private set; }

    public GameObject projectilePrefab;

    private List<GameObject> projectilePool = new List<GameObject>();

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() { }

    public GameObject GetProjectileFromPool(Vector3 position, Quaternion rotation)
    {
        foreach (GameObject projectile in projectilePool) {
            if (!projectile.activeInHierarchy) {
                projectile.transform.position = position;
                projectile.transform.rotation = rotation;
                projectile.SetActive(true);
                return projectile;
            }
        }

        // Ǯ�� ��Ȱ��ȭ�� ����ü�� ������ ���ο� ����ü ����
        GameObject newProjectile = Instantiate(projectilePrefab, position, rotation, transform);
        projectilePool.Add(newProjectile);
        return newProjectile;
    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}
