using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject line;
    public Transform lineParent;

    public Transform[] lines;

    private WordGenerator wordGenerator;

    private void Start()
    {
        wordGenerator = GetComponent<WordGenerator>();

        for (int i = 0; i < wordGenerator.wordLength; i++)
        {
            Instantiate(line, lineParent);
        }

        lines = lineParent.GetComponentsInChildren<Transform>();

        for (int i = 0; i < wordGenerator.wordLength; i++)
        {
            lines[i].localPosition += new Vector3(80 * i,0);
        }
    }
}
