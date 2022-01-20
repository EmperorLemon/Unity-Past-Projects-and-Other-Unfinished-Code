using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            var lightSwitch = FindObjectOfType<Light>();
            lightSwitch.gameObject.SetActive(false);
        }
    }
}
