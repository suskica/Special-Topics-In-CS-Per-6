using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhoWon : MonoBehaviour
{
    public Sprite winImg;
    public Sprite loseImg;
    public Image image;

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
