using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvenBetterRaceScripts : MonoBehaviour
{
    private float totalTime;
    private float lapTime; //current lap time
    private float bestTime = 0; //best lap time

    public bool racing = false;
    private bool checkpoint1 = false; //boolean for if the 1st checkpoint is passed
    private bool checkpoint2 = false; //boolean for if the 2nd checkpoint is passed
    private bool paused = false; //for when the 

    public byte lapAmount = 3;
    private byte lapCount;

    public UnityEngine.UI.Text lTime;
    public UnityEngine.UI.Text bTime;
    public UnityEngine.UI.Text tTime;

    private Rigidbody rb;
    private Toggle toggle;

    // Start is called before the first frame updatess
    void Start()
    {
        lapCount = 0;
        rb = GetComponent<Rigidbody>(); //gets collider to check collider collisions later
        bTime.text = "Best: " + bestTime.ToString("F2");
        toggle = GetComponent <Toggle> (); //gets toggle component to enable/disable win/lose image
        toggle.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (racing) {
            if (paused) {
                //if racing is enabled but the game is still "paused" unpause the game.
                rb.constraints = RigidbodyConstraints.None;
                paused = false;
            }
            //update lap times
            lapTime = lapTime + Time.deltaTime;
            lTime.text = "Lap Time: " + lapTime.ToString("F2"); //F2 rounds the decimals
            totalTime = totalTime + Time.deltaTime;
            tTime.text = "Total Time: " + totalTime.ToString("F2");   
        } else {
            //if user is not racing, pause game and freeze the car in place
            rb.constraints = RigidbodyConstraints.FreezeAll;
            paused = true;
        }
    }

    void OnTriggerEnter(Collider other) { //checks when the car comes into contacat with another rigidbody
        if (paused) { //prevents issues if the game is paused while user is on a collider
            return;
        }
        if (other.gameObject.name == "StartFinish") {
            if (!racing) { //starts timers when the user goes through the starting line
                racing = true;
                lapTime = 0;
                checkpoint1 = false;
                checkpoint2 = false;
            }
            if (checkpoint1 && checkpoint2) { //checks to make sure the user didnt just go backwards into the starting line
                if (bestTime == 0 || lapTime < bestTime) { //checks if current lap is faster than best lap time
                    bestTime = lapTime; //sets best time to the lap time if above condition is passed
                    bTime.text = "Best: " + bestTime.ToString("F2");
                }
                //resets the checkpoint checks after the user makes a full lap around the track and increases lap count
                checkpoint1 = false;
                checkpoint2 = false;
                lapCount++;
                lapTime = 0;
                if (lapCount >= lapAmount) { //checks if the laps required is met and ends the game if it is
                    racing = false;
                    toggle.isOn = true; //toggle the win/lose screen
                    Time.timeScale = 0f; //pauses the game to prevent AI from changing the win/lose screen as the game would still be "playable", just not visible
                }
            }   
        }
        //if user passes a significant checkpoint, it will set the checks to true
        if (other.gameObject.name == "CheckPoint1" ){
            //Debug.Log("CheckPoint 1");
            checkpoint1 = true;
        }
        if (other.gameObject.name == "CheckPoint2" ){
            //Debug.Log("Checkpoint 2");
            checkpoint2 = true; 
        }
    }
}