using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public TextAsset textAsset;

    [Header("Text")]
    public Transform textParent;
    private Text[] wordsDisplay;
    public GameObject wordObj;

    private string[] words;

    public char[] letters;

    public string randomWord;

    public int[] letterIndex;

    public bool isRight;

    public int wordLength;

    private char[] splitter;

    private HangmanGenerator hangman;
    private InputManager manager;

    private void Start()
    {
        splitter = new char[] { '\r', '\n' };
        words = textAsset.text.Split(splitter, System.StringSplitOptions.RemoveEmptyEntries);

        hangman = GetComponent<HangmanGenerator>();
        manager = GetComponent<InputManager>();

        PickRandomWord();
        CreateTextElements();
        HideRandomWord();
        DisplayRandomWord();
    }

    public void PickRandomWord()
    {
        randomWord = words[Random.Range(0, words.Length - 1)];
        wordLength = randomWord.Length - 1;

        letters = new char[wordLength];

        letterIndex = new int[wordLength];

        for (int i = 0; i < wordLength; i++)
            letters[i] = randomWord[i];
    }

    public void CreateTextElements()
    {
        for (int i = 0; i < wordLength; i++)
        {
            Instantiate(wordObj, textParent);
        }

        wordsDisplay = textParent.GetComponentsInChildren<Text>();
    }

    public void DisplayRandomWord()
    {
        for (int i = 0; i < wordLength; i++)
        {
            wordsDisplay[i].text = letters[i].ToString();

            wordsDisplay[i].transform.localPosition += new Vector3(80 * i, 0);
        }
    }

    public void HideRandomWord()
    {
        for (int i = 0; i < wordLength; i++)
        {
            wordsDisplay[i].gameObject.SetActive(false);
        }
    }

    public void DisplayCorrectLetters(char c)
    {
        for (int i = 0; i < wordLength; i++)
        {
            if (c.ToString().Contains(letters[i].ToString()))
            {
                wordsDisplay[i].gameObject.SetActive(true);
                letterIndex[i] = 1;
            }
            else
            {
                if (letterIndex[i] != 1)
                {
                    letterIndex[i] = -1;
                }
            }
        }

            hangman.LoseLife();
            hangman.DisplayHangman(Mathf.Abs(hangman.livesRemaining - 3));
    }
}
