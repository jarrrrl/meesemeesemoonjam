using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    private float playerMoveSpeed = Player.MoveSpeed;

    private Vector2 movementInput;
    // Update is called once per frame
    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal") * playerMoveSpeed;
        movementInput.y = Input.GetAxisRaw("Vertical") * playerMoveSpeed / 4;
        Rotate();

    }

    private void FixedUpdate()
    {
        movementInput = movementInput.normalized;
        rb.MovePosition(rb.position + movementInput * playerMoveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = Vector3.up * 180;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.up;
        }
    }
}
