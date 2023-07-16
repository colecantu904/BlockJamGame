using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    [SerializeField]
    playerMain playermain;

    // movement variables
    internal float xplayer;
    internal float yplayer;

    // attack variables
    internal bool jPressed;
    internal bool kPressed;
    internal bool lPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xplayer = Input.GetAxisRaw("Horizontal");
        yplayer = Input.GetAxisRaw("Vertical");


    }
}
