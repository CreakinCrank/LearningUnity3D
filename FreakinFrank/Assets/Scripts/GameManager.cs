using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // If we make hudManager public, we will have to drag HUDManager into the inspector
    // every time we use this script. see ** in "Awake"
    HUDManager hudManager;
    public int score = 0;
    public int highScore = 0;
    public int currentLevel = 1;
    public int highestLevel = 2;
    // static instance (altering one alters all) of the game manager can be accessed from anywhere within the game
    public static GameManager instance;
    // Start is called before the first frame update
    // Awake is called BEFORE start!
    void Awake()
    {
        // If no game manager exisits, create it
        if (instance == null){
            // Assign it to current object
            instance = this;
                        
        }
        // Check if another game manager exists
        else if (instance != this){
            // We must only have one, so destroy this latest one
            Destroy(gameObject);
        }
        // Don't destroy the game manager when changing scenes
        DontDestroyOnLoad(gameObject);
        // ** As we have made hudManager private, we must search for the GameObject
        // HUDManager in the current scene:
        hudManager = FindObjectOfType<HUDManager>();
                
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }
    */
    public void IncreaseScore(int amount)
    {
        //if (hudManager == null){print("NULL");}
        score += amount;
        if (score > highScore){
            highScore = score;
            print("New High Score : "+highScore);
            }
        //if (hudManager != null){ //prevents errors if we have not yet included HUDManager in our scene!
        hudManager.UpdateHUD();
        //}
        

    }
    //Reset the game, duh!
    public void Reset(){
        score = 0;
        currentLevel = 1;
        //if (hudManager != null)
        hudManager.UpdateHUD();
        SceneManager.LoadScene("Level1");

    }
    //Send the player to the next level
    public void IncreaseLevel(){
        //Check if at highest level & return to level 1
        if (currentLevel < highestLevel){
            currentLevel++;
        }
        else if (currentLevel >= highestLevel){
            currentLevel = 1;
        }
        SceneManager.LoadScene("Level" + currentLevel);
    }
}
