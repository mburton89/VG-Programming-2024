using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public Button respawn;
    public Button returnToMenu;
    public int timeSurvived;
    public int weightCollected; //collect time survived and weight collected, add together for total :)
    public int totalScore;
    public TextMeshProUGUI endGameText;

    public bool isPlayerAlive; //For testing and coding, update when real boolean is made
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    void handleEnding(bool isPlayerAlive)
    {
    //    if(isPlayerAlive)
    //    {
   //         endGameText.SetText("You Survived! \nSurvival Time ~ " ??? "\nWeight Collected ~ " ??? "\nTotal Score ~ " ???   ); //replace ??? with proper variables
     //   }
    //    else
    //    {
    //        endGameText.SetText("You Died! \nSurvival Time ~ " ??? "\nWeight Collected ~ " ??? "\nTotal Score ~ " ???);
   //     }
    }

}
