using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private playerMain playerMain;
    [SerializeField] private int health;
    private bool hit = false;
    void Awake()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMain>();
        health = playerMain.slimeHealth;
    }
    private void FixedUpdate()
    {
        Move(playerMain.transform);
    }
    private void Move(Transform dest)
    {
        if (!hit)
        {
            Vector2 direction = (dest.position - transform.position).normalized;
            rb.velocity = direction * playerMain.slimeSpeed;
        }
        else if (hit)
        {
            rb.velocity = playerMain.shootLocation.transform.up * playerMain.slimeKnockback;
            hit = false;
        }
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Hit");
        health-=damage;
        hit = true;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
