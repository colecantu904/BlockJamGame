using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool hit = false;

    [Header("Variables")]
    public int slimeHealth = 30;
    public float slimeSpeed = 5f;
    public float slimeKnockback = 5f;
    public int slimeDamage = 3;
    public Vector2 direction;

    [Header("Objects")]
    [SerializeField] logicScript logicScript;
    [SerializeField] SlimeHealthBar SlimeHealthBar;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private playerMain playerMain;
    public AnimationClip slimeSpawn;
    public Animator animator;
    
    // componenets to retrieve through code: RigidBody, Animator
    // list of values for scriptable object: knockback, damage, moveSpeed, maxHealth, logicScript



    void Awake()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMain>();
        SlimeHealthBar = GetComponentInChildren<SlimeHealthBar>();
        health = slimeHealth;
        SlimeHealthBar.setHealth(health);

    }
    private void Start()
    {
        animator.SetTrigger("spawn");
    }

    private void FixedUpdate()
    {
        Move(playerMain.transform);
    }

    // Make an "Simple Movment" function that takes the 'destination gameobject' as well as the rb of enemy calling the function.
    // rewrite the code so that the component is called within the script and no the inspector.
    private void Move(Transform dest)
    {
        if (!hit)
        {
            direction = (dest.position - transform.position).normalized;
            rb.velocity = direction * slimeSpeed;
        }
        else if (hit)
        {
            rb.velocity = playerMain.attackScript.shootLocation.transform.up * slimeKnockback;
            hit = false;
        }
    }


    

    // redesign enemy code so that the fucntion derives from enemy class, takes damage and current health as a argument and returns new current health.
    public void TakeDamage(int damage)
    {
        health -= damage;
        SlimeHealthBar.barDamage(damage);
        hit = true;
        if (health <= 0)
        {
            Destroy(gameObject);
            logicScript.badKilled += 1;
            if (playerMain.attackScript.heavyDashing)
            {
                logicScript.score += 100 * logicScript.multiplier;
            }
            else
            {
                logicScript.score += 100;
            }
            
        }
    }
}
