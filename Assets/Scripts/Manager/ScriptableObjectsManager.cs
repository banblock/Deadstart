using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ��ũ���ͺ� ������Ʈ�� ����ϰ� ��ȯ�մϴ�.
/// </summary>
public class ScriptableObjectsManager : MonoBehaviour
{
    public static ScriptableObjectsManager Instance { private set; get; }

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

}
