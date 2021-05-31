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
    public GameObject batonHitEffect;
    public Animator animator;

    public float moveSpeed = 5f;
    public float maxHealth = 3;


    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(playerBoundsTop.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(playerBoundsBottom.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());

        animator.SetFloat("Speed", GetComponent<Rigidbody2D>().angularVelocity);
    }

    public void TakeDamageBaton()
    {
        AudioManager.instance.Play("batonHitSound");
        maxHealth--;
        if(maxHealth <= 0)
        {
            KillEnemy();
        }
    }
    public void TakeDamageGun()
    {
        AudioManager.instance.Play("meatHitSound");
        maxHealth -= 3;
        if(maxHealth <= 0)
        {
            KillEnemy();
        }
    }
    public virtual void KillEnemy()
    {
        AudioManager.instance.Play("oofLowerPitch");
        Destroy(gameObject);
        regionBelongTo.numEnemies--;
        regionBelongTo.AreEnemiesLeft();
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
            GameObject hitEffectInstance = Instantiate(batonHitEffect, transform.position,
            Quaternion.identity);
            Destroy(hitEffectInstance, 2f);
            return;
        }
    }

}
