using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMalla : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    { 
        var rb = other.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(rb.velocity * -0.5f, ForceMode.Impulse);
    }
}
