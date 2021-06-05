//Code taken from: https://www.youtube.com/watch?v=qQ7V5COPDVk&list=PLfX6C2dxVyLw5kerGvTxB-8xqVINe85gw&index=8

using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject proPrefab;

    float timeUntilFire;
    PlayerMovement pm;
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
            if (Input.GetButtonDown("Shoot") && (timeUntilFire + 0.3) < Time.time){
                AudioManager.instance.Play("Player1 Shoot");
                Shoot();
                timeUntilFire = Time.time + fireRate;
            }
        }
    }

    void Shoot() {
        float angle = pm.isFacingRight ? 0f: 180f;
        Instantiate(proPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
    
}
