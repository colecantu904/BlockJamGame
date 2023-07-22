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

    public AnimationClip damaged;
    public float hurtTime = 1f;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerhealthbar = GetComponentInChildren<PlayerBar>();
        health = playerHealth;
        playerhealthbar.setHealth(playerHealth);

        playerMain.badKilled = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            StartCoroutine(knockback());

            // IF U WANT TO ADD ANOTHER ENEMY A NEW CALL IS NEEDED
            playerhealthbar.barDamage(collision.collider.GetComponent<slimeScript>().slimeDamage);
            health -= collision.collider.GetComponent<slimeScript>().slimeDamage;
            if (health <= 0)
            {
                sceneLoader.deathScene();
            }

        }
    }


    public IEnumerator knockback()
    {
        playerMain.animator.Play(damaged.name);
        playerMain.isDamaged = true;

        // bound the player away from the center

        yield return new WaitForSeconds(hurtTime);

        playerMain.isDamaged = false;
    }



   
}
