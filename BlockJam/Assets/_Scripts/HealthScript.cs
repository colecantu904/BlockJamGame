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
    private Vector2 direction;
    public float playerKnockback = 5f;

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
            if (!playerMain.heavyDashing)
            {
                StartCoroutine(knockback(collision.collider.gameObject));



                // IF U WANT TO ADD ANOTHERl ENEMY A NEW CALL IS NEEDED
                playerhealthbar.barDamage(collision.collider.GetComponent<slimeScript>().slimeDamage);
                health -= collision.collider.GetComponent<slimeScript>().slimeDamage;
                if (health <= 0)
                {
                    sceneLoader.deathScene();
                }
            }
        }
    }


    public IEnumerator knockback(GameObject slime)
    {
        
        playerMain.animator.Play(damaged.name);
        direction = slime.GetComponent<slimeScript>().direction;
        playerMain.playerMove.Move(direction*(Vector2.one*playerKnockback));
        playerMain.isDamaged = true;

        // bound the player away from the center

        yield return new WaitForSeconds(hurtTime);

        playerMain.isDamaged = false;
    }



   
}
