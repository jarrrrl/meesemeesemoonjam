using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossController : XQCController
{
    public Gun mouthGun;
    public Sprite mouthLaserSprite;
    public int numEyeLasers = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void GunAttack()
    {
        if (direction.y <= 0.2f && direction.y >= -0.2f && canFire
            && (Vector2.Distance(playerObject.transform.position, transform.position) > 6f))
        {
            maldingSign.GetComponent<SpriteRenderer>().enabled = true;
            enemyObject.moveSpeed -= 2f;
            if (numEyeLasers < 3) {
                enemyObject.GetComponent<SpriteRenderer>().sprite = gunSprite;
                enemyGun.ShootGun();
                numEyeLasers++;
            }
            else
            {
                enemyObject.GetComponent<SpriteRenderer>().sprite = mouthLaserSprite;
                mouthGun.ShootGun();
                enemyObject.GetComponent<SpriteRenderer>().sprite = idleSprite;

                numEyeLasers = 0;
            }
            StartCoroutine(FireSpeedTimer());
        }
    }
    public override void PunchAttack()
    {
     return;
    }
    public override void MoveCharacter(Vector2 direction)
    {
        if((Vector2.Distance(playerObject.transform.position, transform.position)) > 10f)
        rb.MovePosition((Vector2)enemyObject.transform.position +
          (direction * enemyObject.moveSpeed * Time.deltaTime));
    }
    private IEnumerator FireSpeedTimer()
    {
        canFire = false;
        yield return new WaitForSeconds(enemyGun.fireSpeed);
        enemyObject.GetComponent<SpriteRenderer>().sprite = idleSprite;

        maldingSign.GetComponent<SpriteRenderer>().enabled = false;
        AudioManager.instance.Play("finalBossLaughSound");

        canFire = true;
        enemyObject.moveSpeed += 2f;
    }
}
