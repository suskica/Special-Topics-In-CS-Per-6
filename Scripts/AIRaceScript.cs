using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIRaceScript : MonoBehaviour
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
        rb = GetComponent<Rigidbody>();
   
        toggle = GetComponent <Toggle> ();
        toggle.isOn = false;
    }

    

    void OnTriggerEnter(Collider other) {
        if (paused) {
            return;
        }
        if (other.gameObject.name == "StartFinish") {
            if (!racing) {
                racing = true;
                //lapTime = 0;
                checkpoint1 = false;
                checkpoint2 = false;
            }
            if (checkpoint1 && checkpoint2) {
                checkpoint1 = false;
                checkpoint2 = false;
                lapCount++;
                //lapTime = 0;
                if (lapCount >= lapAmount) {
                    racing = false;
                    toggle.isOn = true;
                }
            }   
        }
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