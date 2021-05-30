using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ** sprites
    public Sprite idleSprite;
    public Sprite gunSprite;
    public Sprite normalSprite;

    //

    // **weapons
    public PlayerGun playerGun;
    public RiotShield playerShield;
    public Baton playerBaton;

    private bool canFire = true;
    private bool canShield = true;
    private bool canBaton = true;
    //
    // ** player variables
    private static float moveSpeed = 15f;

    public static float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }


    //

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canShield && !Input.GetKey(KeyCode.E))
        {
            PlayerFireInput();
        }
        else if (Input.GetButton("Fire2") && (!Input.GetButton("Fire1")) &&
            !Input.GetKey(KeyCode.E))
        {
            PlayerShieldInput();
        }
        else if (Input.GetKey(KeyCode.E) && (!Input.GetButton("Fire1")) && canShield
            && canFire)
        {
            PlayerBatonInput();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider,
            GetComponent<Collider2D>());

            Debug.Log(collision.collider);

            // ignore
        }
        if (collision.gameObject.CompareTag("EnemyHand") || 
            collision.gameObject.CompareTag("EnemyBullet"))
        {
            //die
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
        this.GetComponent<SpriteRenderer>().sprite = gunSprite;
        playerBaton.transform.gameObject.SetActive(false);

        playerGun.ShootGun();
        StartCoroutine(FireSpeedTimer());
    }

    public void PlayerShieldInput()
    {
        if (!canShield)
        {
            return;
        }
        playerGun.transform.gameObject.SetActive(false);
        this.GetComponent<SpriteRenderer>().sprite = normalSprite;
        playerBaton.transform.gameObject.SetActive(false);
        playerShield.DeployShield();
        StartCoroutine(ShieldCooldownTimer());
    }
    public void PlayerBatonInput()
    {
        if (!canBaton)
        {
            return;
        }
        playerGun.transform.gameObject.SetActive(false);
        this.GetComponent<SpriteRenderer>().sprite = gunSprite;
        playerBaton.DeployBaton();
        StartCoroutine(BatonCooldownTimer());
    }

    /**
     * Counter for the time between shots fired, so that you can't just spam click / fire
     * super fast
     */
    private IEnumerator FireSpeedTimer()
    {
        canFire = false;

        yield return new WaitForSeconds(playerGun.fireSpeed);
        playerBaton.transform.gameObject.SetActive(true);
        this.GetComponent<SpriteRenderer>().sprite = normalSprite;


        canFire = true;
    }
    private IEnumerator ShieldCooldownTimer()
    {
        canShield = false;

        yield return new WaitForSeconds(playerShield.shieldCooldown);
        playerBaton.transform.gameObject.SetActive(true);


        canShield = true;
    }
    private IEnumerator BatonCooldownTimer()
    {
        canBaton = false;

        yield return new WaitForSeconds(playerBaton.batonCooldown);
        this.GetComponent<SpriteRenderer>().sprite = normalSprite;
        canBaton = true;
    }


}
