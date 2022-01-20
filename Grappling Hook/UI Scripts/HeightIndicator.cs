using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeightIndicator : MonoBehaviour
{
    public Transform player;

    public Text heightLevelText;
    public Text highestLevelText;

    string heightLevel;
    float height;
    float highestLevel = 0;


    private void Start()
    {
    }

    private void Update()
    {
        if (player.position.y > highestLevel)
        {
            highestLevel = player.position.y;
        }
        

        height = player.transform.position.y;

        height = Mathf.Round(height);

        heightLevel = height.ToString();

        heightLevelText.text = "Height: " + heightLevel + " Meters";
        highestLevelText.text = "Highest Point: " + (int)highestLevel + " Meters";
    }
}
