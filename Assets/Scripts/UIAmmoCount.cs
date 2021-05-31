using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmoCount : MonoBehaviour
{
    public Player userCharacter;
    public Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = userCharacter.playerGun.ammoCount.ToString();

    }
}
