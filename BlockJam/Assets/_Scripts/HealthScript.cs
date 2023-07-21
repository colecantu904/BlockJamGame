using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int playerHealth = 10;
    private int health;

    [SerializeField]
    playerMain playerMain;

    [SerializeField]
    PlayerBar playerhealthbar;

    [SerializeField]
    sceneLoaderScript sceneLoader;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerhealthbar = GetComponentInChildren<PlayerBar>();
        health = playerHealth;
        playerhealthbar.setHealth(playerHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            playerhealthbar.barDamage(collision.collider.GetComponent<slimeScript>().slimeDamage);
            health -= collision.collider.GetComponent<slimeScript>().slimeDamage;
            if (health <= 0)
            {
                sceneLoader.deathScene();
            }

        }
    }



   
}
