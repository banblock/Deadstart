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
    /// 발사체를 Pool에서 가져옵니다.
    /// </summary>
    /// <param name="prefab">발사체 프리펩</param>
    /// <param name="position">위치</param>
    /// <param name="rotation">회전율</param>
    /// <returns> 발사체 오브젝트 </returns>
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
    /// 발사체 오브젝트를 Pool에 반환 합니다.
    /// </summary>
    /// <param name="projectile"></param>
    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }



    /// <summary>
    /// private 메서드
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
