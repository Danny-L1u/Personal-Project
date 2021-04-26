using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D move;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;

    float speed;

    private void Update(){
        speed = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()){
            Jump();
        }
    }

    private void FixedUpdate(){
        Vector2 movement = new Vector2(speed * movementSpeed, move.velocity.y);

        move.velocity = movement;
    }

    void Jump(){
        Vector2 movement = new Vector2(move.velocity.x, jumpForce);

        move.velocity = movement;
    }

    public bool IsGrounded (){
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null){
            return true;
        }
        return false;
    }
}
