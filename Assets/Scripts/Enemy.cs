using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ** enemy variables
    private static float moveSpeed = 100f;
    private static float maxHealth = 3;
    private static float currenthealth;
    public static float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    public static float CurrentHealth
    {
        get => currenthealth;
        set => currenthealth = value;
    }
    public static float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
