using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiotShield : MonoBehaviour
{
    public GameObject playerBoundsTop;
    public GameObject playerBoundsBottom;
    public GameObject riotShield;
    private static float shieldCooldown = 3.5f;
    private static float shieldUseTime = 3f;
    public static float ShieldCooldown
    {
        get => shieldCooldown;
        set => shieldCooldown = value;
    }
    private void Update()
    {
        Physics2D.IgnoreCollision(playerBoundsTop.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(playerBoundsBottom.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());
    }

    /*
    * deploys shield from a "firepoint", a location on the playercharacter
    */
    public void DeployShield()
    {
        riotShield.SetActive(true);
        StartCoroutine(ShieldUseTimer());
    }

    private IEnumerator ShieldUseTimer()
    {
        yield return new WaitForSeconds(RiotShield.shieldUseTime);

        riotShield.SetActive(false);
    }

}
