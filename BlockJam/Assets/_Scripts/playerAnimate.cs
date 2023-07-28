using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimate : MonoBehaviour
{
    [SerializeField]
    internal playerMain playerMain;

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


        if (playerMain.attackScript.heavyDashing)
        {
            // make the heavy dash animation bruh
            playerMain.animator.SetTrigger("heavyDash");
        }
        else if (!playerMain.attackScript.isDamaged)
        {
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
}
