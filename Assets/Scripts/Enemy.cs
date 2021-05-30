using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ** enemy variables

    public BattleRegion regionBelongTo;
    public GameObject playerBoundsTop;
    public GameObject playerBoundsBottom;


    public float moveSpeed = 5f;
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(playerBoundsTop.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(playerBoundsBottom.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());
    }

    public void TakeDamagePunch()
    {
        maxHealth--;
        if(maxHealth <= 0)
        {
            KillEnemy();
        }
    }
    public void TakeDamageGun()
    {
        maxHealth = maxHealth - 3;
        if(maxHealth <= 0)
        {
            KillEnemy();
            regionBelongTo.numEnemies--;
            regionBelongTo.AreEnemiesLeft();
            
        }
    }
    private void KillEnemy()
    {

        Destroy(gameObject);
        //maybe switch to enemy on ground before destroyed?
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            TakeDamageGun();
            GameObject hitEffectInstance = Instantiate(Bullet.bulletHitEffect, transform.position,
            Quaternion.identity);
            Destroy(hitEffectInstance, 2f);
            return;
        }
    }

}
