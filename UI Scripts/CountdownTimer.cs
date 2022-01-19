using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public ShootingManager manager;

    [HideInInspector]
    public float timer;
    [HideInInspector]
    public float maxTimer = 15f;

    private TextMesh countDownTimerText;

    private void Start()
    {
        countDownTimerText = GetComponent<TextMesh>();

        timer = maxTimer;
    }

    private void Update()
    {
        if (timer > 0 && manager.gameStarted)
        {
            timer -= Time.deltaTime;
            countDownTimerText.text = "00:" + Mathf.Round(timer);

            if (timer < 9.5f)
                countDownTimerText.text = "00:0" + Mathf.Round(timer);
        }
        else
        {
            manager.StopGame();
        }
    }
}
