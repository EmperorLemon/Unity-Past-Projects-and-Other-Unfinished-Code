using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    [SerializeField]
    public Text[] scoreOneText;
    [SerializeField]
    public Text[] scoreTwoText;

    private BowlingManager manager;
    private PinManager pManager;

    private void Start()
    {
        manager = GetComponent<BowlingManager>();
        pManager = GetComponent<PinManager>();

        foreach (Text to in scoreOneText)
        {
            to.gameObject.SetActive(false);
        }
        
        foreach (Text to in scoreTwoText)
        {
            to.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (manager.turnsTaken[x] == 1 && !manager.rolling[x])
                {
                    scoreOneText[manager.timesReset].gameObject.SetActive(true);
                    scoreOneText[manager.timesReset].text = manager.scoreOne[x].ToString();
                }
                else if (manager.turnsTaken[x] == 2 && !manager.rolling[x])
                {
                    scoreTwoText[manager.timesReset].gameObject.SetActive(true);
                    scoreTwoText[manager.timesReset].text = manager.scoreTwo[x].ToString();
                }
            }
        }
    }
}
