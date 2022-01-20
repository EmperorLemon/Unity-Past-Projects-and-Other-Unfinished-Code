using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HangmanGenerator : MonoBehaviour
{
    public int livesRemaining;

    public Text livesText;

    public GameObject hangmanParent;

    public GameObject[] hangman;

    private readonly int lives = 4;

    private WordGenerator wordGenerator;


    private void Start()
    {
        livesRemaining = lives;
        wordGenerator = GetComponent<WordGenerator>();

        hangman = GameObject.FindGameObjectsWithTag("Hangman");

        for (int i = 0; i < hangman.Length; i++)
        {
            hangman[i].SetActive(false);
        }
    }

    private void Update()
    {
        livesText.text = "Lives Remaining: " + livesRemaining;
    }

    public void LoseLife()
    {
        if (livesRemaining > 0)
            livesRemaining -= 1;
    }

    public void DisplayHangman(int index)
    {
        hangman[index].SetActive(true);
    }
}
