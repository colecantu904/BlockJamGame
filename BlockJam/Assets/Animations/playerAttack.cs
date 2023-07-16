using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMain.playerInput.shurikenDown)
        {
            shuriken();
        }
        if (playerMain.playerInput.sliceDown)
        {
            slice();
        }
        if (playerMain.playerInput.heavySliceDown)
        {
            heavyslice();
        }
    }

    public void shuriken()
    {
        Debug.Log("shurkiken");
    }

    public void slice()
    {
        playerMain.animator.SetTrigger("Attack");
    }

    public void heavyslice()
    {
        Debug.Log("HeavySlice");
    }
}
