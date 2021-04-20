using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hor;
    public Rigidbody2D move;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hor);
        hor = Input.GetAxis("Horizontal");
        move.velocity = new Vector2(hor * speed, move.velocity.y);
    }
}
