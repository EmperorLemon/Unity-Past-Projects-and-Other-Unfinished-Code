using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ListWrapperTwo
{
    // public List<string> standingPins;
}

[System.Serializable]
public class ListWrapper
{
    public List<string> knockedPins;
}

public class PinManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] pinParents;
    public Pin[][] pins;

    public List<ListWrapper> knockedPins = new List<ListWrapper>();

    private void Start()
    {
        pins = new Pin[5][];

        pins[0] = pinParents[0].GetComponentsInChildren<Pin>();
        pins[1] = pinParents[1].GetComponentsInChildren<Pin>();
        pins[2] = pinParents[2].GetComponentsInChildren<Pin>();
        pins[3] = pinParents[3].GetComponentsInChildren<Pin>();
        pins[4] = pinParents[4].GetComponentsInChildren<Pin>();
    }

    private void Update()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (pins[x][y] != null)
                {
                    if (!pins[x][y].isStanding)
                    {
                        if (!knockedPins[x].knockedPins.Contains(pins[x][y].name))
                        {
                            knockedPins[x].knockedPins.Add(pins[x][y].name);
                        }
                    }
                }

            }
        }
    }
}
