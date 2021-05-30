using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BattleRegion : MonoBehaviour
{
    public BattleRegionTrigger locationTrigger;
    public BattleRegionBorder battleBorderLeft;
    public BattleRegionBorder battleBorderRight;
    public CameraController gameCameraController;
    public PolygonCollider2D battleRegionCameraArea;

    public Player playerCollider;
    private Transform regionCameraTransform;
    public int numEnemies = 4;
    public static int NumEnemies
    {
        get => NumEnemies;
        set => NumEnemies = value;
    }
    // Start is called before the first frame update
    void Start()
    {

        regionCameraTransform = gameCameraController.regionCamera.transform;
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

    }
    public void AreEnemiesLeft()
    {
        if (numEnemies == 0)
        {
            battleBorderRight.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("enemies gone");
            //give camera priority to the player camera again
            gameCameraController.SwitchPriority();

            //move locked camera and boundary box to the right
            regionCameraTransform.Translate(50, 0, 0);

            battleRegionCameraArea.transform.Translate(50, 0, 0);
        }
    }

}
