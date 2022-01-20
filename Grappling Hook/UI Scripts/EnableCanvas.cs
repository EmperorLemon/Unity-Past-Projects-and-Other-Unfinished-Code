using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvas : MonoBehaviour
{
    public GameObject canvas;

    private void Update()
    {
        if (!canvas.activeInHierarchy)
        {
            canvas.SetActive(true);
        }
    }
}
