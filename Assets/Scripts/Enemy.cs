using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ** enemy variables

    public BattleRegion regionBelongTo;
    public GameObject playerBoundsTop;
    public GameObject playerBoundsBottom;
    public GameObject hitEffect;

    public float moveSpeed = 5f;
    public float maxHealth = 3;


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

    public void TakeDamageBaton()
    {
        maxHealth--;
        if(maxHealth <= 0)
        {
            KillEnemy();
        }
    }
    public void TakeDamageGun()
    {
        maxHealth -= 3;
        if(maxHealth <= 0)
        {
            KillEnemy();
        }
    }
    private void KillEnemy()
    {
        regionBelongTo.numEnemies--;
        regionBelongTo.AreEnemiesLeft();
        Destroy(gameObject);
        //maybe switch to enemy on ground before destroyed?
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            TakeDamageGun();
            GameObject hitEffectInstance = Instantiate(hitEffect, transform.position,
            Quaternion.identity);
            Destroy(hitEffectInstance, 2f);
            return;
        }
        if (collision.gameObject.CompareTag("PlayerBaton"))
        {
            TakeDamageBaton();
            GameObject hitEffectInstance = Instantiate(hitEffect, transform.position,
            Quaternion.identity);
            Destroy(hitEffectInstance, 2f);
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
