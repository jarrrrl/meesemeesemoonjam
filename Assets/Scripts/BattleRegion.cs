using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRegion : MonoBehaviour
{
    public BattleRegionTrigger locationTrigger;


    public Player playerCollider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && locationTrigger.hasTriggered == true)
        {
            //this means there are enemies left
            return;
        }
        //no enemies left - return camera to moving state, get player to move right
    }
}
