using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIRaceScript : MonoBehaviour //modified EvenBetterRaceScript basically
{
    //private float totalTime;
    //private float lapTime;
    //private float bestTime = 0;

    public bool racing = false;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    private bool paused = false;

    public byte lapAmount = 3;
    private byte lapCount;

  

    private Rigidbody rb;
    private Toggle toggle;

    // Start is called before the first frame updatess
    void Start()
    {
        lapCount = 0;
        rb = GetComponent<Rigidbody>(); //gets rigidbody to check collider collisions
   
        toggle = GetComponent <Toggle> (); //gets toggle component to enable/disable win/lose image
        toggle.isOn = false;
    }

    

    void OnTriggerEnter(Collider other) { //checks when the car comes into collision with another collider
        if (paused) { //prevents issues if the game is paused while user is on a collider
            return;
        }
        if (other.gameObject.name == "StartFinish") {
            if (!racing) { //not really needed for AI, this is just here because I copy pasted the EvenBetterRaceScript and modified it a little; didnt remove though because it works
                racing = true;
                checkpoint1 = false;
                checkpoint2 = false;
            }
            if (checkpoint1 && checkpoint2) { //resets the checkpoint checks after the user makes a full lap around the track and increases lap count (not really necessary for AI though)
                checkpoint1 = false;
                checkpoint2 = false;
                lapCount++;
                if (lapCount >= lapAmount) { //checks if the laps required is met and ends the game if it is
                    racing = false;
                    toggle.isOn = true; //toggle the win/lose screen
                    Time.timeScale = 0f; //pauses the game to prevent AI from changing the win/lose screen as the game would still be "playable", just not visible
                }
            }   
        }
        //not needed for AI, but its use is shown in EvenBetterRaceScript which this is used for
        if (other.gameObject.name == "CheckPoint1" ){
            Debug.Log("CheckPoint 1");
            checkpoint1 = true;
        }
        if (other.gameObject.name == "CheckPoint2" ){
            Debug.Log("Checkpoint 2");
            checkpoint2 = true; 
        }
    }
}