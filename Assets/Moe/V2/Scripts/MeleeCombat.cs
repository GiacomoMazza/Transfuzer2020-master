using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator attackAnimator; //for future reference to animation added for melee attack

    public Transform pointOfAttack; //transform of empty 'pointOfAttack' added to specify range of attack
    private float baseMeleeAttackRange = 0.15f; //area of range for melee attacks delcared so that it can be modified for other weapons 
    public LayerMask targetLayer; //to assign enemies to this layer so that attacks only detect objs in this layer 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //will move this to its own part for modularity 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformMeleeAttack();
        }
    }

    void PerformMeleeAttack()
    {
        /* add check for if player has melee weapon equiped or not; example:
            if(!hasMeleeWeaponEquiped){return;}*/

        //play a melee attack animation 
        //Ex: attackAnimator.SetTrigger("Attack");

        //detect enemies in range (maybe add get Equiped weapon function to determine what weapon player has and determine stats such as range)
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(pointOfAttack.position, baseMeleeAttackRange, targetLayer); //get enemies that are hit; range of attacked based on circle originating from point of attack transform 


        //apply damage
        foreach (Collider2D enemy in enemiesHit)
        {
            Debug.Log("Hit: " + enemy.name); //still need to implement the enemy
        }
    }

    private void OnDrawGizmosSelected() //visualize melee attack for testing
    {
        if (pointOfAttack == null) { return; } //error protections
        Gizmos.DrawWireSphere(pointOfAttack.position, baseMeleeAttackRange);
    }
}
