using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolManager : MonoBehaviour
{
    public static ProjectilePoolManager Instance { get; private set; }

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

    public GameObject GetProjectileFromPool(GameObject gameObject, Vector3 position, Quaternion rotation)
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
        GameObject newProjectile = Instantiate(gameObject, position, rotation, transform);
        newProjectile.name = gameObject.name;
        projectilePool.Add(newProjectile);
        return newProjectile;
    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}
