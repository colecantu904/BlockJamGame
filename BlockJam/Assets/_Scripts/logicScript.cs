using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicScript : MonoBehaviour
{

    public static int score, badKilled;
    public int multiplier = 5;

    void Awake()
    {
        score = 0;
        badKilled = 0;
    }

}
