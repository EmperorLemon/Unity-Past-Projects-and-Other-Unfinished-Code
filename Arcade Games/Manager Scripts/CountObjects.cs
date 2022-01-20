using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountObjects : MonoBehaviour
{
    public List<GameObject> throwables = new List<GameObject>();

    public void AddObjectCount(GameObject obj)
    {
        throwables.Add(obj);
    }
}
