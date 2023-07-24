using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;
    public AnimationClip dashAnimation;
    [SerializeField] public int heavySliceDamage = 20;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        playerMain.shootLocation.transform.position = playerMain.playerRigidbody2D.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMain.heavyDashing)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (playerMain.playerInput.shurikenDown)
        {
            shuriken();
        }
        if (playerMain.playerInput.sliceDown)
        {
            slice(5, playerMain.sliceRadius);
        }
        if (playerMain.playerInput.heavySliceDown)
        {
            heavySliceAttack();
        }
    }


    public void shuriken()
    {
        Instantiate(playerMain.shurikenGameObject,playerMain.shootLocation.transform.position,playerMain.shootLocation.transform.rotation);
    }



    public void slice(int damage, float radius)
    {
        if (!playerMain.heavyDashing)
        {
            playerMain.animator.SetTrigger("Attack");
            // audio stuff
            FindObjectOfType<audioManage>().play("slice1");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerMain.shootLocation.transform.position, radius);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "Enemy") enemy.GetComponent<slimeScript>().TakeDamage(damage);
            if (enemy.tag == "blueslime") enemy.GetComponent<blueSlime>().TakeDamage(damage);
            if (enemy.tag == "red") enemy.GetComponent<redEnemyScript>().TakeDamage(damage);
            if (enemy.tag == "yellow") enemy.GetComponent<yellowEnemy>().TakeDamage(damage);
        }
    }
    public void heavySliceAttack()
    {
        playerMain.animator.Play(dashAnimation.name);
        playerMain.heavyDashing = true;
        playerMain.GetComponent<BoxCollider2D>().isTrigger = true;
        StartCoroutine(HeavyDash(playerMain.heavyDashDelay));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") collision.GetComponent<slimeScript>().TakeDamage(heavySliceDamage);
        if (collision.tag == "blueslime") collision.GetComponent<blueSlime>().TakeDamage(heavySliceDamage);
        if (collision.tag == "red") collision.GetComponent<redEnemyScript>().TakeDamage(heavySliceDamage);
        if (collision.tag == "yellow") collision.GetComponent<yellowEnemy>().TakeDamage(heavySliceDamage);


    }
    private IEnumerator HeavyDash(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerMain.GetComponent<playerMove>().Move(playerMain.shootLocation.transform.up * playerMain.heavyDashDistance);
        StartCoroutine(DontMoveYet());
        playerMain.heavyDashing=false;
        FindObjectOfType<audioManage>().play("heavyDash");
        playerMain.playerRigidbody2D.position = Vector2.MoveTowards(playerMain.playerRigidbody2D.position, playerMain.destination.transform.position, playerMain.heavyDashSpeed);
    }
    private IEnumerator DontMoveYet()
    {
        yield return new WaitForSeconds(3f);
        playerMain.GetComponent<BoxCollider2D>().isTrigger = false;

    }
}
