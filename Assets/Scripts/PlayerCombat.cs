//Code taken from https://www.youtube.com/watch?v=sPiVz1k-fEs
/**
This class allows the player to use melee attacks. If a player wants to attack 
the class detects if there are enemies within the attack range and damges them. 
The class also puts time between attacks so the player cannot spam attacks.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    //Attack variables
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        //Checks if player is alive
        if (!isDead){
            //Puts a buffer between attacks so player cannot spam attacks
            if (Time.time >= nextAttackTime)
            {
                //If player wants to melee attack ("c") activate attack function
                if (Input.GetButtonDown("Melee"))
                {
                    Attack();
                    //Ads a buffer between melee attacks
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    /**
    This method detects and attacks the player. It plays an attack animation
    then detects if there are enemies within the attack animation. It does this by
    taking data from an attackpoint in front of the player in Unity. Then if there 
    are enemies it access the opposite player's health and lowers it.
    */
    void Attack()
    {
        //Play an attack animation
         animator.SetTrigger("Melee");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies) 
        {
            //Damage enemy
            enemy.GetComponent<Player2_Health>().TakeDamage(attackDamage);
        }
    }

//This method displays player's attack range when selected
void OnDrawGizmosSelected()
{
    if (attackPoint == null)
        return;

    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}

}
