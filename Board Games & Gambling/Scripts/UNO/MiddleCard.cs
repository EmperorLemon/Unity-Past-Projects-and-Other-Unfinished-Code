using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCard : MonoBehaviour
{
    public string color;
    public string value;

    public void GetCardValue()
    {
        string tempName;
        char[] splitters = { ' ' };
        string[] splitWords;

        tempName = gameObject.name;
        tempName = tempName.Replace("Centre Card:", "");
        splitWords = tempName.Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);

        color = splitWords[0];
        value = splitWords[1];
    }
}
