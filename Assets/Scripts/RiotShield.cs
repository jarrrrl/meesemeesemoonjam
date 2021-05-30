using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiotShield : MonoBehaviour
{
    public GameObject playerBoundsTop;
    public GameObject playerBoundsBottom;
    public GameObject riotShield;
    public GameObject hitEffect;
    public float shieldCooldown = 3.5f;
    private static float shieldUseTime = 3f;
    public RaycastHit2D firstHit;
    public LayerMask layer;
    public bool playerShielded = false;

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
        playerShielded = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("EnemyHand") || 
            collider.gameObject.CompareTag("EnemyBullet"))
        {
            firstHit = Physics2D.Linecast(collider.gameObject.transform.position,
                gameObject.transform.position, layer);
            //block
            if (firstHit.collider.gameObject.CompareTag("Shield"))
            {
                GameObject hitEffectInstance = Instantiate(hitEffect, 
                    transform.position, Quaternion.identity);
                Destroy(hitEffectInstance, 2f);
                playerShielded = true;
                collider.enabled = false;
            }
        }
    }
}
