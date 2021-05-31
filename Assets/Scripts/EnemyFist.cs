using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFist : MonoBehaviour
{
    public float fireSpeed = 6f;
    public float fistDamage = 1f;
    public float fistUseTimer = 2f;
    public GameObject fistHitbox;




    /*
     * enables punch hitbox for short time
     */

    public void PunchFist()
    {
        fistHitbox.GetComponent<Collider2D>().enabled = true;
        StartCoroutine(FistUseTimer());
    }
    private IEnumerator FistUseTimer()
    {
        yield return new WaitForSeconds(fistUseTimer);

        fistHitbox.GetComponent<Collider2D>().enabled = false;
    }
}
