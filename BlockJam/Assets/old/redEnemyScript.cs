using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redEnemyScript : MonoBehaviour
{
    private Vector2 runLocation;
    private float holdTimer;
    public float runSpeed = .5f;
    public float delaytime = 2;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    [SerializeField] Animator animator;
    [SerializeField] SlimeHealthBar SlimeHealthBar;
    [SerializeField] private playerMain playerMain;

    [SerializeField] public int damage = 5;

    public int time;
    private bool attacking;
    private int animations;
    public float attackRadius = 2f;
    private bool redAttacking = false;

    public int health = 30;
    private int currentHealth;

    private void Awake()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMain>();
        SlimeHealthBar = GetComponentInChildren<SlimeHealthBar>();
        SlimeHealthBar.setHealth(health);

    }
    void Start()
    {
       // animator.SetTrigger("smoke");
        currentHealth = health;
        runLocation = transform.position;
    }

    void Update()
    {
        if (transform.position.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        moveLocation();
    }

    private void FixedUpdate()
    {
        move();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        SlimeHealthBar.barDamage(damage);
        if (health <= 0)
        {
            Destroy(gameObject);
            logicScript.badKilled += 1;
            if (playerMain.attackScript.heavyDashing)
            {
                logicScript.score += 300 * playerMain.logicScript.multiplier;
            }
            else
            {
                logicScript.score += 300;
            }
        }
    }
 
    public void move()
    {
        if (!attacking)
        {
            rb.position = Vector2.MoveTowards(rb.position, runLocation, runSpeed);
            if (rb.position.y == runLocation.y)
            {
                Debug.Log("stop running");
                animator.SetBool("run", false);
            }
        }
    }

    public void moveLocation()
    {
        if (!attacking)
        {
            int _time = Random.Range(3, 8);
            if (holdTimer < _time)
            {
                holdTimer += Time.deltaTime;
            }
            else
            {
                runLocation.x = Random.Range(-8f, 8f);
                runLocation.y = Random.Range(-8f, 8f);
                animator.SetBool("run", true);
                holdTimer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(slice());
        }
    }

    private IEnumerator slice()
    {
        holdTimer = 0;
        runLocation = transform.position;   
        attacking = true;
        animations = Random.Range(0, 2);
        if (animations == 0)
        {
            animator.SetTrigger("slice");
        }
        else
        {
            animator.SetTrigger("stab");
        }

        
        yield return new WaitForSeconds(delaytime);
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach (Collider2D player in hitplayer)
        {
            if (player.tag == "Player")
            {
                playerMain.HealthScript.takeDamage(damage,this.gameObject);
            }
        }
        attacking = false;
    }


}
