using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool active = true;

    public GameObject x;
    public GameObject o;

    public TicTacToe tictactoe;

    private void OnMouseDown()
    {
        if (!active)
        {
            active = false;
            tictactoe.currentTurn++;
            DetermineObject();
        }
    }

    public void DetermineObject()
    {
        if (tictactoe.currentTurn % 2 == 0)
            x.SetActive(true);
        else if (tictactoe.currentTurn % 2 == 1)
            o.SetActive(true);
    }
}
