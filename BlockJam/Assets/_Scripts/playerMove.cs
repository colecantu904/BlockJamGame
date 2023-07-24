using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;
    [SerializeField] public GameObject Spawner;
    private bool outOfBounds = false;

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
        playerMain.destination.transform.position = playerMain.playerRigidbody2D.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = playerMain.playerInput.xplayer;
        movement.y = playerMain.playerInput.yplayer;
        if (movement.sqrMagnitude > 0)
        {
            if ((playerMain.playerInput.xDown || playerMain.playerInput.yDown) && !playerMain.heavyDashing && !playerMain.isDamaged&&!outOfBounds)
            {
                Move((Vector2)playerMain.GetComponent<Renderer>().bounds.size * movement * distance);
            }
            
            
        }
        
    }

    private void FixedUpdate()
    {
        if (!outOfBounds) playerMain.playerRigidbody2D.position = Vector2.MoveTowards(playerMain.playerRigidbody2D.position, playerMain.destination.transform.position, movespeed);
        else if (outOfBounds)
        {
            playerMain.destination.transform.position = playerMain.playerRigidbody2D.transform.position;
            playerMain.playerRigidbody2D.position = Vector2.MoveTowards(transform.position, Spawner.transform.position, movespeed);

        }
    }

    public void Move(Vector2 length)
    {
        playerMain.destination.transform.position = (Vector2)transform.position + length;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.tag == "bounds")
        {
            outOfBounds = true;

            Debug.Log("sagfdg");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bounds")
        {
            outOfBounds = false;
        }
    }
}
