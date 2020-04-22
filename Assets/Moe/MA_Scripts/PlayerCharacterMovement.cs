using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour //this class is not for movement anymore, but changing name causes issues
{
    [SerializeField] private Animator playerCharacterAnimator; //to access player character animator component and must be set manually for now
    /*[SerializeField]*/ Vector2 deathPushBack = new Vector2(100f, 100f); //player is pushed back on death and this controls how far/fast pushback is (NOT WORKING AS I NEED TO MOVE COLLIDER RATHER THAN TRANSFORM SIMILAR TO HOW ENEMY WORKS)

    public Rigidbody2D playerRigidBody; //set at start
    public CapsuleCollider2D playerBodyCollider; //set at start for and is for detecting enemies and triggers in scene (doors buttons) 
    public BoxCollider2D playerBoxCollider; //yet another collider mainly for wall detetction

    public float moveSpeed = 1; //speed at which player moves
    public float dashSpeed = 2; //speed at which player will dash (dash method -> work in progress)

    public bool playerAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();

        //remember to set box collider when testing map pls

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerAlive) //stop player from being able to do stuff when getting hit (losing lives)
        {
            return; 
        }

        die();
        move();
    }

    private void move() //player movement 
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * moveSpeed; 
   
        playerCharacterAnimator.SetFloat("Horizontal", movement.x);
        playerCharacterAnimator.SetFloat("Vertical", movement.y);
        playerCharacterAnimator.SetFloat("Magnitude", movement.magnitude);

        playerRigidBody.velocity = movement; //to check

        transform.position = transform.position + movement * Time.deltaTime; //change position of character (delta time for frame rate independence and smooth movement)

        //flipping sprite (might want to extract it to its own method for modularity)
        if (movement.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if (movement.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void die() //player death 
    {
        //if player collider touches anything from enemy class
        if(playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            playerAlive = false; //stop player movement controls on death 
            //issues with line above: Need to add other controls (shooting for ex) + when moving on death, player continues to move

            playerCharacterAnimator.SetTrigger("Dying"); //trigger death anim
            GetComponent<Rigidbody2D>().velocity = deathPushBack; //testing visually that player died
    
        }

    }

    private void pickUp()
    {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Interactables")))
        {
            //how to get whats being picked up?
        }
    }

    private void dash() //player dash (WORK IN PROGRESS)
    {
        //if (dash input detected) { 

        Vector2 velocityToAdd = new Vector2(0f, dashSpeed);
        playerRigidBody.velocity += velocityToAdd; //In the future (being optimistic) I'm planning to move player based on rigib body once I understand how its done

        //transform.position -> still checking how to implement dash 

    }

    private void flipSprite()
    {

    }
}
