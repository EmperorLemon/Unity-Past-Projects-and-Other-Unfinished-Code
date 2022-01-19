using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static int x, y;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Save(int playerWinStreak, int dealerWinStreak)
    {
        PlayerPrefs.SetInt("Player Wins", playerWinStreak);
        PlayerPrefs.SetInt("Dealer Wins", dealerWinStreak);

        PlayerPrefs.Save();

        Debug.Log("Game Saved");
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Player Wins") && PlayerPrefs.HasKey("Dealer Wins"))
        {
            x = PlayerPrefs.GetInt("Player Wins");
            y = PlayerPrefs.GetInt("Dealer Wins");

            Debug.Log("Load Complete");
        }
        else
            Debug.LogError("No Load Detected");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();

        x = 0;
        y = 0;
    }
}
