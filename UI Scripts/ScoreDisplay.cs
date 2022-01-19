using System.Collections;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public GunScript gunScript;

    private TextMesh scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMesh>();
    }

    private void Update()
    {
        scoreText.text = Mathf.Round(gunScript.totalScore).ToString();
    }
}
