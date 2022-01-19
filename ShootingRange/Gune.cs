using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gune : MonoBehaviour
{
    [HideInInspector]
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void SetStartPosition()
    {
        transform.position = startPos;
        transform.SetParent(null);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }
}
