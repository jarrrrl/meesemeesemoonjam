using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanPaulEnemy : Enemy
{
    public override void KillEnemy()
    {
        AudioManager.instance.Play("oofLowerPitch");
        AudioManager.instance.StopPlaying("BossTheme");
        AudioManager.instance.Play("CityTheme");
        Destroy(gameObject);
        regionBelongTo.numEnemies--;
        regionBelongTo.AreEnemiesLeft();
    }
}
