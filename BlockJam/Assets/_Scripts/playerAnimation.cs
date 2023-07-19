using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;


    // animations movement variables
    private float holdtimer;


    void Start()
    {
        
    }

 
    void Update()
    {
        //flip the player in the right direction for idle
        if (playerMain.rend.transform.position.x > 0)
        {
            playerMain.rend.flipX = true;
        }
        else
        {
            playerMain.rend.flipX = false;
        }



        // horizantal dash "animation"
        if (playerMain.playerInput.xDown)
        {
            if ((playerMain.playerInput.xplayer == -1 && playerMain.rend.transform.position.x < 0) || (playerMain.playerInput.xplayer == 1 && playerMain.rend.transform.position.x > 0))
            {
                playerMain.animator.SetTrigger("dash2");
                
            }
            else
            {
                playerMain.animator.SetTrigger("dash1");
            }
            
        }

        // vertical dash "animation"
        if (playerMain.playerInput.yDown)
        {
            if (playerMain.playerInput.yplayer == -1)
            {
                playerMain.animator.SetTrigger("updash2");
            }
            else
            {
                playerMain.animator.SetTrigger("updash1");
            }
        }
        

    }
}
