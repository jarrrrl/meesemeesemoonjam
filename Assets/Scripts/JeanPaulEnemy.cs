using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanPaulEnemy : Enemy
{
    public override void KillEnemy()
    {
        AudioManager.instance.Play("oofLowerPitch");
        AudioManager.instance.StopPlaying("bossTheme");
        AudioManager.instance.Play("cityTheme");
        Destroy(gameObject);
        regionBelongTo.numEnemies--;
        regionBelongTo.AreEnemiesLeft();
        //maybe switch to enemy on ground before destroyed?
    }
}
