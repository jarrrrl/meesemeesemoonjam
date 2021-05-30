using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint; //where the bullet is fired from
    public GameObject bulletPrefab;
    public GameObject gunObject;
    private static int ammoCount;
    private static float fireSpeed = 2f;
    private static float gunDamage = 3f;
    public static float gunUseTimer = 2f;
    public static float GunDamage
    {
        get => gunDamage;
        set => gunDamage = value;
    }

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
        gunObject.SetActive(true);
        StartCoroutine(GunUseTimer());
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    private IEnumerator GunUseTimer()
    {
        yield return new WaitForSeconds(gunUseTimer);

        gunObject.SetActive(false);
    }
}

