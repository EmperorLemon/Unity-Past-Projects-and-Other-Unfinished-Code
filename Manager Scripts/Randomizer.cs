using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject cube;
    public Transform cubeParent;

    public GameObject coin;
    public Transform coinParent;

    [Range(0,200)]
    public int maxCubes;

    [Range(0,30)]
    public int maxCoins;

 //   [Header("X")]
    float minX, maxX;

   // [Header("Y")]
    float minY, maxY;

    // [Header("Z")]
    float minZ, maxZ;

    Vector3 randomCubeSpawn;
    Vector3 randomCoinSpawn;

    bool colorChanged = false;

    List<GameObject> grabCubes = new List<GameObject>();
    List<GameObject> grabbles = new List<GameObject>();
    List<GameObject> coins = new List<GameObject>();

    // ObjectPooling objectPooler;

    private void Awake()
    {
        // objectPooler = ObjectPooling.Instance;

        minX = 10;
        maxX = 95;

        minY = 15;
        maxY = 300;

        minZ = -40;
        maxZ = -10;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && colorChanged == false)
        {
            RandomizeColors();

            colorChanged = true;
        }

        grabCubes.AddRange(GameObject.FindGameObjectsWithTag("Hookable"));

        randomCubeSpawn = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        randomCoinSpawn = new Vector3(Random.Range(minX, maxX), Random.Range(minY + 2, maxY + 2), Random.Range(minZ, maxZ));

        if (coins.Count < maxCoins)
        {
            RandomizeCoins();
        }

        if (grabbles.Count < maxCubes)
        {
            RandomizeGrappleObjects();
        }

    }

    private void FixedUpdate()
    {
        // objectPooler.SpawnFromPool("Ball", transform.position, Quaternion.identity);
    }

    public void RandomizeGrappleObjects()
    {
        GameObject newCube = Instantiate(cube, randomCubeSpawn, Quaternion.identity);

        newCube.transform.parent = cubeParent;

        grabbles.Add(newCube);
    }

    public void RandomizeCoins()
    {
        GameObject newCoin = Instantiate(coin, randomCoinSpawn, Quaternion.identity);

        newCoin.transform.parent = coinParent;

        coins.Add(newCoin);
    }

    public void RandomizeColors()
    {
        for (int i = 0; i < grabCubes.Count; i++)
        {
            grabCubes[i].GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
