using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private Vector3 startPos;

    public bool backAndForth;
    public bool reverse;
    public float travelDistance;

    private float moveSpeed = 3.5f;

    private void Start()
    {
        startPos = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = startPos;

        backAndForth = false;
        reverse = false;
    }

    public void MoveTargets()
    {
        reverse = true;
        backAndForth = true;
    }

    private void Update()
    {
        if (backAndForth)
        {
            if (reverse)
                transform.position = new Vector3(startPos.x - Mathf.PingPong(Time.time * moveSpeed, travelDistance), 
                    transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(startPos.x + Mathf.PingPong(Time.time * moveSpeed, travelDistance), 
                    transform.position.y, transform.position.z);
        }
    }
}
