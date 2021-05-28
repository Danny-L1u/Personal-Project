//Code taken from: https://www.youtube.com/watch?v=sPiVz1k-fEs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Health : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -=damage;

        //Play hurt animation

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player2 died!");

        //Die animation

    }
}
