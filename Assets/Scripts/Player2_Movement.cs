//Code taken from https://www.youtube.com/watch?v=ZvF_MYlt944&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=2 
//and https://www.youtube.com/watch?v=1bHVsxw_o7o&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;

    float mx;

    bool isGrounded;

    //runs every frame
    private void Update(){
        mx = Input.GetAxisRaw("Horizontal2");

        //Checks if player hits the jump key
        if (Input.GetButtonDown("Jump2") && IsGrounded()) {
            Jump();
        }

        if (Mathf.Abs(mx) > 0.05f){
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);
        }

        if (mx > 0f){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else{
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        anim.SetBool("isGrounded", IsGrounded());
    }

private void FixedUpdate(){
    Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

    rb.velocity = movement;
}
    //Jump function
    void Jump() {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
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
