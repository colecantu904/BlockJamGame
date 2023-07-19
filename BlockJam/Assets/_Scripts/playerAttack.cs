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
        playerMain.heavyDashing = true;

        StartCoroutine(HeavyDash(playerMain.heavyDashDelay));
    }
    private IEnumerator HeavyDash(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("ashgsdfh");
        playerMain.GetComponent<playerMove>().Move(playerMain.shootLocation.transform.up * playerMain.heavyDashDistance);
        StartCoroutine(DontMoveYet());
        playerMain.playerRigidbody2D.position = Vector2.MoveTowards(playerMain.playerRigidbody2D.position, playerMain.destination.transform.position, playerMain.heavyDashSpeed);
    }
    private IEnumerator DontMoveYet()
    {
        Debug.Log("not move");

        yield return new WaitForSeconds(playerMain.heavyDashDelay);
        playerMain.heavyDashing=false;
    }
}
