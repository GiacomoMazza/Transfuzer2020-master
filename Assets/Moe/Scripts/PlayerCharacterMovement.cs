using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{

    public Animator playerCharacterAnimator; //to access player character animator component

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerCharacter();
    }

    private void movePlayerCharacter()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f); 
   
        playerCharacterAnimator.SetFloat("Horizontal", movement.x);
        playerCharacterAnimator.SetFloat("Vertical", movement.y);
        playerCharacterAnimator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime; //change position of character (delta time for frame rate independence and smooth movement)
    }
}
