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
        playerMain.shootLocation.transform.position = playerMain.playerRigidbody2D.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
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
        Instantiate(playerMain.shurikenGameObject,playerMain.shootLocation.transform.position,playerMain.shootLocation.transform.rotation);
        Debug.Log("shurkiken");
    }

    public void slice()
    {
        playerMain.animator.SetTrigger("Attack");
        Debug.Log("slice");
    }

    public void heavyslice()
    {
        Debug.Log("HeavySlice");
    }
}
