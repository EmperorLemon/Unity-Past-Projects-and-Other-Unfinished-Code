using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isStanding;
    public bool removeFromList;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            isStanding = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bowling Ball") || collision.collider.CompareTag("Player") || collision.collider.CompareTag("Pin"))
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void Update()
    {
        if (transform.up.y < .6f)
        {
            isStanding = false;
            removeFromList = false;
        }
        else
        {
            isStanding = true;
            removeFromList = true;
        }
    }
}
