using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpeedIndicator : MonoBehaviour
{
    public Transform player;
    public Text speedText;

    float speed = 0;
    Vector3 lastPosition = Vector3.zero;

    private void FixedUpdate()
    {
        speed = Mathf.Round(((player.position - lastPosition).magnitude / Time.deltaTime) * 100) / 100;
        lastPosition = player.position;
    }

    private void Update()
    {
        speedText.text = "Speed: + " + speed + " m/s";
    }
}