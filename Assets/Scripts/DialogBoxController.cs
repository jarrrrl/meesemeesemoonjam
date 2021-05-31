using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogTextBackground;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableBox()
    {
        dialogTextBackground.SetActive(false);
    }
    public void EnableBox()
    {
        dialogTextBackground.SetActive(true);

    }
}
