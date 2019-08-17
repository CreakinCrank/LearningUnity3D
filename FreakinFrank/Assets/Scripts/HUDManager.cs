using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        

        UpdateHUD();
        
    }

    public void UpdateHUD(){
        scoreLabel.text = "Score: " + GameManager.instance.score;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
