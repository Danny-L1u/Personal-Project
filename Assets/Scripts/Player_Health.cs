//Code taken from: https://www.youtube.com/watch?v=sPiVz1k-fEs
/**
This script keeps track of player health. It starts with a max health then everytime the player
takes damage the health lowers until it reaches 0 or below 0, which then the player dies.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public Animator animator;

    //Health variables
    public int maxHealth;
    int currentHealth;
    //Health bar variable
    public Player1_HealthBar healthBar;
    //Disable Player when dead variables
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public PlayerShoot playerShoot;

    [SerializeField]
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //Start the player with full health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        
        AudioManager.instance.Stop("Menu Music");
        AudioManager.instance.Play("Fighting Music");
    }

    /**
    This method takes away health if the player is damaged and activates a hurt
    animation. If the health is 0 or below 0 then a die method is activated
    */
    public void TakeDamage(int damage)
    {
        //Deal damage to player
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //Play hurt animation
        animator.SetTrigger("Hurt");
        AudioManager.instance.Play("Player1 Hurt");

        //Checks if the player is dead
        if (currentHealth <= 0){
            AudioManager.instance.Play("Player1 Death");
            Die();
        }
    }

    /**
    This method performs a die animation and disables the player
    */
    void Die()
    {
        //Die animation
        animator.SetBool("IsDead", true);

        //Disable player
        rb.gravityScale = 0;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        playerMovement.isDead = true;
        playerCombat.isDead = true;
        playerShoot.isDead = true;
    }

}  
