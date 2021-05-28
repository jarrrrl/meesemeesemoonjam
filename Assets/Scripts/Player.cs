using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Gun playerGun;

    private static float moveSpeed = 5f;

    public static float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerFireInput();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // gameover here
        }
    }


    /**
     * Player pressed the input for firing the gun, calls the gun's fire method
     */
    public void PlayerFireInput()
    {
        playerGun.IsCanFire();
    }
    
}
