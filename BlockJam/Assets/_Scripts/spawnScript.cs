using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    private float timer = 5f;
    private float holdtimer;
    public GameObject slime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private void FixedUpdate()
    {
        spawnSlime();
    }

    public void spawnSlime()
    {
        if (holdtimer < timer)
        {
            holdtimer += Time.deltaTime;
        }
        else
        {
            Instantiate(slime);
            holdtimer = 0;
        }
    }
}
