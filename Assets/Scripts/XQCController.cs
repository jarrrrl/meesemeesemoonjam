using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XQCController : EnemyController
{
    public GameObject maldingSign;
    public float maldingSignTimer = 1f;
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
        maldingSign.GetComponent<SpriteRenderer>().enabled = true;
        base.GunAttack();
        StartCoroutine(MaldingSignTimer());

    }
    private IEnumerator MaldingSignTimer()
    {
        yield return new WaitForSeconds(maldingSignTimer);

        maldingSign.GetComponent<SpriteRenderer>().enabled = false;

    }
}
