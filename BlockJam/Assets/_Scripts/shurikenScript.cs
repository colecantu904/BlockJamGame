using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private float rotZ;
    public float rotSpeed = 5f;
    public playerMain playerMain;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * playerMain.shurikenSpeed;
    }
    private void Awake()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMain>();
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
        //Debug.Log("exited");
        if (collision.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<slimeScript>().TakeDamage(playerMain.shurikenDamage);
            Destroy(gameObject);
        }
    }
}
