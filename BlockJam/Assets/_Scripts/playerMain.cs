using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is a main script that cenrtalizes all interactions between other scripts
// this exponentially helps with orginzaiton, Debugging, and scripting
// to access something fomr another field in a differtn script, call playerMain.<fieldneed>.<component needed>
// more information here https://www.youtube.com/watch?v=_vj1GASSO9U

public class playerMain : MonoBehaviour
{
    [SerializeField]
    internal playerInput playerInput;

    [SerializeField]
    internal playerMove playerMove;

    [SerializeField]
    internal Animator animator;

    [Header("Movement Objects")]
    public GameObject destination;
    public Rigidbody2D playerRigidbody2D;
    public SpriteRenderer rend;

    [Header("Attack Objects")]
    public GameObject shurikenGameObject;
    public GameObject shootLocation;
    public int shurikenDamage = 1;
    public float shurikenSpeed = 20f;
    [Header("Heavy Slice")]
    public float heavyDashDelay = 10f;
    public float heavyDashDistance = 7.5f;
    public bool heavyDashing = false;
    public float heavyDashSpeed = 10f;
    [Header("Slime")]
    public int slimeHealth = 10;
    public float slimeSpeed = 5f;
    public float slimeKnockback = 5f;
}
