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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void removeConstraints() {
        rb.constraints = RigidbodyConstraints.None;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Respawn") {
            position = other.bounds.center;
            rotation = other.gameObject.transform.rotation;
        } else if (other.gameObject.tag == "Death") {
            transform.SetPositionAndRotation(position, rotation);
            rb.velocity = new Vector3(0, 0, 0);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("removeConstraints", repspawnDelay);
        }
    }
}
