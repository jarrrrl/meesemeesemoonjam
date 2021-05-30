using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFist : MonoBehaviour
{
    public float fireSpeed = 6f;
    public float fistDamage = 1f;
    public float gunUseTimer = 2f;
    public GameObject fistHitbox




    /*
     * Fires gun from the fire point which is the barrel of the gun
     */

    public void PunchFist()
    {
        fistHitbox.SetActive(true);
        StartCoroutine(GunUseTimer());
    }
    private IEnumerator GunUseTimer()
    {
        yield return new WaitForSeconds(gunUseTimer);

        fistHitbox.SetActive(false);
    }
}
