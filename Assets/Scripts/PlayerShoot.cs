//Code taken from: https://www.youtube.com/watch?v=qQ7V5COPDVk&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=8

using UnityEngine;

/**
This class shoots a projectile. It has a specific rate the projectile travels at 
has a buffer between shots so the player cannot spam shots.
*/
public class PlayerShoot : MonoBehaviour
{
    //Shooting variables
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject proPrefab;
    float timeUntilFire;
    PlayerMovement pm;
    //Checks player state
    public bool isDead = false;

    //Start is called before the first frame update
    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    //Runs every frame
    private void Update(){

        //Checks if player is alive
        if (!isDead)
        {
            //Checks if player wants to shoot ("v") and if the "buffer" between shots is over
            if (Input.GetButtonDown("Shoot") && (timeUntilFire + 0.3) < Time.time){
                Shoot();
                //Time until the next projectile can be shot
                timeUntilFire = Time.time + fireRate;
            }
        }
    }

    /**
    This method shoots the project forward from the player and either goes left or right
    depending on which way the player is facing
    */
    void Shoot() {
        AudioManager.instance.Play("Player1 Shoot");
        float angle = pm.isFacingRight ? 0f: 180f;
        Instantiate(proPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
    
}
