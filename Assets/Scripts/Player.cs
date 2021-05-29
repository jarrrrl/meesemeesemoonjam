using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Gun playerGun;
    public RiotShield playerShield;

    private bool canFire = true;
    private bool canShield = true;

    private static float moveSpeed = 25f;

    public static float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && (canShield))
        {
            PlayerFireInput();
        }
        else if (Input.GetButton("Fire2") && (!Input.GetButton("Fire1")))
        {
            PlayerShieldInput();
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
     * Player pressed the input for firing the gun, calls the gun's fire method
     */
    public void PlayerFireInput()
    {
        if (!canFire)
        {
            return;
        }
        playerGun.ShootGun();
        StartCoroutine(FireSpeedTimer());
    }

    public void PlayerShieldInput()
    {
        if (!canShield)
        {
            return;
        }
        playerShield.DeployShield();
        StartCoroutine(ShieldSpeedTimer());
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
    private IEnumerator ShieldSpeedTimer()
    {
        canShield = false;

        yield return new WaitForSeconds(RiotShield.ShieldCooldown);

        canShield = true;
    }
}
