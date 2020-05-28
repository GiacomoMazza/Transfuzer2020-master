using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Dynamic;

public class WeaponData : MonoBehaviour //find a way to link to play session and collectible pickup
{ 
    //initialized to avoid errors
    [SerializeField] int weaponID = 0; //ID system being used to determine weapon picked up
    string weaponName; //name given to weapon
    [SerializeField] float range = 0; //distance its projectiles can travel
    [SerializeField] float rateOfFire = 0; //how fast before another projectile can be fired (in seconds -> may use coroutines to delay))
    [SerializeField] float damage = 0; //how fast before another projectile can be fired (in seconds -> may use coroutines to delay))
    int numberOfProjectilesPerShot = 0; //for spread weapon like shotgun (EX: launch 3 projectiles in tight cone and each does damage separately)

    bool isRangedWeapon = true; //we need a better way to figure out if weapon is ranged or melee (if false, may choose to ignore range and projectiles per shot for ex)


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void assignWeaponData(int wepaonID)
    {
        //may have forgot the values we chose to assign originally so hopeufully its been recorded
        switch (wepaonID) //based on ID, determine what was picked up
        {
            case 0: 
                Console.WriteLine("NOT ASSIGNED"); //if reached here, it means weapon assignment did not work
                break;
            case 1: //bat
                Console.WriteLine("Bat");
                isRangedWeapon = false;
                range = 2f; //change based on bool
                rateOfFire = 1.2f;
                damage = 2;
                numberOfProjectilesPerShot = 0;
                break;
            case 2: //pistol
                Console.WriteLine("Pistol");
                isRangedWeapon = true;
                range = 10.0f;
                rateOfFire = 0.6f;
                damage = 0.5f;
                numberOfProjectilesPerShot = 1;
                break;
            case 3: //shotgun
                Console.WriteLine("Shotgun");
                isRangedWeapon = true;
                range = 6.0f;
                rateOfFire = 1.8f;
                damage = 1f;
                numberOfProjectilesPerShot = 5;
                break;
            case 4: //something else
                Console.WriteLine("StressRelievePills");

                break;
            default: //default
                Console.WriteLine("WTF ERROR"); //should be default (if something is not assigned, crash will occur so TODO: create if statement to gaurd against unassigned)
                break;
        }

    }

    void getWeaponData() //a way to get the data of the weapon instance (ie get damage, range, rate of fire, etc... all in one go rather than creating getter methods for each)
    {

    }
}
