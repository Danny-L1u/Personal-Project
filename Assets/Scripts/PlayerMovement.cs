//Code taken from https://www.youtube.com/watch?v=ZvF_MYlt944&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=2 
//and https://www.youtube.com/watch?v=1bHVsxw_o7o&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
This class allows the player to move left, right and jump up. It has a certain speed the player
moves at when moving and a certain max height the player can jump.
*/

public class PlayerMovement : MonoBehaviour
{
    //Movement variables
    public float movementSpeed;
    public Rigidbody2D move;
    //Animator variable
    public Animator anim;
    //Jump variables
    public float jumpForce = 30f;
    public Transform feet;
    public LayerMask groundLayers;
    float speed;
    //Player state variable
    public bool isDead =  false;

    [HideInInspector] public bool isFacingRight = true;

    //Runs every frame
    private void Update(){

        //Checks if player is alive
        if(!isDead){
             //Checks if player wants to move left and right ("a", "w") 
            speed = Input.GetAxisRaw("Horizontal");

            //Checks if player wants to jump ("w") and is touching the ground
            if (Input.GetButtonDown("Jump") && IsGrounded()){
                Jump();
            }

            if (Mathf.Abs(speed) > 0.05f){
                anim.SetBool("isRunning", true);
            }
            else{
                anim.SetBool("isRunning", false);
            }

            //Swap player model depending if player is moving right or left
            if (speed > 0f){
                transform.localScale = new Vector3(1f, 1f, 1f);
                isFacingRight = true;
            }
            else if (speed < 0f){
                transform.localScale = new Vector3(-1f, 1f, 1f);
                isFacingRight = false;
            }

            anim.SetBool("isGrounded", IsGrounded());
        }
    }

    //Calculates the speed player moves at
    private void FixedUpdate(){
        Vector2 movement = new Vector2(speed * movementSpeed, move.velocity.y);
        move.velocity = movement;
    }

    //Brings player up simulating a "Jump"
    void Jump(){
        Vector2 movement = new Vector2(move.velocity.x, jumpForce);
        move.velocity = movement;
    }

    //Checks if the player is on the ground, if not then player can't jump
    public bool IsGrounded (){
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null){
            return true;
        }
        return false;
    }
}
