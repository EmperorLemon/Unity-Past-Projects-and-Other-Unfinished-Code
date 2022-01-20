using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class UnoCard
{
    public GameObject CardGameObject
    {
        get { return CardObject; }
        set { CardObject = value; }
    }

    public string CardColor
    {
        get { return Color; }
        set { Color = value; }
    }

    public string CardValue
    {
        get { return Value; }
        set { Value = value; }
    }

    public bool CardBack
    {
        get { return Hidden; }
        set { Hidden = value; }
    }

    [SerializeField]
    public string Color;
    [SerializeField]
    public string Value;
    [SerializeField]
    public bool Hidden;
    [SerializeField]
    public GameObject CardObject;
}
