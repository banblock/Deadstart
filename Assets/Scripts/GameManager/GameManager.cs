using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 전체적인 게임 시스템 관리
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    void Awake()
    {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }

        if(WeaponManager.Instance == null) {
            this.AddComponent<WeaponManager>();
        }
        if (ActionManager.Instance == null) {
            this.AddComponent<ActionManager>();
        }
    }

}
