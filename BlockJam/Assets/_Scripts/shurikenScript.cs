using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f;
    private float rotZ;
    public float rotSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rotZ += Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }


    // destroy when it reaches the game boundary
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exited");
        if (collision.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
}
