using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;
    public bool heavyAttacking = false;

    public AnimationClip dashAnimation;

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
            slice(3, playerMain.sliceRadius);
        }
        if (playerMain.playerInput.heavySliceDown)
        {
            heavySliceAttack(3);
        }
    }


    public void shuriken()
    {
        Instantiate(playerMain.shurikenGameObject,playerMain.shootLocation.transform.position,playerMain.shootLocation.transform.rotation);
        Debug.Log("shurkiken");
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
            if (enemy.tag == "Enemy")
            {
                enemy.GetComponent<slimeScript>().TakeDamage(damage);
                // IF YOU ADD ANOTHER ENEMY YOU NEED A SEPERATE CALL FOR ITS SCRIPT COMPONENT HERE
            }
            
        }
    }
    public void heavySliceAttack(int damage)
    {
        playerMain.animator.Play(dashAnimation.name);
        playerMain.heavyDashing = true;
        playerMain.GetComponent<BoxCollider2D>().isTrigger = true;
        StartCoroutine(HeavyDash(playerMain.heavyDashDelay));
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(playerMain.shootLocation.transform.position, playerMain.sliceRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMain.heavyDashing && collision.tag == "Enemy")
        {
            collision.GetComponent<slimeScript>().TakeDamage(3);
            Debug.Log(collision);
        }
    }
    private IEnumerator HeavyDash(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("ashgsdfh");
        playerMain.GetComponent<playerMove>().Move(playerMain.shootLocation.transform.up * playerMain.heavyDashDistance);
        StartCoroutine(DontMoveYet());
        
        playerMain.playerRigidbody2D.position = Vector2.MoveTowards(playerMain.playerRigidbody2D.position, playerMain.destination.transform.position, playerMain.heavyDashSpeed);
    }
    private IEnumerator DontMoveYet()
    {
        Debug.Log("not move");
        yield return new WaitForSeconds(playerMain.heavyDashDelay);
        playerMain.heavyDashing=false;
        playerMain.GetComponent<BoxCollider2D>().isTrigger = false;

    }
}
