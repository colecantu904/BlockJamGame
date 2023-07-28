using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;
    public AnimationClip dashAnimation;

    [Header("Variables")]
    public GameObject shurikenGameObject;
    public GameObject shootLocation;
    public int shurikenDamage = 1;
    public float shurikenSpeed = 20f;
    public int sliceDamage = 3;
    public float sliceRadius = 5f;
    public bool isDamaged;
    public float heavySliceAngle = 90f;

    [Header("Heavy Slice Variable")]
    [SerializeField] public int heavySliceDamage = 20;
    public float heavyDashDelay = 2f;
    public float heavyDashDistance = 7.5f;
    public bool heavyDashing = false;
    public float heavyDashSpeed = 10f;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        shootLocation.transform.position = playerMain.playerMove.playerRigidbody2D.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!heavyDashing)
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
            slice(5, sliceRadius);
        }
        if (playerMain.playerInput.heavySliceDown)
        {
            heavySliceAttack();
        }
    }


    public void shuriken()
    {
        Instantiate(shurikenGameObject,shootLocation.transform.position,shootLocation.transform.rotation);
    }



    public void slice(int damage, float radius)
    {
        if (!heavyDashing)
        {
            playerMain.animator.SetTrigger("Attack");
            // audio stuff
            FindObjectOfType<audioManage>().play("slice1");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(shootLocation.transform.position, radius);

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
        heavyDashing = true;
        playerMain.GetComponent<BoxCollider2D>().isTrigger = true;
        StartCoroutine(HeavyDash(heavyDashDelay));
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
        yield return new WaitForSeconds(heavyDashDelay);
        playerMain.playerMove.Move(shootLocation.transform.up * heavyDashDistance);
        StartCoroutine(DontMoveYet());
        heavyDashing = false;
        Debug.Log("Dashing Heacy");
        FindObjectOfType<audioManage>().play("heavyDash");
        playerMain.playerMove.playerRigidbody2D.position = Vector2.MoveTowards(playerMain.playerMove.playerRigidbody2D.position, playerMain.playerMove.destination.transform.position, heavyDashSpeed);
    }
    private IEnumerator DontMoveYet()
    {
        yield return new WaitForSeconds(2.7f);
        playerMain.GetComponent<BoxCollider2D>().isTrigger = false;

    }
}
