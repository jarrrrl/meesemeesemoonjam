using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletVelocity = 20f;


    public Rigidbody2D rb; //2d collider box physics container

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletVelocity;
    }
    private void Update()
    {
        
    }
    /**
     * Whenever a bullet hits an object, it will create a hit effect, destroy the bullet, then
     * the hit effect after an amount of time
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Physics2D.IgnoreCollision(collision.collider,
                GetComponent<Collider2D>());
            return;
        }
        AudioManager.instance.Play("blockSound");
        Destroy(gameObject);
    }

}
