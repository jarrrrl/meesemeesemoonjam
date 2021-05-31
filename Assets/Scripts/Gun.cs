using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint; //where the bullet is fired from
    public GameObject bulletPrefab;
    public GameObject gunObject;
    public float fireSpeed = 6f;
    public float gunDamage = 3f;
    public float gunUseTimer = 5f;


 

    /*
     * Fires gun from the fire point which is the barrel of the gun
     */

    public virtual void ShootGun()
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

