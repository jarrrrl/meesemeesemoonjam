using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void KillEnemy()
    {
        AudioManager.instance.Play("oofLowerPitch");
        AudioManager.instance.StopPlaying("BossTheme");
        AudioManager.instance.Play("CityTheme");
        Destroy(gameObject);
        regionBelongTo.numEnemies--;
        regionBelongTo.AreEnemiesLeft();
        //end cutscene here
    }
}
