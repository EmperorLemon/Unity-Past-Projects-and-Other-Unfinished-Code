using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DebugObject : MonoBehaviour
{
    ThrowableObject to;

    public Text topSpeed;
    public Text speed;
    public Text mass;

    private void Start()
    {
       to = FindObjectOfType<ThrowableObject>();
    }

    private void FixedUpdate()
    {
        topSpeed.text = "Fastest Speed: " + System.Math.Round(to.topSpeed, 2) + "m/s";
        speed.text = "Speed: " + System.Math.Round(to.speed, 2) + "m/s";
        mass.text = "Mass: " + System.Math.Round(to.mass, 2) + "kg";
    }
}
