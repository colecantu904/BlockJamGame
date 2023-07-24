using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 5;
    public LayerMask enemylays;
    public Transform attacPoint;
    public Rigidbody2D rb;
    
    public float speed = 5;
    Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Attack();
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * speed);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attac");
            Collider2D[] enemyhit = Physics2D.OverlapCircleAll(attacPoint.position, attackRange, enemylays);

            foreach (Collider2D enemy in enemyhit)
            {
                enemy.GetComponent<goblin>().takeDamge(20);
            }
        }


    }
}
