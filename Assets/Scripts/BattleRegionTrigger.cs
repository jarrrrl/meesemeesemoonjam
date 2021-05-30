using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRegionTrigger : MonoBehaviour
{
    public bool hasTriggered;



    // Start is called before the first frame update
    void Start()
    {
        hasTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasTriggered == false)
        {
            hasTriggered = true;

            

        }

    }
}
