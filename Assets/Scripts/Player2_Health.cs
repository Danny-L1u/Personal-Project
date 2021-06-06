//Code taken from: https://www.youtube.com/watch?v=sPiVz1k-fEs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
This class keeps track of player health. It starts with a max health then everytime the player
takes damage the health lowers until it reaches 0 or below 0, which then the player dies and the
game transitions to the ending scene.
*/

public class Player2_Health : MonoBehaviour
{
    public Animator animator;

    //Health variables
    public int maxHealth;
    int currentHealth;
    //Health bar variables
    public Player2_HealthBar healthBar;
    //Disable Player when dead variables
    public Player2_Movement player2Movement;
    public Player2_Combat player2Combat;

    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Start the player with full health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth2(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    /**
    This method takes away health if the player is damaged and activates a hurt
    animation. If the health is 0 or below 0 then a die method is activated
    */
    public void TakeDamage(int damage)
    {
        //Deal damage to player
        currentHealth -= damage;
        healthBar.SetHealth2(currentHealth);

        //Play hurt animation and hurt sound effect
        animator.SetTrigger("Hurt");
        AudioManager.instance.Play("Player2 Hurt");

        //Checks if the player is dead
        if(currentHealth <= 0){
            Die();
        }
    }

    /**
    This method performs a die animation and disables the player
    */
    void Die()
    {
        //Die animation and death sound effect
        AudioManager.instance.Play("Player2 Death");
        animator.SetBool("IsDead", true);

        //Disable player
        rb.gravityScale = 0;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        player2Movement.isDead = true;
        player2Combat.isDead = true;
        //Switch the game music and switch Unity scenes
        AudioManager.instance.Stop("Fighting Music");
        SceneManager.LoadScene(3);
        AudioManager.instance.Play("End Music");
    }
}
