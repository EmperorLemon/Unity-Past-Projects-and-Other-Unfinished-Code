using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayMovement : MonoBehaviour
{
    public Image groundedImage;
    public Image midairImage;

    private void Start()
    {
    }

    private void Update()
    {
        if (PlayerMovement.isGrounded == true)
        {
            groundedImage.enabled = true;
            midairImage.enabled = false;
        }
        else
        {
            groundedImage.enabled = false;
            midairImage.enabled = true;
        }
    }
}
