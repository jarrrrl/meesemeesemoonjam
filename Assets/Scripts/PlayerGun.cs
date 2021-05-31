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
            AudioManager.instance.Play("gunShotSound");
            StartCoroutine(GunUseTimer());
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            AudioManager.instance.Play("noAmmoSound");
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
