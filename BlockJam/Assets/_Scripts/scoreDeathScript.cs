using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDeathScript : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score: " + logicScript.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
