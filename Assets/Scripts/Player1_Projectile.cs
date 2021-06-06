//Code taken from: https://www.youtube.com/watch?v=qQ7V5COPDVk&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=8

using UnityEngine;

/**
This class sets speed and damage Player1 shoots out. It also detects if it hits the enemy (Player2)
and if it does it damages the enemy (Player2)
*/
public class Player1_Projectile : MonoBehaviour
{
    public float proSpeed = 15f;
    public float proDamage = 10f;
    public Rigidbody2D rb;

    //Speed the projectile travels
    private void FixedUpdate() {
        rb.velocity = transform.right * proSpeed;
    }

    //Detects if the projectile hits Player2.
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player2"){
            //Damage Player2
            collision.gameObject.GetComponent<Player2_Health>().TakeDamage(15);
            }
                    Destroy(gameObject);
        }  
}
