using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 스크립터블 오브젝트를 등록하고 반환합니다.
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
