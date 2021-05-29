using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun
{

    private static float gunUseTimer = 2f;

    public void ShootGun()
    {
        gunObject.SetActive(true);
        StartCoroutine(GunUseTimer());
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


    private IEnumerator GunUseTimer()
    {
        yield return new WaitForSeconds(PlayerGun.gunUseTimer);

        gunObject.SetActive(false);
    }
}
