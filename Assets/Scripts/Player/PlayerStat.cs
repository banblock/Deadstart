using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;

    // 각 스탯의 초기값 설정
    public float Health { 
        get { return currentHealth; } 
        set {
            if (value < 0) currentHealth = 0;
            else if (value > maxHealth) currentHealth = maxHealth;
            else currentHealth = value; 
        }
    }

    public float MaxHealth {
        get { return maxHealth; }
        private set { maxHealth = value; }
    }

    public float Attack { get; set; }
    public float AttackSpeed { get; set; }

    public float Speed {
        get { return speed; } 
        set {
            if (value < 0) speed = 0;
            else if (value > 10f) speed = 10f;
            else speed = value;
        }
    }

    public void InitializeStats() {
        MaxHealth = 100;
        Health = MaxHealth;
        Attack = 1;
        AttackSpeed = 1;
        Speed = 3f;
    }
    
}