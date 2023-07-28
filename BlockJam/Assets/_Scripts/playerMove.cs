using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class playerMove : MonoBehaviour
{
    [SerializeField] playerMain playerMain;
    private bool outOfBounds = false;

    [Header("Objects")]
    public GameObject destination;
    public Rigidbody2D playerRigidbody2D;
    public GameObject Player;
    public GameObject Spawner;



    [Header("variables")]
    public float movespeed = 5f;
    Vector2 movement;
    public float distance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        destination.transform.position = playerRigidbody2D.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = playerMain.playerInput.xplayer;
        movement.y = playerMain.playerInput.yplayer;
        if (movement.sqrMagnitude > 0)
        {
            if ((playerMain.playerInput.xDown || playerMain.playerInput.yDown) && !playerMain.attackScript.heavyDashing && !playerMain.attackScript.isDamaged &&!outOfBounds)
            {
                Move((Vector2)playerMain.GetComponent<Renderer>().bounds.size * movement * distance);
            }
            
            
        }
        
    }

    private void FixedUpdate()
    {
        if (!outOfBounds) playerRigidbody2D.position = Vector2.MoveTowards(playerRigidbody2D.position, destination.transform.position, movespeed);
        else if (outOfBounds)
        {
            destination.transform.position = playerRigidbody2D.transform.position;
            playerRigidbody2D.position = Vector2.MoveTowards(transform.position, Spawner.transform.position, movespeed);

        }
    }

    public void Move(Vector2 length)
    {
        destination.transform.position = (Vector2)transform.position + length;
        
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
