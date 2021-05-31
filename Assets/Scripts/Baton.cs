using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baton : MonoBehaviour
{
    public GameObject playerIdleBaton;
    public GameObject playerUsedBaton;
    public float batonCooldown = 0.5f;
    public float batonUseTime = 3f;
    public float batonDamage = 1f;

    /*
    * deploys shield from a "firepoint", a location on the playercharacter
    */
    public void DeployBaton()
    {
        playerIdleBaton.SetActive(false);
        playerUsedBaton.SetActive(true);
        StartCoroutine(BatonUseTimer());
    }

    private IEnumerator BatonUseTimer()
    {
        yield return new WaitForSeconds(batonUseTime);

        playerIdleBaton.SetActive(true);
        playerUsedBaton.SetActive(false);
    }
}
