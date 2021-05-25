using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D move;

    public Animator anim;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;

    float speed;

    private void Update(){
        speed = Input.GetAxisRaw("Horizontal");

        //If user wants to jump
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            Jump();
        }

        if (Mathf.Abs(speed) > 0.05f){
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);
        }

        if (speed > 0f){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (speed < 0f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        anim.SetBool("isGrounded", IsGrounded());
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
