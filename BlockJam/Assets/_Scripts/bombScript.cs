using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public float timer = 2f;
    public float deathTime = .2f;   
    public Animator animator;
    public float attackRadius = 6f;
    [SerializeField] public float speed=5f;
    [SerializeField] private Vector2 destination;
    public Rigidbody2D rb;


    private void FixedUpdate()
    {
        Move();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(explode());
        destination = GameObject.FindGameObjectWithTag("Player").transform.position;

    }

    public IEnumerator explode()
    {
        yield return new WaitForSeconds(timer);
        animator.SetTrigger("explode");
            
        Collider2D[] hitplayers = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach (Collider2D player in hitplayers)
        {
            Debug.Log("doing");
            if (player.tag == "Player")
            {
                FindObjectOfType<playerMain>().HealthScript.takeDamage(5, GameObject.FindGameObjectWithTag("red"));
            }
        }

        StartCoroutine(despawn());
    }
    
    private IEnumerator despawn()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
    private void Move()
    {
        rb.position = Vector2.MoveTowards(rb.position, destination, speed);
    }
}
