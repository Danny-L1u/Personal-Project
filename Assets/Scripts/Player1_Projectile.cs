//Code taken from: https://www.youtube.com/watch?v=qQ7V5COPDVk&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=8

using UnityEngine;

public class Player1_Projectile : MonoBehaviour
{
    public float proSpeed = 15f;
    public float proDamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate() {
        rb.velocity = transform.right * proSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player2"){
            //Damage enemy
            collision.gameObject.GetComponent<Player2_Health>().TakeDamage(15);
            }
                    Destroy(gameObject);
        }  
}
