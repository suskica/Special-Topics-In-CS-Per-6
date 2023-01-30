using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhoWon : MonoBehaviour
{
    //the Sprites are the possible images the screen can display when the race finishes which will be stored into the image
    //variable depending if the player wins or loses
    //script attached to the finish line
    public Sprite winImg;
    public Sprite loseImg;
    public Image image;

    //if AI reaches the finish line first save the lose display into the image variable to shpw the player
    //else if player reaches the finish line save the winner display into the image variable to show the player
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "AI") {
                //changes the image to a lose one
                image.sprite = loseImg;
            } else if (other.gameObject.tag == "Player") {
                //changes the image to a win one
                 image.sprite = winImg;
            }
    }

}
