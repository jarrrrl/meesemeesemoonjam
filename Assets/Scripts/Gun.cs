using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bulletPrefab;
    private static int ammoCount;
    private static float fireSpeed = 2f;
    public Transform firePoint; //where the bullet is fired from
    public Transform playerTransform; // the player's location



 

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

    /*
     * Checks if the gun is able to fire, calls the bulletscript to create a bullet instantiation
     * if canFire is true
     */

    public void ShootGun()
    {
        Debug.Log(playerTransform.position);
        firePoint.position = firePoint.position + playerTransform.position;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

