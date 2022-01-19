using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum DifficultyLevel { EASY, MEDIUM, HARD, EXPERT};

public class GameManager : MonoBehaviour
{
    public BeatScroller bs;

    public GameObject pausePanel;

    public GameObject keyStartAdvice;

    public GameObject game;

    public AudioSource musicPlayer;
    private AudioClip music;

    public static GameManager instance;

    public Text scoreText;
    public Text multiplierText;

    public bool startPlaying;

    [HideInInspector]
    public int currentScore;
    public int scorePerNote = 50;
    public int scorePerGoodNote = 100;
    public int scorePerPerfectNote = 300;

    [HideInInspector]
    public int bpm;

    private int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    private int totalNotes;
    private int normalHits;
    private int goodHits;
    private int perfectHits;
    private int missedHits;

    private bool fullCombo;

    public GameObject resultsScreen;
    public Text percentHitText, normalText, goodText, perfectText, missText, rankText, finalScoreText;

    private void Start()
    {
        instance = this;

        music = musicPlayer.GetComponent<AudioClip>();

        scoreText.text = "Score: 0";
        multiplierText.text = "Multiplier: x1";

        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<Note>().Length;
    }


    private void Update()
    {
        if (!startPlaying)
        {
            game.SetActive(false);
            keyStartAdvice.SetActive(true);

            if (Input.anyKeyDown)
            {
                startPlaying = true;
                bs.hasStarted = true;
                keyStartAdvice.SetActive(false);
                game.SetActive(true);

                musicPlayer.Play();
            }
        }
        else
        {
            if (!musicPlayer.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                game.SetActive(false);

                normalText.text = "" + normalHits;
                goodText.text = "" + goodHits;
                perfectText.text = "" + perfectHits;
                missText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100;

                percentHitText.text = percentHit.ToString("F1") + " %";

                string rankVal = "F";

                if (percentHit > 40)
                {
                    rankVal = "D";

                    if (percentHit >= 50)
                    {
                        rankVal = "C";

                        if (percentHit >= 65)
                        {
                            rankVal = "B";

                            if (percentHit >= 75)
                            {
                                rankVal = "A";

                                if (percentHit >= 90)
                                {
                                    rankVal = "S";

                                    if (percentHit == 100)
                                    {
                                        rankVal = "SS";
                                        fullCombo = true;
                                    }
                                }

                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                // PauseGame();
            }
            else
            {
                // ContinueGame();
            }
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
    }

    void ContinueGame()
    {
        pausePanel.SetActive(false);
    }

    public void NoteHit()
    {
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiplierText.text = "Multiplier: " + "x" + currentMultiplier;

        // currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
    {
        print("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiplierText.text = "Multiplier: " + "x" + currentMultiplier;

        missedHits++;
    }
}
