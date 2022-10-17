using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterRaceScript : MonoBehaviour
{
    private float totalTime;
    private float lapTime;
    private float bestTime = 0;

    public bool racing = false;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    private bool paused = false;

    public UnityEngine.UI.Text lTime;
    public UnityEngine.UI.Text bTime;
    public UnityEngine.UI.Text tTime;

    private Rigidbody rb;

    // Start is called before the first frame updatess
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bTime.text = "Best: " + bestTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (racing) {
            if (paused) {
                rb.constraints = RigidbodyConstraints.None;
                paused = false;
            }
            lapTime = lapTime + Time.deltaTime;
            lTime.text = "Lap Time: " + lapTime.ToString("F2");
            totalTime = totalTime + Time.deltaTime;
            tTime.text = "Total Time: " + totalTime.ToString("F2");   
        } else {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            paused = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "StartFinish") {
            if (!racing) {
                racing = true;
                lapTime = 0;
                checkpoint1 = false;
                checkpoint2 = false;
            }
            if (checkpoint1 && checkpoint2) {
                if (bestTime == 0 || lapTime < bestTime) {
                    bestTime = lapTime;
                    bTime.text = "Best: " + bestTime.ToString("F2");
                    checkpoint1 = false;
                    checkpoint2 = false;
                }
                lapTime = 0;
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