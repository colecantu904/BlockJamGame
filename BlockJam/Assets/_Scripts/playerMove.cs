using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;

    //public GameObject destination;
    //public SpriteRenderer sr;

    [Header("variables")]
    public float movespeed = 5f;
    Vector2 movement;
    //public Rigidbody2D rb;
    public float distance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = playerMain.playerInput.xplayer;
        movement.y = playerMain.playerInput.yplayer;

        if (movement.sqrMagnitude > 0)
        {
            Move((Vector2)playerMain.renderer.bounds.size * movement * distance);
            playerMain.animator.SetTrigger("Dash");
        }
        
    }

    private void FixedUpdate()
    {
        playerMain.rigidobdy2D.position = Vector2.MoveTowards(playerMain.rigidobdy2D.position, playerMain.destination.transform.position, movespeed);
    }

    private void Move(Vector2 length)
    {
        playerMain.destination.transform.position = (Vector2)transform.position + length;
    }


}
