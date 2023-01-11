using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhoWon : MonoBehaviour
{

    public double currentLap = 0;
    public double lapsRequired = 3;

    public Sprite winImg;
    public Sprite loseImg;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        currentLap++;
        if (currentLap >= lapsRequired) {
            if (other.gameObject.name.Contains("AI")) {
                //ai win
                image.sprite = loseImg;
            } else {
                //player win
                image.sprite = winImg;
            }
        }
    }

}
