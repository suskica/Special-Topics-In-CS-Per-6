using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToCheckpoint : MonoBehaviour
{
    public float repspawnDelay = 2f;

    public Vector3 position;
    public Quaternion rotation;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void removeConstraints() { //unfreezes the car
        rb.constraints = RigidbodyConstraints.None;
    }

    private void OnTriggerEnter(Collider other) { //when car comes into contact with a different collider
        if (other.gameObject.tag == "Respawn") { //if car passes through a checkpoint/respawn point:
            position = other.bounds.center; //save position
            rotation = other.gameObject.transform.rotation; //save rotation
        } else if (other.gameObject.tag == "Death") { //if car comes into contact with terrain
            transform.SetPositionAndRotation(position, rotation); //teleport the car to the saved position and rotation
            rb.velocity = new Vector3(0, 0, 0); //set velocity to 0 to prevent previous car momentum from carrying on
            rb.constraints = RigidbodyConstraints.FreezeAll; //freeze the car completely
            Invoke("removeConstraints", repspawnDelay); //after set respawn delay, runs the method "removeConstraints" to unfreeze the car
        }
    }
   
}
