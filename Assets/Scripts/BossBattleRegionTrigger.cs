using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            DialogBoxController dialog = FindObjectOfType<DialogBoxController>();
            if (dialog)
            {
                dialog.dialogText.text = "";
                dialog.DisableBox();
            }

            gameCameraController.SwitchPriority();
            AudioManager.instance.StopPlaying("CityTheme");
            AudioManager.instance.StopPlaying("PlaneswalkerTheme");
            AudioManager.instance.Play("BossTheme");
            hasTriggered = true;
            Debug.Log(hasTriggered);

        }




    }
}
