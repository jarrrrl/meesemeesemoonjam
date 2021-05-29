using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint; //where the bullet is fired from
    public GameObject bulletPrefab;
    private static int ammoCount;
    private static float fireSpeed = 2f;


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
 

    /*
     * Fires gun from the fire point which is the barrel of the gun
     */

    public void ShootGun()
    {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

