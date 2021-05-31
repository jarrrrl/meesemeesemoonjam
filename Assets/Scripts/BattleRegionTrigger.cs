using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRegionTrigger : MonoBehaviour
{
    public bool hasTriggered;
    public CameraController gameCameraController;


    // Start is called before the first frame update
    void Start()
    {
        hasTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasTriggered == false)
        {
            gameCameraController.SwitchPriority();
            hasTriggered = true;


        }

    }
}
