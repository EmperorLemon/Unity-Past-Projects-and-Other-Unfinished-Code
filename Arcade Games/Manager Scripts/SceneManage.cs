using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("ARCADE");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
