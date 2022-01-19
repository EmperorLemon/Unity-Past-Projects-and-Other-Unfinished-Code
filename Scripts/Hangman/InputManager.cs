using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputField input;

    public Transform guessedWordParent;

    public Text guessedWordDisplay;

    public char guessedLetter;

    public List<char> guessedLetters = new List<char>();

    public List<Text> guessOutput = new List<Text>();

    private WordGenerator generator;

    private int inc = 0;

    private void Start()
    {
        generator = GetComponent<WordGenerator>();

        guessedLetters.Clear();
    }

    public void UpdateList()
    {
        guessedLetter = input.text.ToCharArray()[0];

        if (!guessedLetters.Contains(guessedLetter))
        {
            guessedLetters.Add(guessedLetter);

            Text newWord = Instantiate(guessedWordDisplay, guessedWordParent);

            guessOutput.Add(newWord);

            newWord.text = guessedLetter.ToString();

            guessOutput[inc].transform.localPosition += new Vector3(80 * inc, 0);

            inc++;
        }
    }

    public void CheckWordGuess()
    {
        generator.DisplayCorrectLetters(guessedLetter);
    }
}
