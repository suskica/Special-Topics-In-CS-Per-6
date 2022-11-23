using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.4f;

    public float duration = 5f;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider player) {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= multiplier;

        yield return new WaitForSeconds(duration);

        player.transform.localScale /= multiplier;
        Destroy(gameObject);
    }
}
