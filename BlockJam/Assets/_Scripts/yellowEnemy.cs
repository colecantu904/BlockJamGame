using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowEnemy : MonoBehaviour
{
    private Vector2 runLocation;

    public GameObject bomb;
    //[SerializeField] int delay = 2;
    private float holdTimer=0f;
    public float runSpeed = 2f;
    private bool attacking = true;
    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public Animator animator;


    [SerializeField] SlimeHealthBar SlimeHealthBar;
    [SerializeField] private playerMain playerMain;

    public int health = 30;
    private int currentHealth;


    private void Awake()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMain>();
        SlimeHealthBar = GetComponentInChildren<SlimeHealthBar>();
        SlimeHealthBar.setHealth(health);
    }


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ThrowBomb());
        StartCoroutine(Move());
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator ThrowBomb()
    {
        int delay = Random.Range(1, 3);
        yield return new WaitForSeconds(delay);
         animator.SetTrigger("punch");
         Instantiate(bomb, transform.position, transform.rotation);
    }
    private IEnumerator Move()
    {
        while (true)
        {
            int delay = Random.Range(4, 6);
            yield return new WaitForSeconds(delay-1);
            ;
            runLocation.x = Random.Range(-5f, 5f);
            runLocation.y = Random.Range(-5f, 5f);
            rb.position = runLocation;
            animator.SetTrigger("smoke");
            StartCoroutine(ThrowBomb());
        }
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

}
