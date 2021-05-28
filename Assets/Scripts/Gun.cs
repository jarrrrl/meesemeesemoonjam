using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private static int ammoCount;
    private static float fireSpeed;

    private bool canFire = true;

 

    public static int AmmoCount
    {
        get => ammoCount;
        set => ammoCount = value;
    }

    public static float FireSpeed
    {
        get => fireSpeed;
        set => fireSpeed = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    /*
     * Checks if the gun is able to fire, calls the bulletscript to create a bullet instantiation
     * if canFire is true
     */
    public static void IsCanFire()
    {
        if (!canFire)
        {
            return;
        }
        Bullet.ShootGun();
        StartCoroutine(FireSpeedTimer());
    }

}

