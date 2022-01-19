using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnBowlingBall : MonoBehaviour
{
    public GameObject bowlingBall;
    public Transform[] ballSpawnPositions;

    List<GameObject> bowlingBallsOne = new List<GameObject>();
    List<GameObject> bowlingBallsTwo = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnBalls(4));
    }

    public IEnumerator SpawnBalls(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (bowlingBallsOne.Count <= amount && bowlingBallsTwo.Count <= amount)
            {
                GameObject newBall = Instantiate(bowlingBall, ballSpawnPositions[0].position, Quaternion.identity);
                GameObject newBallTwo = Instantiate(bowlingBall, ballSpawnPositions[1].position, Quaternion.identity);

                Color newBallColor = newBall.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                Color newBallTwoColor = newBallTwo.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                bowlingBallsOne.Add(newBall);
                bowlingBallsTwo.Add(newBallTwo);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
