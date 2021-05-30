using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ** enemy variables
    public BattleRegion regionBelongTo;
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

    public void takeDamagePunch()
    {
        maxHealth--;
        if(maxHealth <= 0)
        {
            killEnemy();
        }
    }
    public void takeDamageGun()
    {
        maxHealth = maxHealth - 3;
        if(maxHealth <= 0)
        {
            killEnemy();
            regionBelongTo.numEnemies--;
            
        }
    }
    private void killEnemy()
    {

        Destroy(gameObject, 3f);
        //maybe switch to enemy on ground before destroyed?
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamageGun();
            GameObject hitEffectInstance = Instantiate(Bullet.bulletHitEffect, transform.position,
            Quaternion.identity);
            Destroy(hitEffectInstance, 2f);
            Destroy(collision);
            return;
        }
    }
}
