using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickup : MonoBehaviour //for now, collectible can be a weapon
{
    [SerializeField] AudioClip pickUpSFX; //sound audio to play when it is picked up
    [SerializeField] int pickUpID = 3; //to determine what is being pickup up using an ID system (could be done in other ways such as creating a class of type "collectibe")
    //this ID system has not been implemented, only being tested between here and play session

    private void OnTriggerEnter2D(Collider2D collision) //pickup method 
    {
        FindObjectOfType<PlaySession>().GetCollected(pickUpID);  //determine weapon picked up by ID + update the level session which (should) holds the player data
        AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position); //play audio (can have different audio based on ID)
        Destroy(gameObject); //remove from scene
    }
}
