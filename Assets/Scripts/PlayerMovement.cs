//Code taken from https://www.youtube.com/watch?v=ZvF_MYlt944&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=2 
//and https://www.youtube.com/watch?v=1bHVsxw_o7o&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    public bool isDead =  false;

    [HideInInspector] public bool isFacingRight = true;

    //Runs every frame
    private void Update(){
        if(!isDead){

            speed = Input.GetAxisRaw("Horizontal");

            //If player wants to jump
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
                isFacingRight = true;
            }
            else if (speed < 0f){
                transform.localScale = new Vector3(-1f, 1f, 1f);
                isFacingRight = false;
            }

            anim.SetBool("isGrounded", IsGrounded());
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

    //Checks if the player is on the ground, if not then player can't jump
    public bool IsGrounded (){
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null){
            return true;
        }
        return false;
    }
}
