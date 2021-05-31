using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun
{
    public int ammoCount = 5;

    private void Reset()
    {
        fireSpeed = 2f;
        gunUseTimer = 2f;
    }
    public override void ShootGun()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            gunObject.SetActive(true);
            StartCoroutine(GunUseTimer());
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            //out of ammo
            return;
        }
    }
    private IEnumerator GunUseTimer()
    {
        yield return new WaitForSeconds(gunUseTimer);

        gunObject.SetActive(false);
    }
}
