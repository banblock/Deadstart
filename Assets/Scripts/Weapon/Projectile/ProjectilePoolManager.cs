using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class ProjectilePoolManager : MonoBehaviour
{
    public static ProjectilePoolManager Instance { get; private set; }

    private Dictionary<Type, int> projectileType = new Dictionary<Type, int>();
    private List<List<GameObject>> projectilePool = new List<List<GameObject>>();

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// �߻�ü�� Pool���� �����ɴϴ�.
    /// </summary>
    /// <param name="prefab">�߻�ü ������</param>
    /// <param name="position">��ġ</param>
    /// <param name="rotation">ȸ����</param>
    /// <returns> �߻�ü ������Ʈ </returns>
    public GameObject GetProjectileFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        Type projectileComponentType = prefab.GetComponent<Projectile>()?.GetType();

        if (projectileComponentType == null) {
            Debug.LogError("Projectile component type is null for prefab: " + prefab.name);
            return null;
        }

        if (!projectileType.TryGetValue(projectileComponentType, out int poolNumber)) {
            poolNumber = projectilePool.Count;
            projectileType.Add(projectileComponentType, poolNumber);
        }

        List<GameObject> selectedPool = GetOrCreateProjectilePool(poolNumber);
        GameObject projectile = selectedPool.Find(projectile => projectile != null && !projectile.activeInHierarchy);

        if (projectile == null) {
            projectile = CreateNewProjectile(prefab, position, rotation, poolNumber);
        }
        else {
            SetProjectileTransform(projectile, position, rotation);
        }

        return projectile;
    }

    /// <summary>
    /// �߻�ü ������Ʈ�� Pool�� ��ȯ �մϴ�.
    /// </summary>
    /// <param name="projectile"></param>
    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }



    /// <summary>
    /// private �޼���
    private List<GameObject> GetOrCreateProjectilePool(int poolNumber)
    {
        if (poolNumber >= projectilePool.Count) {
            projectilePool.Add(new List<GameObject>());
        }
        return projectilePool[poolNumber];
    }


    private GameObject CreateNewProjectile(GameObject prefab, Vector3 position, Quaternion rotation, int poolNumber)
    {
        GameObject newProjectile = Instantiate(prefab, position, rotation, transform);
        newProjectile.name = prefab.name;
        projectilePool[poolNumber].Add(newProjectile);
        return newProjectile;
    }

    private void SetProjectileTransform(GameObject projectile, Vector3 position, Quaternion rotation)
    {
        projectile.transform.position = position;
        projectile.transform.rotation = rotation;
        projectile.SetActive(true);
    }
}
