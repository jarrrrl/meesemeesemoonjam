using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static float moveSpeed = 5f;

    public static float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    private bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!canFire)
            {
                return;
            }
            ShootGun();
            StartCoroutine(Reload());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // gameover here
        }
    }
    /**
     * Counter for the time between shots fired, so that you can't just spam click / fire
     * super fast
     */
    private IEnumerator FireSpeedTimer()
    {
        canFire = false;

        yield return new WaitForSeconds(Gun.FireSpeed);

        canFire = true;
    }

    public static void ShootGun
    {

    }
    
}
