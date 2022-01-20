using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public CountdownTimer countdown;

    [HideInInspector]
    public bool gameStarted;

    private TargetMovement[] targets;
    private Gune[] guns;

    private void Start()
    {
        guns = FindObjectsOfType<Gune>();
        targets = FindObjectsOfType<TargetMovement>();
    }

    public void StartGame()
    {
        for (int i = 0; i < targets.Length; i++)
            targets[i].MoveTargets();

        gameStarted = true;

        countdown.timer = countdown.maxTimer;
    }

    public void StopGame()
    {
        for (int i = 0; i < targets.Length; i++)
            targets[i].ResetPosition();

        for (int i = 0; i < guns.Length; i++)
            guns[i].SetStartPosition();

        gameStarted = false;
    }
}
