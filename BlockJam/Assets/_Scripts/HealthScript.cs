using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int playerHealth = 10;
    public int health;

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
        if (!playerMain.heavyDashing)
        {
            if (collision.collider.tag == "Enemy")
            {
                 StartCoroutine(knockback(collision.collider.gameObject));
                 // IF U WANT TO ADD ANOTHERl ENEMY A NEW CALL IS NEEDED
                 playerhealthbar.barDamage(collision.collider.GetComponent<slimeScript>().slimeDamage);
                 health -= collision.collider.GetComponent<slimeScript>().slimeDamage;
            }
            if (collision.collider.tag == "blueslime")
            {
                StartCoroutine(knockback(collision.collider.gameObject));
                playerhealthbar.barDamage(collision.collider.GetComponent<blueSlime>().slimeDamage);
                health -= collision.collider.GetComponent<blueSlime>().slimeDamage;
            }
            if (health <= 0)
            {
                sceneLoader.deathScene();
            }
        }
    }

    public void takeDamage(int damage, GameObject enemy)
    {
        StartCoroutine(knockback(enemy));
        playerhealthbar.barDamage(damage);
        health -= damage;
        if (health <= 0)
        {
            sceneLoader.deathScene();
        }
    }
    public IEnumerator knockback(GameObject enemy)
    {
        
        playerMain.animator.Play(damaged.name);
        playerMain.isDamaged = true;
        if (enemy.tag == "Enemy") direction = enemy.GetComponent<slimeScript>().direction;
        if (enemy.tag == "blueslime") direction = enemy.GetComponent<blueSlime>().direction;
        if (enemy.tag == "red") direction = playerMain.shootLocation.transform.up*-1;

        playerMain.playerMove.Move(direction * (Vector2.one * playerKnockback));

        // bound the player away from the center

        yield return new WaitForSeconds(hurtTime);

        playerMain.isDamaged = false;
    }



   
}
