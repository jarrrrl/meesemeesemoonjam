using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baton : MonoBehaviour
{
    public GameObject playerIdleBaton;
    public GameObject playerUsedBaton;
    private static float batonCooldown = 0.5f;
    private static float batonUseTime = 0.5f;
    private static float batonDamage = 1f;
    public static float BatonDamage
    {
        get => batonDamage;
        set => batonDamage = value;
    }
    public static float BatonCooldown
    {
        get => batonCooldown;
        set => batonCooldown = value;
    }

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
        yield return new WaitForSeconds(Baton.batonUseTime);

        playerIdleBaton.SetActive(true);
        playerUsedBaton.SetActive(false);
    }
}
