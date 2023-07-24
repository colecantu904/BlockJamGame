using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2;
    Vector2 vect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vect.x = Input.GetAxisRaw("Horizontal");
        vect.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            rb.AddForce(Vector2.up * speed * vect.y);
        }


    }
    private void Dash(int direction)
    {
        rb.AddForce(Vector2.up * speed *direction);
        Debug.Log("sfgsdh");
    }
}
