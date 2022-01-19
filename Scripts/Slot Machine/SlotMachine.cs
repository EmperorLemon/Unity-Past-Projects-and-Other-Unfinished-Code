using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    private int[] slot;
    private readonly int[] slotChoices = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    private string[] slotDisplay;
    private readonly string[] slotDisplayChoices = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    public bool matchingValues;

    public Text slotOne, slotTwo, slotThree;

    private void Start()
    {
        slot = new int[3];
        slotDisplay = new string[3];
    }

    public void Spin()
    {
        int slotX = Random.Range(0, slotChoices.Length);
        int slotY = Random.Range(0, slotChoices.Length);
        int slotZ = Random.Range(0, slotChoices.Length);

        slot[0] = slotX;
        slot[1] = slotY;
        slot[2] = slotZ;


        //CheckValues();
    }

    public void SpinEffect()
    {
        for (int x = 0; x < slotChoices.Length; x++)
        {

        }
    }

    private void CheckValues()
    {
        if (slot[0] == slot[1] && slot[0] == slot[2] && slot[1] == slot[2])
        {
            matchingValues = true;
        }
        else
            matchingValues = false;
    }

    private void Update()
    {
        slotOne.text = slot[0].ToString();
        slotTwo.text = slot[1].ToString();
        slotThree.text = slot[2].ToString();
    }
}
