using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectsManager : MonoBehaviour
{
    public static ScriptableObjectsManager Instance { private set; get; }


    private void Awake()
    {
        // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫ º≥¡§
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

}
