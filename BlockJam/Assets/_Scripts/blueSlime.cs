using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueSlime : MonoBehaviour
{
    [SerializeField] private playerMain playerMain;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private int health;
    private bool hit = false;
    [SerializeField] SlimeHealthBar SlimeHealthBar;
    public int slimeDamage = 3;
    public Vector2 direction;
    //public float delay = 3f;
    [SerializeField] public Vector2 delayValues;
    private float delay;
    [SerializeField]public float slimeSpeed = 5f;

    private void Awake()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMain>();
        SlimeHealthBar = GetComponentInChildren<SlimeHealthBar>();
        SlimeHealthBar.setHealth(health);

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move(playerMain.transform));
    }
    private IEnumerator Move(Transform dest)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if (!hit)
            {
                direction = (dest.position - transform.position).normalized;
                rb.velocity = direction * slimeSpeed;
            }

            delay = Random.Range(delayValues.x, delayValues.y);
        }
    }
    private void Update()
    {
      if (hit)
       {
            rb.velocity = playerMain.attackScript.shootLocation.transform.up;
            hit = false;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("hit");
        SlimeHealthBar.barDamage(damage);
        hit = true;
        if (health <= 0)
        {
            Destroy(gameObject);
            logicScript.badKilled += 1;
            if (playerMain.attackScript.heavyDashing)
            {
                logicScript.score += 200 * playerMain.logicScript.multiplier;
            }
            else
            {
                logicScript.score += 200;
            }
        }
    }
}
