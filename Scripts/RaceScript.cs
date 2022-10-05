using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceScript : MonoBehaviour
{
    public float totalTime;
    public float lapTime;
    public float bestTime = 0;
    public int lapsAmount;
    public int lapsDone;
    private bool startLapTimer = false;
    private bool startTotalTimer = false;

    private bool checkpoint1 = false;
    private bool checkpoint2 = false;

    public UnityEngine.UI.Text lTime;
    public UnityEngine.UI.Text bTime;
    public UnityEngine.UI.Text tTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (startLapTimer) {
            lapTime = lapTime + Time.deltaTime;

            //Debug.Log(lapTime);
            lTime.text = "Lap Time: " + lapTime.ToString("F2");   
        }
        if (startTotalTimer){
            totalTime = totalTime + Time.deltaTime;
            tTime.text = "Total Time: " + totalTime.ToString("F2");
        }
       
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "StartFinish"){

            
            if (!startLapTimer && lapsDone < lapsAmount){
                startLapTimer = true;
                lapTime = 0;
                checkpoint1 = false;
                checkpoint2 = false;
            }
            if (checkpoint1 == true && checkpoint2 == true){
                lapsDone += 1;
                startLapTimer = false;
                if (bestTime == 0) {
                    bestTime = lapTime;
                }
                if (lapTime < bestTime){
                    bestTime = lapTime;
                }
                bTime.text = "Best: " + bestTime.ToString("F2");  
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
        if (other.gameObject.name == "Finish"){
            startTotalTimer = true;
            if (lapsDone >= lapsAmount){
                startTotalTimer = false;
            }
        }
    }
}
