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
            // ���� ó�� �Ǵ� ������ ����
            Debug.LogError("Projectile component type is null for prefab: " + prefab.name);
            return null;
        }

        //�̹� ��ϵ� projectileType�̶�� ���� ��ȯ
        int poolNumber;
        if(!projectileType.TryGetValue(projectileComponentType, out poolNumber)) {
            //���� �������� �ʴ´ٸ� projectileType�� ���
            poolNumber = projectilePool.Count;
            projectileType.Add(projectileComponentType, poolNumber);
            projectilePool.Add(new List<GameObject>());

            // Ǯ�� �ʱ�ȭ���� �ʾҴٸ� �ʱ�ȭ
            if (poolNumber >= projectilePool.Count) {
                projectilePool.Add(new List<GameObject>());
            }
            Debug.Log("�Ѿ� ���");
        }

        

        foreach (GameObject projectile in projectilePool[poolNumber]) {
            if (projectile != null && !projectile.activeInHierarchy) {
                projectile.transform.position = position;
                projectile.transform.rotation = rotation;
                Debug.Log("�Ѿ� ����");
                projectile.SetActive(true);
                return projectile;
            }
        }

        // Ǯ�� ��Ȱ��ȭ�� ����ü�� ������ ���ο� ����ü ����
        GameObject newProjectile = Instantiate(prefab, position, rotation, transform);
        newProjectile.name = prefab.name;
        projectilePool[poolNumber].Add(newProjectile);
        Debug.Log("�Ѿ� ����");
        return newProjectile;

    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}
