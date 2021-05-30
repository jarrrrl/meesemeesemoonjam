using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRegion : MonoBehaviour
{
    public BattleRegionTrigger locationTrigger;
    public BattleRegionBorder battleBorderLeft;
    public BattleRegionBorder battleBorderRight;

    public Player playerCollider;
    private int numEnemies = 4;
    public static int NumEnemies
    {
        get => NumEnemies;
        set => NumEnemies = value;
    }
    private bool areEnemies = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //battle area activate - set enemies to active state and lock camera and
        //activate boundaries for area
        if (locationTrigger.hasTriggered)
        {
            battleBorderLeft.GetComponent<BoxCollider2D>().enabled = true;
            battleBorderRight.GetComponent<BoxCollider2D>().enabled = true;
        }
        if(numEnemies == 0)
        {
            areEnemies = false;
        }
        if (!areEnemies)
        {
            battleBorderLeft.GetComponent<BoxCollider2D>().enabled = false;
            battleBorderRight.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("enemies gone");
            //make camera return to follow player

        }

    }


}
