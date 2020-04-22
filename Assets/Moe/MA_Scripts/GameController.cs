using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int playerLives = 3;

    private void Awake() //using singleton pattern to make sure theres only one session at a time
    {
        //getting error with gamesession not being recognized even after including the "using" statement for level management in UnityEngine
        /*
        int numOfGameSessions = FindObjectsOfType<GameSession>().Length; //how many session of scene was loaded (tied to player death)
        if(numOfGameSessions > 1)
        {
            Destroy(gameObject);
        } 
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        */

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void processDeath() 
    {
        if(playerLives > 1)
        {
            //take player life
        }
        else
        {
            //reset game progress/session
        }
    }

    private void decrementPlayerLife() //to be called from other classes on player death
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
    }

    private void resetGameSession()
    {
        SceneManager.LoadScene(0); //hard coded 0 as there's only one scene for now
        //Destroy(gameObject);
    } 
}
