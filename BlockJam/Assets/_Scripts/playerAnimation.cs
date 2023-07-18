using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;


    // animations movement variables
    public float lastframetimer = 1f;
    private float holdtimer;
    public AnimationClip sideDash;
    public AnimationClip downDash;


    void Start()
    {
        
    }

 
    void Update()
    {
        // horizantal dash
        if (playerMain.playerInput.xDown)
        {
            if (holdtimer > lastframetimer)
            {
                playerMain.animator.SetTrigger("sideDash");
                holdtimer += Time.deltaTime;
            }
            else
            {
                playerMain.animator.Play(sideDash.name, 0, sideDash.length);
            }

        }

        // vertical dash
        if (playerMain.playerInput.yDown)
        {
            if (holdtimer > lastframetimer)
            {
                playerMain.animator.SetTrigger("upDash");
                holdtimer += Time.deltaTime;
            }
            else
            {
                playerMain.animator.Play(downDash.name, 0, downDash.length);
            }
        }
        holdtimer = 0;

    }
}
