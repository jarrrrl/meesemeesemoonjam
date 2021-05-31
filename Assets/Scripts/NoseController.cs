using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseController : EnemyController
{
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
}
