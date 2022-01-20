using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMachine : MonoBehaviour
{
    public GameObject player;
    public GameObject cursor;

    public Camera clawCamera;
    public Camera hockeyCamera;
    public Camera stackCamera;

    private ClawMovement clawMovement;
    private HockeyGame hockeyGame;
    private StackGame stackGame;

    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();

        clawMovement = FindObjectOfType<ClawMovement>();
        hockeyGame = FindObjectOfType<HockeyGame>();
        stackGame = FindObjectOfType<StackGame>();

        if (hockeyGame != null)
            DisableHockeyGame();

        if (clawMovement != null)
            DisableClawGame();

        if (stackGame != null)
            DisableStackerGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateGame();
        }
    }

    private void ActivateGame()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            if (hit.collider.CompareTag("Claw Machine"))
            {
                ActivateClawGame();
            }

            if (hit.collider.CompareTag("Stacker Machine"))
            {
                ActivateStackerGame();
            }

            if (hit.collider.CompareTag("Hockey Machine"))
            {
                ActivateHockeyGame();
            }
        }
    }

    void ActivateClawGame()
    {
        clawMovement.enabled = true;
        clawCamera.enabled = true;
        clawCamera.gameObject.SetActive(true);
        playerCamera.enabled = false;
        player.SetActive(false);
    }

    void ActivateHockeyGame()
    {
        hockeyGame.enabled = true;
        hockeyCamera.enabled = true;
        hockeyCamera.gameObject.SetActive(true);
        playerCamera.enabled = false;
        player.SetActive(false);
        cursor.SetActive(false);
    }

    void ActivateStackerGame()
    {
        stackGame.enabled = true;
        stackCamera.enabled = true;
        stackCamera.gameObject.SetActive(true);
        playerCamera.enabled = false;
        player.SetActive(false);
    }

    void DisableClawGame()
    {
        clawMovement.enabled = false;
        clawCamera.enabled = false;
        clawCamera.gameObject.SetActive(false);
    }

    void DisableStackerGame()
    {
        stackGame.enabled = false;
        stackCamera.enabled = false;
        stackCamera.gameObject.SetActive(false);
    }

    void DisableHockeyGame()
    {
        hockeyGame.enabled = false;
        hockeyCamera.enabled = false;
        hockeyCamera.gameObject.SetActive(false);
        cursor.SetActive(true);
    }
}
