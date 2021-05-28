using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private static float bulletVelocity = 5f;

    public static float BulletVelocity
    {
        get => bulletVelocity;
        set => bulletVelocity = value;
    }

    public GameObject bulletHitEffect; //the sprite of when a bullet hits


    private Rigidbody2D bulletPhysics; //2d collider box physics container
    public GameObject bulletObject; //entire object of bullet
    public Transform firePoint; //where the bullet is fired from
    private Vector2 currentBulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        bulletPhysics = GetComponent<Rigidbody2D>();
    }
    /**
     * Whenever a bullet hits an object, it will create a hit effect, destroy the bullet, then
     * the hit effect after an amount of time
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitEffectInstance = Instantiate(bulletHitEffect, transform.position, 
            Quaternion.identity);
        Destroy(bulletHitEffect, 5f);
        Destroy(gameObject);
    }

     private static void ShootGun()
    {
        GameObject bulletInstance = Instantiate(bulletObject, firePoint.position, firePoint.rotation);
        bulletPhysics = bulletInstance.GetComponent<Rigidbody2D>();

        bulletPhysics.AddForce(firePoint.up * BulletVelocity, ForceMode2D.Impulse);
        currentBulletVelocity = bulletPhysics.velocity;
    }
}
