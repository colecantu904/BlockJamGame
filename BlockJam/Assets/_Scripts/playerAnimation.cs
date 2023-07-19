using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;


    // animations movement variables
    public float lastframetimer = 1000f;
    private float holdtimer;
    public AnimationClip sideDash;
    public AnimationClip downDash;


    void Start()
    {
        
    }

 
    void Update()
    {
        //flip the player in the right direction
        if (playerMain.rend.transform.position.x > 0)
        {
            playerMain.rend.flipX = true;
        }
        else
        {
            playerMain.rend.flipX = false;
        }


        if (playerMain.rend.transform.position.y > 0 && Input.GetKeyDown(KeyCode.S))
        {
            playerMain.rend.flipY = true;
        }
        else
        {
            playerMain.rend.flipY = false;
        }



        // horizantal dash
        if (playerMain.playerInput.xDown)
        {
            playerMain.animator.Play(sideDash.name, 0, sideDash.length);
        }

        // vertical dash
        if (playerMain.playerInput.yDown)
        {
            playerMain.animator.Play(downDash.name, 0, downDash.length);
        }
        

    }
}
