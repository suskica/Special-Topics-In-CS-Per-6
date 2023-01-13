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
                //ai win
                //Debug.Log("ai registered");
                image.sprite = loseImg;
            } else if (other.gameObject.tag == "Player") {
                //player win
                image.sprite = winImg;
            }
    }

}
