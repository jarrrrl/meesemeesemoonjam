using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundBar : MonoBehaviour
{
    public Image evilBackground;
    public Image goodBackground;
    public bool backgroundChanged = false;
    // Start is called before the first frame update
    public void ChangeBackground()
    {
        if (backgroundChanged == false)
        {
            goodBackground.enabled = false;
            evilBackground.enabled = true;
            AudioManager.instance.StopPlaying("CityTheme");
            AudioManager.instance.Play("PlaneswalkerTheme");
        }
    }
}
