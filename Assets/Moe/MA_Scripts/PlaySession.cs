using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaySession : MonoBehaviour //player relavent data
{
    [SerializeField] float playerHealth = 1; //player char hearts (should be 5 but set to 1 to reset game)
    [SerializeField] int weaponID = 0; //to determine weapon based on ID

    //make it into something other than text in the future 
    [SerializeField] Text healthText; //display hearts as text for now (TODO: create hearts UI -> show health using hearts sprites top right or left)
    [SerializeField] Text weapon; //display weapon as text for now (TODO: create weapons UI in which the weapon symbol or weapon sprite is displayed)

    private void Awake() //make it into singleton -> only one instance of this class per play session
    {
        int numOfSessions = FindObjectsOfType<PlaySession>().Length; //determine how many exsit
        //make sure there's only 1
        if (numOfSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //for initialization
    void Start()
    {
        healthText.text = playerHealth.ToString();
        weapon.text = weaponID.ToString();
    }

    public void GetCollected(int pickUpID) //to determine what was picked up based on ID given from collectiblePickup class
    {

        int ID = pickUpID; //TODO: desing way to determine what is being picked up [IDEA1: class collectible that holds all collectible data such as weapon damage  (Weapon data class)]
                                                                                // [IDEA2: class weapon that gives each weapon an ID and store the weapon data here instead]
        switch (ID) //based on ID, determine what was picked up
        {
            case 1:
                Console.WriteLine("Bat");
                break;
            case 2:
                Console.WriteLine("Pistol");
                break;
            case 3:
                Console.WriteLine("Shotgun");
                break;
            case 4:
                Console.WriteLine("StressRelievePills");
                break;
            default:
                Console.WriteLine("WTF ERROR"); //should be default (if something is not assigned, crash will occur so TODO: create if statement to gaurd against unassigned)
                break;
        }
    }

    public void ProcessPlayerDeath() //hanlde player health and lose when player health is depleted
    {
        if (playerHealth > 1) //to avoid errors, only take damage when player has health left
        {
            TakeDamage(); //player loses health
        }
        else
        {
            ResetSession(); //game reset
        }
    }

    private void TakeDamage() //method to call to decrease player health (ISSUE: how do we determine how much damage? Enemy ID syst...)
    {
        playerHealth--; //decrease health
        healthText.text = playerHealth.ToString(); //update display

        //hard mode? reset level everytime player is hit and give lives rather than health...
        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetSession() //a method to call to reset level/game depending 
    {
        SceneManager.LoadScene(0); //only one scene active -> 0 is disco but in future, 0 should be main menu
        Destroy(gameObject); //ensure it is singleton
    }
}
