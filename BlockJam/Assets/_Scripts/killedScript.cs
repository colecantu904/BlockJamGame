using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class killedScript : MonoBehaviour
{
    public TMP_Text text;


    // Start is called before the first frame update
    void Start()
    {
        text.text = "Enemies Killed: " + logicScript.badKilled.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
