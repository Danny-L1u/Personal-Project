//Code taken from https://www.youtube.com/watch?v=ZvF_MYlt944&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=2 
//and https://www.youtube.com/watch?v=1bHVsxw_o7o&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Movement : MonoBehaviour
{
    //Movement variables
    public float movementSpeed;
    public Rigidbody2D move;
    public Animator anim;
    //Jump variables
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    float speed;
    public bool isDead = false;

    //Runs every frame
    private void Update(){
        if(!isDead){
            speed = Input.GetAxisRaw("Horizontal2");

            //If player wants to jump
            if (Input.GetButtonDown("Jump2") && IsGrounded()) {
                Jump();
            }

            if (Mathf.Abs(speed) > 0.05f){
                anim.SetBool("isRunning", true);
            }
            else{
                anim.SetBool("isRunning", false);
            }

            //Swap player model depening if player is moving right or left
            if (speed > 0f){
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (speed < 0f){
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            anim.SetBool("isGrounded", IsGrounded());
        }
    }

private void FixedUpdate(){
    Vector2 movement = new Vector2(speed * movementSpeed,move.velocity.y);

    move.velocity = movement;
}
    //Jump function
    void Jump() {
        Vector2 movement = new Vector2(move.velocity.x, jumpForce);

        move.velocity = movement;
    }

    //Checks if the player is on the ground, if not then player can't jump
    public bool IsGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null) {
            return true;
        }

        return false;
    }
}
