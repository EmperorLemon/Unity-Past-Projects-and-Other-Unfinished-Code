using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGround : MonoBehaviour
{
    public GameObject groundObj;

    [Range(0,10)]
    public int maxGround;

    Vector3 size = new Vector3(4, 1, 1);

    List<GameObject> grounds = new List<GameObject>();

    private void Start()
    {
        
    }

    private void Update()
    {
        if (grounds.Count < maxGround)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    for (int z = 0; z < size.z; z++)
                    {
                        GameObject newGround = Instantiate(groundObj);

                        grounds.Add(newGround);

                        newGround.transform.position = new Vector3(x * size.x * 2.5f, y * size.y, z * size.z * 2);

                        newGround.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                        newGround.transform.parent = transform;
                    }
                }
            }
        }
    }
}

 