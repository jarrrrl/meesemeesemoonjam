using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XQCController : EnemyController
{
    public GameObject maldingSign;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Rotate(Vector2 direction)
    {
        if (direction.x > 0)
        {
            enemyObject.transform.eulerAngles = Vector3.up;

        }
        else if (direction.x < 0)
        {
            enemyObject.transform.eulerAngles = Vector3.up * 180;

        }
    }
    public override void GunAttack()
    {
        if (direction.y <= 0.2f && direction.y >= -0.2f && canFire
            && (Vector2.Distance(playerObject.transform.position, transform.position) > 10f
            && canPunch))
        {
            enemyObject.moveSpeed -= 2f;
            enemyObject.GetComponent<SpriteRenderer>().sprite = gunSprite;
            enemyFist.GetComponent<Collider2D>().enabled = false;
            maldingSign.GetComponent<SpriteRenderer>().enabled = true;


            enemyGun.ShootGun();
            StartCoroutine(FireSpeedTimer());
        }
    }
    private IEnumerator FireSpeedTimer()
    {
        canFire = false;
        yield return new WaitForSeconds(enemyGun.fireSpeed);
        enemyObject.GetComponent<SpriteRenderer>().sprite = idleSprite;

        maldingSign.GetComponent<SpriteRenderer>().enabled = false;
        canFire = true;
        enemyObject.moveSpeed += 2f;
    }
}
