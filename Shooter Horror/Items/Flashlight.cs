using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light flashLight;

    private void Start()
    {
        flashLight = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flashLight.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            flashLight.enabled = false;
        }
    }
}
