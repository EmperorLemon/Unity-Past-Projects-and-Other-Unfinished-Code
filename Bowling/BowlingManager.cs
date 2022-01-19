using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BowlingManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] lanes = new GameObject[5];
    [HideInInspector]
    public GameObject[] triggers = new GameObject[5];

    [HideInInspector]
    public bool[] rolling = new bool[5];
    [HideInInspector]
    public bool[] rollingAgain = new bool[5];

    public int[] turnsTaken = new int[5];

    [HideInInspector]
    public int[] pinsKnockedOne = new int[5];
    [HideInInspector]
    public int[] pinsKnockedTwo = new int[5];

    public bool[] strike;
    public bool[] spare;

    [Header("New Shit")]
    public int[] scoreOne;
    public int[] scoreTwo;

    public bool reset = false;
    public int timesReset;

    private PinManager manager;

    private void Start()
    {
        strike = new bool[5];
        spare = new bool[5];

        scoreOne = new int[5];
        scoreTwo = new int[5];

        manager = GetComponent<PinManager>();
    }

    private void Update()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (rolling[x])
                {
                    turnsTaken[x] = 1;

                    if (rollingAgain[x])
                    {
                        turnsTaken[x] = 2;
                    }
                }

                if (turnsTaken[x] == 1 && !rolling[x])
                {
                    triggers[x].SetActive(true);
                    pinsKnockedOne[x] = manager.knockedPins[x].knockedPins.Count;
                    scoreOne[x] = pinsKnockedOne[x];
                }
                else if (turnsTaken[x] == 2 && !rollingAgain[x])
                {
                    triggers[x].SetActive(false);
                    pinsKnockedTwo[x] = manager.knockedPins[x].knockedPins.Count - pinsKnockedOne[x];
                    scoreTwo[x] = pinsKnockedTwo[x];

                    reset = false;

                    if (scoreOne[x] + scoreTwo[x] == 10)
                    {
                        spare[x] = true;
                    }

                    if (!reset)
                        StartCoroutine(ResetLane(x, y));
                }

                strike[0] = !manager.pins[0][y].isStanding;
                strike[1] = !manager.pins[1][y].isStanding;
                strike[2] = !manager.pins[2][y].isStanding;
                strike[3] = !manager.pins[3][y].isStanding;
                strike[4] = !manager.pins[4][y].isStanding;
            }
        }
    }

    IEnumerator ResetLane(int x, int y)
    {
        yield return new WaitForSeconds(5f);

        turnsTaken[x] = 0;

        reset = true;

        timesReset++;

        if (manager.pins[x][y] != null)
        {
            for (int i = 0; i < 10; i++)
            {
                Destroy(manager.pins[x][i].gameObject);
            }
        }

        SpawnLane(x, y);    
        
    }

    void SpawnLane(int x, int y)
    {
        if (manager.pins[x][y] != null)
        {
            Pin newPins = Instantiate(manager.pins[x][y], manager.pins[x][y].transform.position, Quaternion.identity);
        }
    }
}
