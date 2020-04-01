using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{

    public Animator playerCharacterAnimator;

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
        playerCharacterAnimator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 LR = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f); //access left and right arrow keyes for horizontal movement -> CAN CHANGE TO WASD CONTROLS IN FUTURE
        transform.position = transform.position + LR * Time.deltaTime; //change position of character (delta time for frame rate independence and smooth movement)
    }
}
