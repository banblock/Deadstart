using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    private List<GameObject> objPool = new List<GameObject>();

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

    public GameObject GetFXFromPool(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        foreach (GameObject obj in objPool) {
            if (!obj.activeInHierarchy) {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }

        // Ǯ�� ��Ȱ��ȭ�� ����ü�� ������ ���ο� ����ü ����
        GameObject newObj = Instantiate(gameObject, position, rotation, transform);
        objPool.Add(newObj);
        return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
