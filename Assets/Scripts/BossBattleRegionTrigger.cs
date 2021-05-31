using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleRegionTrigger : BattleRegionTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasTriggered == false)
        {
            gameCameraController.SwitchPriority();
            AudioManager.instance.StopPlaying("CityTheme");
            AudioManager.instance.StopPlaying("PlaneswalkerTheme");
            AudioManager.instance.Play("BossTheme");
            hasTriggered = true;

        }




    }
}
