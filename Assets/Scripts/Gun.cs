using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private static int ammoCount;
    private static float fireSpeed;

    public static int AmmoCount
    {
        get => ammoCount;
        set => ammoCount = value;
    }

    public static float FireSpeed
    {
        get => fireSpeed;
        set => fireSpeed = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
