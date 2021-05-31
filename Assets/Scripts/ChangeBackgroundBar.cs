using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundBar : MonoBehaviour
{
    public Image evilBackground;
    public Image goodBackground;
    // Start is called before the first frame update
    public void ChangeBackground()
    {
        goodBackground.enabled = false;
        evilBackground.enabled = true;
    }
}
