using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    // static instance of the game manager can be accessed from anywhere within the game
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
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }
    */
    public void IncreaseScore(int amount)
    {
        score += amount;
        if (score > highScore){
            highScore = score;
            print("New High Score : "+highScore);
        }
        print("New score : "+score);

    }
}
