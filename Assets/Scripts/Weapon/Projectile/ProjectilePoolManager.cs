using System;
using System.Collections.Generic;
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

    public GameObject GetProjectileFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        Type projectileComponentType = prefab.GetComponent<Projectile>().GetType();

        if (projectileComponentType == null) {
            // 예외 처리 또는 적절한 대응
            Debug.LogError("Projectile component type is null for prefab: " + prefab.name);
            return null;
        }

        //이미 등록된 projectileType이라면 값을 반환
        int poolNumber;
        if(!projectileType.TryGetValue(projectileComponentType, out poolNumber)) {
            //만약 존재하지 않는다면 projectileType에 등록
            poolNumber = projectilePool.Count;
            projectileType.Add(projectileComponentType, poolNumber);
            projectilePool.Add(new List<GameObject>());

            // 풀이 초기화되지 않았다면 초기화
            if (poolNumber >= projectilePool.Count) {
                projectilePool.Add(new List<GameObject>());
            }
            Debug.Log("총알 등록");
        }

        

        foreach (GameObject projectile in projectilePool[poolNumber]) {
            if (projectile != null && !projectile.activeInHierarchy) {
                projectile.transform.position = position;
                projectile.transform.rotation = rotation;
                Debug.Log("총알 생성");
                projectile.SetActive(true);
                return projectile;
            }
        }

        // 풀에 비활성화된 투사체가 없으면 새로운 투사체 생성
        GameObject newProjectile = Instantiate(prefab, position, rotation, transform);
        newProjectile.name = prefab.name;
        projectilePool[poolNumber].Add(newProjectile);
        Debug.Log("총알 생성");
        return newProjectile;

    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}
