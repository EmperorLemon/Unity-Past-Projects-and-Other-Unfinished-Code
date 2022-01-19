using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject panel;

    public Button[] buttons;

    public bool hasSaveData;

    private SaveLoad loadSave;

    void Start()
    {
        panel.SetActive(false);

        loadSave = FindObjectOfType<SaveLoad>();
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("Player Wins") || PlayerPrefs.HasKey("Dealer Wins"))
            hasSaveData = true;
    }

    public void StartGame()
    {
        if (hasSaveData)
            PopupWarning();
        else
            SceneManager.LoadScene("Blackjack");
    }

    public void LoadGame()
    {
        if (hasSaveData)
            loadSave.Load();
        else
            Debug.LogWarning("No Save Detected");

        print("Number of wins for player: " + SaveLoad.x);
        print("Number of wins for dealer: " + SaveLoad.y);
    }

    public void PlayUNO()
    {
        SceneManager.LoadScene("UNO");
    }

    public void PlaySlots()
    {
        SceneManager.LoadScene("Slot Machine");
    }

    private void PopupWarning()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = false;

        panel.SetActive(true);
    }

    public void Accept()
    {
        loadSave.Reset();

        SceneManager.LoadScene("Blackjack");
    }

    public void ClosePanel()
    {
        panel.SetActive(false);

        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = true;
    }

    public static void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
