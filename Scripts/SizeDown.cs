using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDown : MonoBehaviour
{
     // Need variables for the particle effect, how small the car is supposed to shrink, and how long the it should last
     //which in this case is 5 sec
    
    public GameObject pickupEffect;

    public float multiplier = 0.4f;

    public float duration = 5f;

    //a method that gets activated "on trigger" or when the car comes in contact with the powerup; will then call the Pickup method
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(Pickup(other));
        }
    }

    // spawn particle effect when pickup; decrease the car size by the multiplier; 
    //its an IEnumerator so we can wait a certain amount of seconds before the powerup effect stops; the powerup is then destroyed as well
    IEnumerator Pickup(Collider player) {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= multiplier;

        yield return new WaitForSeconds(duration);

        player.transform.localScale /= multiplier;
        Destroy(gameObject);
    }
}
