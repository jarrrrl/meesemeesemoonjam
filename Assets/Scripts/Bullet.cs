using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private static float bulletVelocity = 20f;
    public static float BulletVelocity
    {
        get => bulletVelocity;
        set => bulletVelocity = value;
    }

    public static GameObject bulletHitEffect; //the sprite of when a bullet hits


    public Rigidbody2D rb; //2d collider box physics container

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * BulletVelocity;
    }
    /**
     * Whenever a bullet hits an object, it will create a hit effect, destroy the bullet, then
     * the hit effect after an amount of time
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            return;
        }
        
        Destroy(gameObject);
    }

}
